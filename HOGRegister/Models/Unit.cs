using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Leader { get; set; }
        public string Overview { get; set; }
        public string Responsibilities { get; set; } //separated by ';'
    }
}