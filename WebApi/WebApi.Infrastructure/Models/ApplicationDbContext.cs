using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Domain.Entities.Audit;
using WebApi_Domain.Entities.User;
using WebApi_Domain.Relationships;

namespace WebApi_Infrastructure.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LogEntity> Logs { get; set; }
        public DbSet<ScreenProfile> ScreenProfile { get; set; }
        public DbSet<ScreenRoutes> ScreenRoutes { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
    }
}
