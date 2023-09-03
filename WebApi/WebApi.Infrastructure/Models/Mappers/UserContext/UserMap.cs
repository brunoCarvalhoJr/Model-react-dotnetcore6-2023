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
    public class UserMapper : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.EntityTypes)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}