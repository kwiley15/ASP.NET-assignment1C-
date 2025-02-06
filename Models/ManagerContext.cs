using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace assignment1C_.Models
{
	public class ManagerContext : DbContext
	{
		public ManagerContext(DbContextOptions<ManagerContext> options)
			: base(options) 
		{ }
		public DbSet<Manager> Managers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Manager>().HasData(
				new Manager
				{
					ContactId = 1,
					FirstName = "Juan",
					LastName = "Guerro",
					PhoneNumber = "1234567890",
					Email = "juangg@gmail.com",
					CategoryId = 1,
					Organization = "RDP"
				},
				new Manager
				{
					ContactId = 2,
					FirstName = "Elara",
					LastName = "Starseeker",
					PhoneNumber = "1234567890",
					Email = "elara.starseeker@stellarnet.com ",
					CategoryId = 2,
					Organization = "Stellar Explorations"
				},
				new Manager
				{
					ContactId = 3,
					FirstName = "Cassia",
					LastName = "Moonshade",
					PhoneNumber = "7788990011",
					Email = "cassia.moonshade@lunarchive.us ",
					CategoryId = 5,
					Organization = "Celestial Archives"
				},
				new Manager
				{
					ContactId = 4,
					FirstName = "Thorne",
					LastName = "Blackthorn",
					PhoneNumber = "9988776655",
					Email = "thorne.blackthorn@shadowcraft.io ",
					CategoryId = 4,
					Organization = "Shadowbound Guild"
				},
				new Manager
				{
					ContactId = 5,
					FirstName = "Mira",
					LastName = "Luminaris",
					PhoneNumber = "1122334455",
					Email = "mira.luminaris@lightweave.org ",
					CategoryId = 3,
					Organization = "Weavers of Dawn"
				}
				);
		}

	}
}
