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
    public class ContactBookConfiguration : IEntityTypeConfiguration<ContactBook>
    {
        public void Configure(EntityTypeBuilder<ContactBook> builder)
        {
            builder.ToTable("ContactBook");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasColumnType("VARCHAR").HasMaxLength(100);

        }
    }
}
