﻿using HouseholdExpensesTrackerServer.Domain.Households.Model;
using HouseholdExpensesTrackerServer.Domain.Savings.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Context.Configurations
{
    public class SavingConfiguration : IEntityTypeConfiguration<Saving>
    {
        public void Configure(EntityTypeBuilder<Saving> builder)
        {
            builder.ToTable("Savings");

            builder.HasKey(e => e.Id);
            builder.HasOne<SavingType>()
                .WithMany()
                .HasForeignKey(e => e.SavingTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Household>()
                .WithMany()
                .HasForeignKey(e => e.HouseholdId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property("_createdBy")
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("CreatedBy");
            builder.Property("_createdDate")
                .IsRequired()
                .HasColumnName("CreatedDate");
            builder.Property("_updatedBy")
                .HasMaxLength(255)
                .HasColumnName("UpdatedBy");
            builder.Property("_updatedDate")
                .HasColumnName("UpdatedDate");
            builder.Property(e => e.Version)
                .IsConcurrencyToken()
                .HasColumnName("Version");
            builder.Property(e => e.Identity)
                .IsRequired()
                .HasColumnName("Identity");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("money");
            builder.Property(e => e.Date)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasMaxLength(255);

        }
    }
}
