using Microsoft.EntityFrameworkCore;

namespace Data.LTS.Database
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=ec2-54-247-158-179.eu-west-1.compute.amazonaws.com; Port=5432;Database=dcgikuvl1nlm34;Username=kqznyzazvjcihf;Password=03e7f56d42eb7cd51530313e57b249246910a3fff62d4ba20e2ab5da919325b1");
        }
    }
}