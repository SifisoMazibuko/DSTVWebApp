namespace DSTVWebApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DSModel : DbContext
    {
        public DSModel()
            : base("name=DSModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<dsCustomer> dsCustomers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<RegisterFlow> RegisterFlows { get; set; }
        public virtual DbSet<Show> Shows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Shows)
                .WithOptional(e => e.Admin)
                .HasForeignKey(e => e.Admin_adminID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Profiles)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Shows)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_CustomerID);

            modelBuilder.Entity<dsCustomer>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.dsCustomer)
                .HasForeignKey(e => e.dsCustomer_DsCustomerID);

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Payment)
                .HasForeignKey(e => e.Payment_paymentID);
        }
    }
}
