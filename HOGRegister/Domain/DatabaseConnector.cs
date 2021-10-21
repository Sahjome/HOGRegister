using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HOGRegister.Domain
{
    public class DatabaseCoonector  : IDatabaseConnector
    {
        private static DatabaseCoonector instance = null;

        private static readonly Object obj = new Object();


        public static DatabaseCoonector GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new DatabaseCoonector();
                    }
                }


                return instance;
            }
        }

        public DataTable QueryProcedureForDataTable(string procedureName, string cs, Dictionary<string, object> entity)
        {
            throw new NotImplementedException();
        }

        public string QueryProcedureForSingleValue(string procedureName, string cs, Dictionary<string, object> entity)
        {
            throw new NotImplementedException();
        }

        public DataSet QueryProcedureForDataSet(string procedureName, string cs, Dictionary<string, object> param)
        {
            try
            {
                DataSet ds = new DataSet();
                using (MySqlConnection con = new MySqlConnection(cs))
                {
                    con.Open();
                    using (MySqlCommand com = new MySqlCommand(procedureName, con))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandTimeout = 120;
                        foreach (string key in param.Keys)
                        {
                            com.Parameters.Add(key, MySqlDbType.VarChar).Value = param[key].ToString();
                        }
                        da.SelectCommand = com;
                        da.Fill(ds);
                    }
                    con.Close();
                    return ds;
                }
            }
            catch (Exception exc)
            {
                //TODO: log errors
                throw exc;
            }
        }
    }
}