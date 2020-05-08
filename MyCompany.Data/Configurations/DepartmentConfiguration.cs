using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DepartmentId);
            builder.Property(x => x.DepartmentId).UseIdentityColumn();
            builder.Property(x => x.DepartmentName).IsRequired();
            builder.ToTable("Departments");
        }
    }
}
