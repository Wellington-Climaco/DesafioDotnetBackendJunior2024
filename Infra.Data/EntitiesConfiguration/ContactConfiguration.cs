using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Domain;

namespace Infra.Data.EntitiesConfiguration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasColumnType("VARCHAR").HasMaxLength(100);

            builder.Property(x => x.CompanyId).HasColumnName("CompanyId").HasColumnType("INT");

            builder.Property(x => x.Email).IsRequired().HasColumnName("Email").HasColumnType("VARCHAR").HasMaxLength(100);

            builder.Property(x => x.PhoneNumber).IsRequired().HasColumnName("PhoneNumber").HasColumnType("VARCHAR").HasMaxLength(50);

            builder.HasOne(x => x.ContactBook).WithMany(x => x.Contact).HasForeignKey(x => x.ContactBookId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
