using HouseholdExpensesTrackerServer.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdExpensesTrackerServer.Infrastructure.Context.Configurations
{
    public class CredentialTypeConfiguration : IEntityTypeConfiguration<CredentialType>
    {
        public void Configure(EntityTypeBuilder<CredentialType> builder)
        {
            builder.ToTable("CredentialTypes");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(255);
        }
    }
}
