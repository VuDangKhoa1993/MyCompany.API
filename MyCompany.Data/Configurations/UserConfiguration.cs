using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCompany.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.ToTable("Users");
        }
    }
}
