using DSTVWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Context
{
    public class DataContext: DbContext
    {
        public DataContext()
           : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //throw new UnintentionalCodeFirstException();
            // base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<dsCustomer> dsCustomers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<Subscribe> Subscribes { get; set; }
        public virtual DbSet<FixEnquire> FixEnquires { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }



        public System.Data.Entity.DbSet<DSTVWebApp.Models.RegisterFlow> RegisterFlows { get; set; }

        public System.Data.Entity.DbSet<DSTVWebApp.Models.Rewards> Rewards { get; set; }
        public System.Data.Entity.DbSet<DSTVWebApp.Models.SupportQuery> SupportQuerys { get; set; }
    }
}