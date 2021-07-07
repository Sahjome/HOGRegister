using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Logs
    {
        long Id { get; }
        int WorkerId { get; set; }
        int UnitId { get; set; }
        DateTime SignIn { get; set; }
        DateTime SignOut { get; set; }
        int Tag { get; set; }
        int Service { get; set; }
    }
}