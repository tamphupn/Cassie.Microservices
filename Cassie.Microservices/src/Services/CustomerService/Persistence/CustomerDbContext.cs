using CustomerService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Persistence
{
	public class CustomerDbContext: DbContext
	{
		public DbSet<Customer> Customers { get; set; }

		public CustomerDbContext(DbContextOptions<CustomerDbContext> options): base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Customer>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(x => x.EmailAddress).IsUnique();
        }
    }
}

