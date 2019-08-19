using Microsoft.EntityFrameworkCore;

namespace GroupJoinIssue
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=GroupJoinIssue;Trusted_Connection=True;");
        }
    }
}
