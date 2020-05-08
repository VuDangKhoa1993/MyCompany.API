using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Data.Configurations
{
    public class DepartmentEmployeeConfiguration : IEntityTypeConfiguration<DepartmentEmployee>
    {
        public void Configure(EntityTypeBuilder<DepartmentEmployee> builder)
        {
            builder.HasKey(x => new { x.DepartmentId, x.EmployeeId });
            builder.HasOne(x => x.Employees).WithMany(x => x.DepartmentEmployees).HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.Departments).WithMany(x => x.DepartmentEmployees).HasForeignKey(x => x.DepartmentId);
        }
    }
}
