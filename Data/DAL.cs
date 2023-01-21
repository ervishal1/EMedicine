using EMedicine.Models;
using Microsoft.EntityFrameworkCore;

namespace EMedicine.Data
{
	public class DAL : DbContext
	{
		public DAL(DbContextOptions<DAL> options) : base(options)
		{
		}

		public DbSet<Users> Users { get; set; }
		public DbSet<Medicines> Medicines { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Orders> Orders{ get; set; }
		public DbSet<OrderItems> OrderItems{ get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
