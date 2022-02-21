using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Settings
    {
        public int SID { get; set; }
        public int Action { get; set; }
        public int ActionPeriod { get; set; }
        public string Status { get; set; }
        public int Frequency { get; set; }
        public string Name { get; set; }
        public DateTime LastRun { get; set; }
        public DateTime NextRun { get; set; }
    }

    public enum ActionValue
    {
        Deactivate = 5,
        Nothing = 0,
        Suspend = 15,
        Disable = 20,
        Delete = 25
    }
}