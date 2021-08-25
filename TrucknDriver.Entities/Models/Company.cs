using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class Company
    {
        public long Companyid { get; set; }
        public string Companyname { get; set; }
        public string Cardnumber { get; set; }
        public long? Cardexpirymonth { get; set; }
        public long? Cardexpiryyear { get; set; }
        public long? Cardcvv { get; set; }
        public long? Drivercount { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Planenddate { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
