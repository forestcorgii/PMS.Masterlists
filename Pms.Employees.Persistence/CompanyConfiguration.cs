﻿using Pms.Employees.Domain;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pms.Employees.Persistence
{
    public class CompanyConfiguration : IEntityTypeConfiguration<CompanyView>
    {
        public void Configure(EntityTypeBuilder<CompanyView> builder)
        {
            builder.ToTable("company").HasKey(ts => ts.CompanyId);

            builder.Property(cc => cc.CompanyId).HasColumnType("VARCHAR(35)").IsRequired();
            builder.Property(cc => cc.RegisteredName).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(cc => cc.Region).HasColumnType("VARCHAR(10)");
            builder.Property(cc => cc.Acronym).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(cc => cc.BranchCode).HasColumnType("TINYINT");
            builder.Property(cc => cc.TIN).HasColumnType("VARCHAR(20)");
            builder.Property(cc => cc.Site).HasColumnType("VARCHAR(20)");

            builder.Property(cc => cc.MinimumRate).HasColumnType("DOUBLE(6,2)");
        }
    }
}
