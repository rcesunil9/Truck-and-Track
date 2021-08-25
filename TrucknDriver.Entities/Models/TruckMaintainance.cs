using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class TruckMaintainance
    {
        public long TruckMaintainanceid { get; set; }
        public long Truckid { get; set; }
        public long? Driverid { get; set; }
        public string Odometerreading { get; set; }
        public DateTime? Dateofrepair { get; set; }
        public string Description { get; set; }
        public string Truckimagepath { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
