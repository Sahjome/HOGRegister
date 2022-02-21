using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HOGRegister.Data
{
    public class DatabaseConnector
    {
        private static DatabaseConnector instance = null;

        private static readonly Object obj = new Object();

        public static DatabaseConnector GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                            instance = new DatabaseConnector();
                    }
                }


                return instance;
            }
        }

        public DataTable QueryProcedureForDataTable(string procedureName, string cs, Dictionary<string, object> entity)
        {
            try
            {
                DataTable ds = new DataTable();
                using (MySqlConnection con = new MySqlConnection(cs))
                {
                    con.Open();
                    using (MySqlCommand com = new MySqlCommand(procedureName, con))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandTimeout = 120;
                        if(entity.Count > 0)
                        {

                            foreach (string key in entity.Keys)
                            {
                                com.Parameters.Add(key, MySqlDbType.VarChar).Value = entity[key].ToString();
                            }
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

        //do not use
        public string QueryProcedureForSingleValue(string procedureName, string cs, Dictionary<string, object> entity)
        {
            try
            {
                DataTable ds = new DataTable();
                using (MySqlConnection con = new MySqlConnection(cs))
                {
                    con.Open();
                    using (MySqlCommand com = new MySqlCommand(procedureName, con))
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandTimeout = 120;
                        foreach (string key in entity.Keys)
                        {
                            com.Parameters.Add(key, MySqlDbType.VarChar).Value = entity[key].ToString();
                        }
                        da.SelectCommand = com;
                        da.Fill(ds);
                    }
                    con.Close();
                    return ds.Rows[0]["Column"].ToString();
                }
            }
            catch (Exception exc)
            {
                //TODO: log errors
                throw exc;
            }
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