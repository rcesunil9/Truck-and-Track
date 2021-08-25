using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class DriverDocumentMaster
    {
        public long Documentid { get; set; }
        public string Driverdocumentname { get; set; }
        public bool? Isactive { get; set; }
        public bool? Isadminonlyaccess { get; set; }
        public bool? Isshowonmenuonly { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
