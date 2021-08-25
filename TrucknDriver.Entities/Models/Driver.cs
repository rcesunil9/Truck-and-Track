using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class Driver
    {
        public long Driverid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Emailid { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string Mobilenumber { get; set; }
        public string Drivinglicenseno { get; set; }
        public string Photopath { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
