using HouseholdExpensesTrackerServer.Domain.Identities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Context.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(e => e.Id);
            var navigation = builder.Metadata
                .FindNavigation(nameof(Role.RolePermissions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

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
            builder.Property(e => e.RowVersion)
                .IsRowVersion();
            builder.Property(e => e.Version)
                .IsRequired()
                .HasColumnName("Version");
            builder.Property(e => e.AggregateId)
                .IsRequired()
                .HasColumnName("AggregateId");

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.Name)
                .HasMaxLength(255);
        }
    }
}
