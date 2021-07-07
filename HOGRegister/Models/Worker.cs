using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Worker
    {
        int Id { get;}
        string Title { get; set; }
        string Firstname { get; set; }
        string Midname { get; set; }
        string Lastname { get; set; }
        long Phone { get; set; }
        string Email { get; set; }
        string Gender { get; set; }
        string Address { get; set; }
        string Status { get; set; }
        byte[] FingerPrint { get; set; }
        //List<Unit> Units { get; set; }
    }
}