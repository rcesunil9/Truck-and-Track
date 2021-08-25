using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class CompanyPaymentDetail
    {
        public long Companypaymentid { get; set; }
        public long Companyid { get; set; }
        public DateTime? Transactiondate { get; set; }
        public string Currency { get; set; }
        public decimal? Amount { get; set; }
        public string Chargeid { get; set; }
        public string Balancetransactionid { get; set; }
        public string Receipturl { get; set; }
        public string Striperesponsecontent { get; set; }
        public DateTime? Createddt { get; set; }
        public DateTime? Updateddt { get; set; }
        public DateTime? Deleteddt { get; set; }
        public long? Createdby { get; set; }
        public long? Updatedby { get; set; }
        public long? Deletedby { get; set; }
        public bool? Isdeleted { get; set; }
    }
}
