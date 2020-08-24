using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace SalesTax.Models
{

	public class AppDbContext : DbContext 
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
	{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
			{
			modelBuilder.Entity<Product>()
				.HasKey(c => c.Id);
			modelBuilder.Seed();

		}

		public DbSet<Product> Products { get; set; }
	
	}
}
