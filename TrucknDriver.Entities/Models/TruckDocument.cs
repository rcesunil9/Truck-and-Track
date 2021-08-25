using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class TruckDocument
    {
        public long Truckdocumentid { get; set; }
        public long Documentid { get; set; }
        public long Truckid { get; set; }
        public long? Driverid { get; set; }
        public string Documentpath { get; set; }
        public DateTime? Expirydate { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
