using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Unit
    {
        int Id { get;}
        string Name { get; set; }
        string LeaderName { get; set; }
        string Overview { get; set; }
        string[] Responsibilities { get; set; }
    }
}