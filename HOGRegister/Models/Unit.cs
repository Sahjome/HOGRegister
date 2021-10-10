using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Unit
    {
        public int Id { get;}
        public string Name { get; set; }
        public string LeaderName { get; set; }
        public string Overview { get; set; }
        public string[] Responsibilities { get; set; } //separated by ';'
    }
}