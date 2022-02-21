using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOGRegister.Service.Model
{
    public class Settings
    {
        public int SID { get; set; }
        public int ActionValue { get; set; }
        public int ActionPeriod { get; set; }
        public string Status { get; set; }
        public int Frequency { get; set; }
        public string Name { get; set; }
        public DateTime LastRun { get; set; }
        public DateTime NextRun { get; set; }
    }
}
