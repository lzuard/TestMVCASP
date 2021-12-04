using Microsoft.EntityFrameworkCore;

namespace Data.LTS.Database
{
    public partial class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}