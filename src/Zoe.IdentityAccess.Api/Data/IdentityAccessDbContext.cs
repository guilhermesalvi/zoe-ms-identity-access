using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Zoe.IdentityAccess.Api.Models;

namespace Zoe.IdentityAccess.Api.Data
{
    public class IdentityAccessDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public IdentityAccessDbContext(DbContextOptions<IdentityAccessDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole<Guid>>().ToTable("Role");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
        }
    }
}
