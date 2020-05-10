using MediReports.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MediReports.DAL
{
    public class EmployeeDAL:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
        public DbSet<Employee> Employees { get; set; }
       
    }
}