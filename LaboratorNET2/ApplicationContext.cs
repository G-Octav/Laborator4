using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = System.Data.Entity.DbContext;

namespace LaboratorNET2
{
    public class ApplicationContext : DbContext
    {
        private readonly string _phoneNumberRegEx;
        private readonly string _connectionString;

        public ApplicationContext()
        {
            _phoneNumberRegEx =
                @"/^(\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\s|\.|\-)?([0-9]{3}(\s|\.|\-|)){2}$/igm";

            // Schimba asta daca muti proiectul pe alt pc
            _connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired().HasMaxLength(300);
//            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).IsRequired().?
        }

        public virtual System.Data.Entity.DbSet<Employee> Employees { get; set; }
        public virtual System.Data.Entity.DbSet<Customer> Customers { get; set; }
    }
}