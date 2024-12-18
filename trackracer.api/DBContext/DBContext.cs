using Microsoft.EntityFrameworkCore;
using MyModel.Accounts.Registrationclass;
using System;



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

     


        }
    }
}
