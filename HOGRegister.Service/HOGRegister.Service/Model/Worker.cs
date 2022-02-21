using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOGRegister.Service.Model
{
    public class Worker
    {
        public Worker()
        {
            //Units = new List<Unit>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Midname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }

        public WorkerStatus WorkerStatus
        {
            get { return (WorkerStatus)Status; }
            set { Status = (int)value; }
        }
        public int Role { get; set; }
        public UserRole UserRole
        {
            get { return (UserRole)Role; }
            set { Role = (int)Role; }
        }
        public byte[] FingerPrint { get; set; }
        //public List<Unit> Units { get; set; }
    }

    public enum UserRole
    {
        Admin = 5,
        Leader = 10,
        Clocker = 15,
        Worker = 20,
        Deleted = 25
    }

    public enum WorkerStatus
    {
        Inactive = 5,
        Active = 10,
        Suspended = 15,
        Disabled = 20,
        Deleted = 25
    }
}