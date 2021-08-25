using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class DriverVehicleInspectionPartsMapping
    {
        public long DriverVehicleInspectionPartsMappingid { get; set; }
        public long? Drivervehicleinspectionid { get; set; }
        public long? Vehiclepartid { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
