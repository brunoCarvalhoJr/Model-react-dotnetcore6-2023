using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Entities.User;

namespace WebApi_Infrastructure.Models.Mappers.ProfileContext
{
    internal class ScreenProfileMap : IEntityTypeConfiguration<ScreenProfile>
    {
        public void Configure(EntityTypeBuilder<ScreenProfile> builder)
        {
            builder.HasIndex(x => x.ScreenName).IsUnique();
        }
    }
}
