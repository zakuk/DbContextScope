using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Numero3.EntityFramework.Demo.DomainModel;

namespace Numero3.EntityFramework.Demo.DatabaseContext
{
	public class UserManagementDbContext : DbContext
	{
		// Map our 'User' model by convention
		public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=DbContextScopeDemo;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Overrides for the convention-based mappings.
			// We're assuming that all our fluent mappings are declared in this assembly.
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserManagementDbContext)));
		}
	}
}
