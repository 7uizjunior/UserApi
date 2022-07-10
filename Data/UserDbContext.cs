using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data
{
    public class UserDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("UsersRoles");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UsersLogins");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UsersClaims");
        }
    }
}