using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityWebApi.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        // This is where we will be adding the model
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {

        }

        // override the default pattern of identity db context
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name= "Admin", ConcurrencyStamp="1", NormalizedName="Admin"},
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" },
                new IdentityRole() { Name = "HR", ConcurrencyStamp = "3", NormalizedName = "HR" }
                );
        }
    }
}
