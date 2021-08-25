using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TrucknDriver.CommonModels;

#nullable disable

namespace TrucknDriver.Entities.Models
{
    public partial class TrucknDriver_LocalContext : IdentityDbContext<AspNetUserModel, AspNetRoleModel, int>
    {
        public TrucknDriver_LocalContext()
        {
        }

        public TrucknDriver_LocalContext(DbContextOptions<TrucknDriver_LocalContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyPaymentDetail> CompanyPaymentDetails { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverDocument> DriverDocuments { get; set; }
        public virtual DbSet<DriverDocumentMaster> DriverDocumentMasters { get; set; }
        public virtual DbSet<DriverTimesheet> DriverTimesheets { get; set; }
        public virtual DbSet<DriverVehicleInspection> DriverVehicleInspections { get; set; }
        public virtual DbSet<DriverVehicleInspectionPartsMapping> DriverVehicleInspectionPartsMappings { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }
        public virtual DbSet<TruckDocument> TruckDocuments { get; set; }
        public virtual DbSet<TruckDocumentMaster> TruckDocumentMasters { get; set; }
        public virtual DbSet<TruckMaintainance> TruckMaintainances { get; set; }
        public virtual DbSet<VehiclePartsMaster> VehiclePartsMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=35.231.45.54;Initial Catalog=TrucknDriver_Local;User ID=sa;Password=#Server@7479#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.ToTable("AspNetRole");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.ToTable("AspNetRoleClaim");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AspNetRoleClaim_AspNetRole1");
            //});

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.createddt).HasColumnType("datetime");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddate");

                //entity.Property(e => e.Drivercount).HasColumnName("drivercount");

                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Isadmin).HasColumnName("isadmin");

                entity.Property(e => e.Isdriver).HasColumnName("isdriver");

                entity.Property(e => e.Issuperadmin).HasColumnName("issuperadmin");

                entity.Property(e => e.updateddt).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Photopath).HasColumnName("photopath");

                //entity.Property(e => e.Planenddate)
                //    .HasColumnType("datetime")
                //    .HasColumnName("planenddate");

                //entity.Property(e => e.Startdate)
                //    .HasColumnType("datetime")
                //    .HasColumnName("startdate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.ToTable("AspNetUserClaim");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AspNetUserClaim_AspNetUsers");
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("AspNetUserLogin");

            //    entity.Property(e => e.LoginProvider)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.ProviderKey)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany()
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AspNetUserLogin_AspNetUsers");
            //});

            //modelBuilder.Entity<AspNetUserRole>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("AspNetUserRole");

            //    entity.HasOne(d => d.Role)
            //        .WithMany()
            //        .HasForeignKey(d => d.RoleId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AspNetUserRole_AspNetRole");

            //    entity.HasOne(d => d.User)
            //        .WithMany()
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AspNetUserRole_AspNetUsers");
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("AspNetUserToken");

            //    entity.Property(e => e.LoginProvider)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(450);

            //    entity.HasOne(d => d.User)
            //        .WithMany()
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AspNetUserToken_AspNetUsers");
            //});

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Cardcvv).HasColumnName("cardcvv");

                entity.Property(e => e.Cardexpirymonth).HasColumnName("cardexpirymonth");

                entity.Property(e => e.Cardexpiryyear).HasColumnName("cardexpiryyear");

                entity.Property(e => e.Cardnumber).HasColumnName("cardnumber");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname");
                entity.Property(e => e.Drivercount).HasColumnName("drivercount");
                entity.Property(e => e.Planenddate)
                    .HasColumnType("datetime")
                    .HasColumnName("planenddate");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<CompanyPaymentDetail>(entity =>
            {
                entity.HasKey(e => e.Companypaymentid);

                entity.Property(e => e.Companypaymentid).HasColumnName("companypaymentid");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Balancetransactionid).HasColumnName("balancetransactionid");

                entity.Property(e => e.Chargeid).HasColumnName("chargeid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Currency)
                    .HasMaxLength(20)
                    .HasColumnName("currency");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Receipturl).HasColumnName("receipturl");

                entity.Property(e => e.Striperesponsecontent).HasColumnName("striperesponsecontent");

                entity.Property(e => e.Transactiondate)
                    .HasColumnType("datetime")
                    .HasColumnName("transactiondate");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Drivinglicenseno).HasColumnName("drivinglicenseno");

                entity.Property(e => e.Emailid).HasColumnName("emailid");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.Middlename).HasColumnName("middlename");

                entity.Property(e => e.Mobilenumber).HasColumnName("mobilenumber");

                entity.Property(e => e.Photopath).HasColumnName("photopath");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<DriverDocument>(entity =>
            {
                entity.Property(e => e.Driverdocumentid).HasColumnName("driverdocumentid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Documentpath).HasColumnName("documentpath");

                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("datetime")
                    .HasColumnName("expirydate");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<DriverDocumentMaster>(entity =>
            {
                entity.HasKey(e => e.Documentid);

                entity.ToTable("DriverDocumentMaster");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Driverdocumentname)
                    .IsRequired()
                    .HasColumnName("driverdocumentname");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Isadminonlyaccess).HasColumnName("isadminonlyaccess");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isshowonmenuonly).HasColumnName("isshowonmenuonly");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<DriverTimesheet>(entity =>
            {
                entity.ToTable("DriverTimesheet");

                entity.Property(e => e.Drivertimesheetid).HasColumnName("drivertimesheetid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Drivinghours).HasColumnName("drivinghours");

                entity.Property(e => e.Endtime)
                    .HasColumnType("datetime")
                    .HasColumnName("endtime");

                entity.Property(e => e.Headquarters).HasColumnName("headquarters");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Starttime)
                    .HasColumnType("datetime")
                    .HasColumnName("starttime");

                entity.Property(e => e.Timesheetdate)
                    .HasColumnType("datetime")
                    .HasColumnName("timesheetdate");

                entity.Property(e => e.Totalhours).HasColumnName("totalhours");

                entity.Property(e => e.Truckid).HasColumnName("truckid");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<DriverVehicleInspection>(entity =>
            {
                entity.ToTable("DriverVehicleInspection");

                entity.Property(e => e.Drivervehicleinspectionid).HasColumnName("drivervehicleinspectionid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Dateofrepair)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofrepair");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Isdefectescorrected).HasColumnName("isdefectescorrected");

                entity.Property(e => e.Isdefectsnotcorrected).HasColumnName("isdefectsnotcorrected");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Remarks).HasColumnName("remarks");

                entity.Property(e => e.Trailersdescription).HasColumnName("trailersdescription");

                entity.Property(e => e.Truckid).HasColumnName("truckid");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<DriverVehicleInspectionPartsMapping>(entity =>
            {
                entity.ToTable("DriverVehicleInspectionPartsMapping");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Drivervehicleinspectionid).HasColumnName("drivervehicleinspectionid");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");

                entity.Property(e => e.Vehiclepartid).HasColumnName("vehiclepartid");
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.Property(e => e.Truckid).HasColumnName("truckid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Makemodel).HasColumnName("makemodel");

                entity.Property(e => e.Modelyear).HasColumnName("modelyear");

                entity.Property(e => e.Outofservicedate)
                    .HasColumnType("datetime")
                    .HasColumnName("outofservicedate");

                entity.Property(e => e.Purchasedate)
                    .HasColumnType("datetime")
                    .HasColumnName("purchasedate");

                entity.Property(e => e.Servicedate)
                    .HasColumnType("datetime")
                    .HasColumnName("servicedate");

                entity.Property(e => e.Truckimagepath).HasColumnName("truckimagepath");

                entity.Property(e => e.Unitnumber)
                    .IsRequired()
                    .HasColumnName("unitnumber");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");

                entity.Property(e => e.Vin).HasColumnName("vin");
            });

            modelBuilder.Entity<TruckDocument>(entity =>
            {
                entity.Property(e => e.Truckdocumentid).HasColumnName("truckdocumentid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Documentpath).HasColumnName("documentpath");

                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("datetime")
                    .HasColumnName("expirydate");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Truckid).HasColumnName("truckid");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<TruckDocumentMaster>(entity =>
            {
                entity.HasKey(e => e.Documentid);

                entity.ToTable("TruckDocumentMaster");

                entity.Property(e => e.Documentid).HasColumnName("documentid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Isadminonlyaccess).HasColumnName("isadminonlyaccess");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Truckdocumentname)
                    .IsRequired()
                    .HasColumnName("truckdocumentname");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<TruckMaintainance>(entity =>
            {
                entity.ToTable("TruckMaintainance");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Dateofrepair)
                    .HasColumnType("datetime")
                    .HasColumnName("dateofrepair");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Driverid).HasColumnName("driverid");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Odometerreading).HasColumnName("odometerreading");

                entity.Property(e => e.Truckid).HasColumnName("truckid");

                entity.Property(e => e.Truckimagepath).HasColumnName("truckimagepath");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            modelBuilder.Entity<VehiclePartsMaster>(entity =>
            {
                entity.HasKey(e => e.Vehiclepartid);

                entity.ToTable("VehiclePartsMaster");

                entity.Property(e => e.Vehiclepartid).HasColumnName("vehiclepartid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddt)
                    .HasColumnType("datetime")
                    .HasColumnName("createddt");

                entity.Property(e => e.Deletedby).HasColumnName("deletedby");

                entity.Property(e => e.Deleteddt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleteddt");

                entity.Property(e => e.Ischild).HasColumnName("ischild");

                entity.Property(e => e.Isdeleted)
                    .HasColumnName("isdeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Istrailerspart).HasColumnName("istrailerspart");

                entity.Property(e => e.Parentpartid).HasColumnName("parentpartid");

                entity.Property(e => e.Partname)
                    .IsRequired()
                    .HasColumnName("partname");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updateddt)
                    .HasColumnType("datetime")
                    .HasColumnName("updateddt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
