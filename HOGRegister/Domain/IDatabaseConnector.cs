using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HOGRegister.Domain
{
    public interface IDatabaseConnector
    {
        //private readonly string cs = ConfigurationManager.ConnectionStrings["AutoDB"].ConnectionString.ToString();

        ///<summary>
        ///<name>Query the procedure when expecting a datatable</name>
        /// </summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="cs"> Connection String to DB</param>
        ///<param name="entity">The dictionary of parameters required by the procedure</param>
        /// <returns>DataTable</returns>
        DataTable QueryProcedureForDataTable(string procedureName, string cs, Dictionary<string, object> entity);

        ///<summary>
        ///<name>Query the procedure when expecting a single result</name>
        /// </summary>
        /// <returns>String</returns>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="cs"> Connection String to DB</param>
        ///<param name="entity">The dictionary of parameters required by the procedure</param>
        String QueryProcedureForSingleValue(string procedureName, string cs, Dictionary<string, object> entity);

        ///<summary>
        ///<name>Query the procedure when expecting a dataset</name>
        /// </summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="cs"> Connection String to DB</param>
        ///<param name="entity">The dictionary of parameters required by the procedure</param>
        /// <returns>DataSet</returns>
        DataSet QueryProcedureForDataSet(string procedureName, string cs, Dictionary<string, object> entity);

    }
}
