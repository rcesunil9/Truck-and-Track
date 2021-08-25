using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class Truck
    {
        public long Truckid { get; set; }
        public string Unitnumber { get; set; }
        public string Vin { get; set; }
        public string Modelyear { get; set; }
        public string Makemodel { get; set; }
        public DateTime? Purchasedate { get; set; }
        public DateTime? Outofservicedate { get; set; }
        public DateTime? Servicedate { get; set; }
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
