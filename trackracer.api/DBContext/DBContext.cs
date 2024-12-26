using Microsoft.EntityFrameworkCore;
using System;
using trackracer.Models.Accounts;



namespace trackracer.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<RegistrationModel> RegistrationModelTB { get; set; }
        public virtual DbSet<TrackingRequestStatusModel> TrackingRequestStatusTB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

            modelBuilder.Entity<RegistrationModel>(rm =>
            {
                rm.ToTable("RegistrationTB"); // Maps to RegistrationTB table
                rm.HasKey(e => e.UserID); // Sets UserID as primary key
                rm.Property(e => e.UserID).HasColumnName("UserID").IsRequired(); // Maps to UserID column
                rm.Property(e => e.UserName).HasColumnName("UserName").HasMaxLength(50); // Maps to UserName column with max length 50
                rm.Property(e => e.Password).HasColumnName("Password").IsRequired(); // Maps to Pawwsord column
                rm.Property(e => e.Type).HasColumnName("Type").IsRequired(); // Maps to Type column
            });
            modelBuilder.Entity<TrackingRequestStatusModel>(trs =>
            {
                trs.ToTable("TrackingRequestStatusTB"); // Maps to TrackingRequestStatus table
                trs.HasKey(e => e.ID); // Sets ID as primary key
                trs.Property(e => e.ID).HasColumnName("ID").IsRequired(); // Maps to ID column
                trs.Property(e => e.SenderID).HasColumnName("SenderID").IsRequired(); // Maps to SenderID column
                trs.Property(e => e.ReceiverID).HasColumnName("ReceiverID").IsRequired(); // Maps to ReceiverID column
                trs.Property(e => e.Status).HasColumnName("Status").HasMaxLength(50).IsRequired(); // Maps to Status column with max length 50
            });




        }
    }
}
