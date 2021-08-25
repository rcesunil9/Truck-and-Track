using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class DriverTimesheet
    {
        public long Drivertimesheetid { get; set; }
        public long? Driverid { get; set; }
        public long? Truckid { get; set; }
        public DateTime? Timesheetdate { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public double? Totalhours { get; set; }
        public double? Drivinghours { get; set; }
        public string Headquarters { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
