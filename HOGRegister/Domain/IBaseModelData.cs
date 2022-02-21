using HOGRegister.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HOGRegister.Domain
{
    public interface IBaseModelData
    {
        ///<summary>
        ///<name>Insert the Entity to the db.</name>
        ///</summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="param">The dictionary of parameters required by the procedure</param>
        ///<returns>DataSet</returns>
        DataSet Insert(string procedureName, Dictionary<string, object> param);

        ///<summary>s
        ///<name>Insert the Entity to the db.</name>
        ///</summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="param">The dictionary of parameters required by the procedure</param>
        ///<returns>string</returns>
        string InsertForSingleResponse(string procedureName, Dictionary<string, object> param);

        ///<summary>
        ///<name>Insert the Entity to the db.</name>
        ///</summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="param">The dictionary of parameters required by the procedure</param>
        ///<returns>string</returns>
        string InsertForMultiModelResponse(string procedureName, Dictionary<string, object> param);

        ///<summary>
        ///<name>Insert the Entity to the db.</name>
        ///</summary>
        ///<param name="procedureName"> Name of the Procedure</param>
        ///<param name="param">The dictionary of parameters required by the procedure</param>
        ///<returns>DataTable</returns>
        DataSet Update(string procedureName, Dictionary<string, object> param);
    }
}
