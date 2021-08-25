using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class DriverVehicleInspection
    {
        public long Drivervehicleinspectionid { get; set; }
        public long? Truckid { get; set; }
        public long? Driverid { get; set; }
        public DateTime? Dateofrepair { get; set; }
        public string Trailersdescription { get; set; }
        public string Remarks { get; set; }
        public bool? Isdefectescorrected { get; set; }
        public bool? Isdefectsnotcorrected { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
