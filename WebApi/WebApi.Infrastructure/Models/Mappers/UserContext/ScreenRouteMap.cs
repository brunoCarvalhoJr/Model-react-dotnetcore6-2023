using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Entities.User;

namespace WebApi_Infrastructure.Models.Mappers.UserContext
{
    public class ScreenRouteMap : IEntityTypeConfiguration<ScreenRoutes>
    {
        public void Configure(EntityTypeBuilder<ScreenRoutes> builder)
        {
            builder.HasOne(x => x.ScreenProfile)
                .WithMany(x => x.Routes)
                .HasForeignKey(x => x.ScreenId);
        }
    }
}