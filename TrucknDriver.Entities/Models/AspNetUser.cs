using System;
using System.Collections.Generic;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            //AspNetUserClaims = new HashSet<AspNetUserClaim>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long? Companyid { get; set; }
        public DateTime? Dateofbirth { get; set; }
        //public long? Drivercount { get; set; }
        public bool? Isdriver { get; set; }
        public bool? Isadmin { get; set; }
        public bool? Issuperadmin { get; set; }
        //public DateTime? Startdate { get; set; }
        //public DateTime? Planenddate { get; set; }
        public string Photopath { get; set; }
        public long? Driverid { get; set; }
        public string Status { get; set; }
        public long? CreatedBy { get; set; }
        public long? updatedby { get; set; }
        public DateTime? createddt { get; set; }
        public DateTime? updateddt { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? deleteddt { get; set; }
        public long? Deletedby { get; set; }

        //public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
    }
}
