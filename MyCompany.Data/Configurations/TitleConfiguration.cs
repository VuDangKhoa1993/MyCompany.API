using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Data.Configurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.HasKey(x => new { x.EmployeeId, x.Titles, x.FromDate });
            builder.Property(x => x.Titles).IsRequired();
            builder.Property(x => x.FromDate).IsRequired();
            builder.HasOne(x => x.Employee).WithMany(x => x.Titles).HasForeignKey(x => x.EmployeeId);
            builder.ToTable("Titles");
        }
    }
}
