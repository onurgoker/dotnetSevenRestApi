using Microsoft.EntityFrameworkCore;

namespace MyMicroService
{
    public class MyDbContext : DbContext
	{
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;user=root;password=;database=dotnet";
            var serverVersion = new MySqlServerVersion(new Version(8, 1, 0));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public DbSet<User> Users { get; set; }
    }
}

