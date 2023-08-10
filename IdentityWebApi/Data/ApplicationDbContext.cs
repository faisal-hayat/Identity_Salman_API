using Microsoft.EntityFrameworkCore;

namespace IdentityWebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {
        }
        // This is where we will be adding the model
    }
}
