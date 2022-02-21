using HOGRegister.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace HOGRegister.Data
{
    public class BaseModelData
    {
        private static readonly string conn = ConfigurationManager.ConnectionStrings["hog_register"].ConnectionString.ToString();
        private DatabaseConnector database;

        ///<summary>
        ///<name>Insert the Entity to the db.</name>
        ///</summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="param">The dictionary of parameters required by the procedure</param>
        ///<returns>DataSet</returns>
        public DataTable Insert(string procedureName, Dictionary<string, object> param)
        {
            database = new DatabaseConnector();
            var result = database.QueryProcedureForDataTable(procedureName, conn, param);
            return result;
        }

        ///<summary>s
        ///<name>Insert the Entity to the db.</name>
        ///</summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="param">The dictionary of parameters required by the procedure</param>
        ///<returns>string</returns>
        public string InsertForMultiModelResponse(string procedureName, Dictionary<string, object> param)
        {
            throw new NotImplementedException();
        }

        public string InsertForSingleResponse(string procedureName, Dictionary<string, object> param)
        {
            throw new NotImplementedException();
        }

        public DataSet QueryProcedureForDataSet(string procedureName, string cs, Dictionary<string, object> entity)
        {
            database = new DatabaseConnector();
            var result = database.QueryProcedureForDataSet(procedureName, conn, entity);
            return result;
        }

        public DataTable QueryProcedureForDataTable(string procedureName, Dictionary<string, object> entity)
        {
            database = new DatabaseConnector();
            var result = database.QueryProcedureForDataTable(procedureName, conn, entity);
            return result;
        }

        public string QueryProcedureForSingleValue(string procedureName, string cs, Dictionary<string, object> entity)
        {
            throw new NotImplementedException();
        }

        public DataSet Update(string procedureName, Dictionary<string, object> param)
        {
            throw new NotImplementedException();
        }
    }
}