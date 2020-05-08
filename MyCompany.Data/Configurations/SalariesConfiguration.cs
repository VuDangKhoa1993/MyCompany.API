using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Data.Configurations
{
    public class SalariesConfiguration : IEntityTypeConfiguration<Salaries>
    {
        public void Configure(EntityTypeBuilder<Salaries> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.FromDate });
            builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.FromDate).IsRequired();
            builder.Property(x => x.ToDate).IsRequired();
            builder.HasOne(x => x.Employee).WithMany(x => x.Salaries).HasForeignKey(x => x.EmployeeId);
            builder.ToTable("Salaries");
        }
    }
}
