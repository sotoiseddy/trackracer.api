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
        public virtual DbSet<ChatModel> ChatTB { get; set; }
      
        // dotnet ef migrations add InitialCreate --project C:\Users\lomn_\source\repos\trackracer.api\trackracer.api\trackracer.api.csproj
        // dotnet ef database update --project C:\Users\lomn_\source\repos\trackracer.api\trackracer.api\trackracer.api.csproj

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //        modelBuilder.Entity<RegistrationModel>(rm =>
        //        {
        //            rm.ToTable("RegistrationTB"); // Maps to RegistrationTB table
        //            rm.HasKey(e => e.UserID); // Sets UserID as primary key
        //            rm.Property(e => e.UserID).HasColumnName("UserID").IsRequired(); // Maps to UserID column
        //            rm.Property(e => e.UserName).HasColumnName("UserName").HasMaxLength(50); // Maps to UserName column with max length 50
        //            rm.Property(e => e.Password).HasColumnName("Password").IsRequired(); // Maps to Pawwsord column
        //            rm.Property(e => e.Type).HasColumnName("Type").IsRequired(); // Maps to Type column
        //        });
        //        modelBuilder.Entity<TrackingRequestStatusModel>(trs =>
        //        {
        //            trs.ToTable("TrackingRequestStatusTB"); // Maps to TrackingRequestStatus table
        //            trs.HasKey(e => e.ID); // Sets ID as primary key
        //            trs.Property(e => e.ID).HasColumnName("ID").IsRequired(); // Maps to ID column
        //            trs.Property(e => e.SenderID).HasColumnName("SenderID").IsRequired(); // Maps to SenderID column
        //            //trs.Property(e => e.ReceiverID).HasColumnName("ReceiverID").IsRequired(); // Maps to ReceiverID column
        //            trs.Property(e => e.Status).HasColumnName("Status").HasMaxLength(50).IsRequired(); // Maps to Status column with max length 50
        //           // trs.Property(e => e.ReceiverName).HasColumnName("ReceiverName").IsRequired();
        //            trs.Property(e => e.SenderName).HasColumnName("SenderName").IsRequired();
        //            trs.Property(e => e.Text).HasColumnName("Text").HasMaxLength(500);
        //            trs.Property(e => e.RequestType).HasColumnName("RequestType").IsRequired();
        //            trs.Property(e => e.Location).HasColumnName("Location").HasMaxLength(500);
        //            trs.Property(e => e.Pay).HasColumnName("Pay").IsRequired();
        //        });
        //        modelBuilder.Entity<ChatModel>(trs =>
        //        {
        //            trs.ToTable("ChatTB"); // Maps to TrackingRequestStatus table
        //            trs.HasKey(e => e.Id); // Sets ID as primary key
        //            trs.Property(e => e.Id).HasColumnName("Id").IsRequired(); // Maps to ID column
        //            trs.Property(e => e.SenderId).HasColumnName("SenderId").IsRequired(); // Maps to SenderID column
        //            trs.Property(e => e.ReceiverId).HasColumnName("ReceiverId").IsRequired(); // Maps to SenderID column
        //            trs.Property(e => e.ChatMessage).HasColumnName("ChatMessage").IsRequired(); // Maps to SenderID column
        //            trs.Property(e => e.ChatId).HasColumnName("ChatId").IsRequired(); // Maps to SenderID column
        //            trs.Property(e => e.SenderName).HasColumnName("SenderName").IsRequired();
        //            trs.Property(e => e.ReceiverName).HasColumnName("ReceiverName").IsRequired();

        //        });



        //    }
    }
}
