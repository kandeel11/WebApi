using Microsoft.EntityFrameworkCore;

namespace WebApi.Context
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<Models.Student> Students { get; set; }
    }
}
