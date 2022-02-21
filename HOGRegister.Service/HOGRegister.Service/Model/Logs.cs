using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Service.Model
{
    public class Logs
    {
        public long Id { get; set; }
        public int WorkerId { get; set; }
        public int Status { get; set; }
        public DateTime SignIn { get; set; }
        public DateTime SignOut { get; set; }
        public int TagNo { get; set; }
        public string TagCategory { get; set; }
    }
}