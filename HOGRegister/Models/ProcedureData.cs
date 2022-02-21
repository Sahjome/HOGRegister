using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class ProcedureResponse
    {
        ///<summary>
        ///Register all procedures in the database
        ///with their expected response type
        ///</summary>
        public int Id { get; set; }
        public string ProcedureName { get; set; }
        public int ResponseType { get; set; }
        public ProcedureResponseType ProcedureResponseType
        {
            get { return (ProcedureResponseType)ResponseType; }
            set { ResponseType = (int)value; }
        }
    }

    public enum ProcedureResponseType
    {
        String = 5,
        Integer = 10,
        DataTable = 15,
        DataSet = 20
    }
}
