using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Models
{
    public class Worker
    {
        public int Id { get;}
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Midname { get; set; }
        public string Lastname { get; set; }
        long Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public byte[] FingerPrint { get; set; }
        //List<Unit> Units { get; set; }
    }
}