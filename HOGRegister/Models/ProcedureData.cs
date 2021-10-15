using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class ProcedureResponse
    {
        public int Id { get; set; }
        public int ProcName { get; set; }
        public ProcedureResponseType ResponseType { get; }
    }

    public enum ProcedureResponseType
    {
        String = 5,
        Integer = 10,
        DataTable = 15,
        DataSet = 20
    }
}