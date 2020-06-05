using Microsoft.EntityFrameworkCore;
using MyCompany.Core.Models.Entities;
using MyCompany.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyCompany.Data
{
    public class MyCompanyDbContext : DbContext
    {
        public MyCompanyDbContext(DbContextOptions<MyCompanyDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Salaries> Salaries { get; set; }
        public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
