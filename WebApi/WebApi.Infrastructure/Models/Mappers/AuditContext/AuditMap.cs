using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Entities.Audit;

namespace WebApi_Infrastructure.Models.Mappers.AuditContext
{
    public class AuditMap : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.Property(x => x.LogTime)
                   .HasColumnType("datetime")
                   .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Id)
                   .HasColumnType("varchar(36)");
        }
    }
}
