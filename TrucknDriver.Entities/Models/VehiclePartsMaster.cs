using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class VehiclePartsMaster
    {
        public long Vehiclepartid { get; set; }
        public string Partname { get; set; }
        public bool? Ischild { get; set; }
        public long? Parentpartid { get; set; }
        public bool? Istrailerspart { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
