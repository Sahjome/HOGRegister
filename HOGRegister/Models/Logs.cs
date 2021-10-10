using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Logs
    {
        public long Id { get; }
        public int WorkerId { get; set; }
        public int UnitId { get; set; }
        public DateTime SignIn { get; set; }
        public DateTime SignOut { get; set; }
        public int Tag { get; set; }
        public int Service { get; set; }
    }
}