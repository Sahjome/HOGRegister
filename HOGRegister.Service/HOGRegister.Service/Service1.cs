using HOGRegister.Service.Domain;
using HOGRegister.Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HOGRegister.Service
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        private BaseModelData dataModel;

        public Service1()
        {
            InitializeComponent();
        }

    protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds  
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
            timer.Enabled = false;
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);
            //todo: check the status of the settings
            var procedure = "spSettings";
            var parameters = new Dictionary<string, object>
            {
                { "SID", 1000},
                { "ACTIONVALUE", 0},
                { "ACTIONPERIOD", 0},
                { "STATUS", 0},
                { "FREQUENCY", 0},
                { "NAME", string.Empty},
                { "LASTRUN", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "NEXTRUN", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")},
                { "TRANSTYPE", 100}
            };
            dataModel = new BaseModelData();
            var result = dataModel.QueryProcedureForDataTable(procedure, parameters);

            Settings settings = new Settings();
            settings = (from DataRow dr in result.Rows
                        select new Settings()
                        {
                            SID = Convert.ToInt32(dr["SID"]),
                            ActionValue = Convert.ToInt32(dr["ActionValue"]),
                            ActionPeriod = Convert.ToInt32(dr["ActionPeriod"]),
                            Frequency = Convert.ToInt32(dr["Frequency"]),
                            Status = dr["Status"].ToString(),
                            Name = dr["Name"].ToString(),
                            NextRun = Convert.ToDateTime(dr["NextRun"]),
                            LastRun = Convert.ToDateTime(dr["LastRun"])
                        }).FirstOrDefault();

            if (settings.Status == "ON")
            {
                WriteToFile("Service is on at " + DateTime.Now);
                if (DateTime.Now >= settings.NextRun)
                {
                    var res = dataModel.QueryProcedureForDataTable("spLogs", new Dictionary<string, object>
                    {
                        { "ID", 0 },
                        { "WORKERID", 0 },
                        { "SIGNIN", string.Empty },
                        { "SIGNOUT", string.Empty },
                        { "TAGNO", 0 },
                        { "TAGCATEGORY", string.Empty },
                        { "TRANSTYPE", 105}
                    });

                    List<Logs> logs = new List<Logs>();
                    logs = (from DataRow dr in res.Rows
                        select new Logs()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            WorkerId = Convert.ToInt32(dr["WorkerId"]),
                            Status = Convert.ToInt32(dr["Status"]),
                            TagNo = Convert.ToInt32(dr["TagNo"]),
                            TagCategory = dr["TagCategory"].ToString(),
                            SignOut = Convert.ToDateTime(dr["SignOut"]),
                            SignIn = Convert.ToDateTime(dr["SignIn"])
                        }).ToList();

                    if (logs != null && logs.Count > 0 && settings.ActionValue > 0)
                    {
                        foreach (var log in logs)
                        {
                            int status = log.SignOut == null && log.SignIn != null ? (int)WorkerStatus.Inactive : 
                                log.SignIn != null && log.SignOut != null ? log.Status : settings.ActionValue;
                            
                            dataModel = new BaseModelData();
                            var workers = dataModel.QueryProcedureForDataTable("spWorkers", new Dictionary<string, object>
                            {
                                { "ID", log.WorkerId },
                                { "TITLE", string.Empty },
                                { "FIRSTNAME", string.Empty },
                                { "MIDNAME", string.Empty },
                                { "LASTNAME", string.Empty },
                                { "PHONE", string.Empty },
                                { "EMAIL", string.Empty },
                                { "ADDRESS", string.Empty },
                                { "GENDER", string.Empty },
                                { "STATUS", status },
                                { "ROLE", 0 },
                                { "FINGERPRINT", string.Empty },
                                { "UNITS", string.Empty },
                                { "TRANSTYPE", 106 }
                            });
                            //catch excepption
                        }
                    }
                    //update the last and next run
                    
                    dataModel.QueryProcedureForDataTable(procedure, new Dictionary<string, object>
                    {
                        { "SID", 1000},
                        { "ACTIONVALUE", 0},
                        { "ACTIONPERIOD", 0},
                        { "STATUS", 0},
                        { "FREQUENCY", 0},
                        { "NAME", string.Empty},
                        { "LASTRUN", DateTime.Now},
                        { "NEXTRUN", DateTime.Now.AddDays(settings.ActionPeriod)},
                        { "TRANSTYPE", 103}
                    });
                }
            }
            else
                WriteToFile("Service is off at " + DateTime.Now);

        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\HOGRegisterLogs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\HOGRegisterLogs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
