using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);
            builder.Property(x => x.EmployeeId).UseIdentityColumn();
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.HasMany<Title>(x => x.Titles).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
            builder.HasMany<Salaries>(x => x.Salaries).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);

            builder.ToTable("Employees");
        }
    }
}
