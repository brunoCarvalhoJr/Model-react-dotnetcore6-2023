using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Relationships;

namespace WebApi_Infrastructure.Models.Mappers.ProfileContext
{
    internal class UserProfileMap : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {


            builder.HasOne(x => x.User)
                .WithMany(x => x.UserProfile)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Profile)
                .WithMany(x => x.UserProfile)
                .HasForeignKey(x => x.ProfileId);
        }
    }
}
