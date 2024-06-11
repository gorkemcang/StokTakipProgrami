using Microsoft.EntityFrameworkCore;
using StokTakipProgrami.Entity;

namespace StokTakipProgrami.Database
{
	public class Context : DbContext
	{
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
