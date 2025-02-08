using Microsoft.EntityFrameworkCore;
namespace assignment1C_.Models
{
	public class ManagerContext : DbContext
	{
		public ManagerContext(DbContextOptions<ManagerContext> options)
			: base(options) 
		{ }
		public DbSet<Contact> Contacts { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Contact>().HasData(
				new Contact
				{
					ContactId = 1,
					FirstName = "Juan",
					LastName = "Guerro",
					PhoneNumber = "1234567890",
					Email = "juangg@gmail.com",
					CategoryId = 1,
					Organization = "RDP",
					DateAdded = new DateTime(2023, 10, 14)
				},
				new Contact
				{
					ContactId = 2,
					FirstName = "Elara",
					LastName = "Starseeker",
					PhoneNumber = "1234567890",
					Email = "elara.starseeker@stellarnet.com ",
					CategoryId = 2,
					Organization = "Stellar Explorations",
					DateAdded = new DateTime(2023, 10, 14)
				},
				new Contact
				{
					ContactId = 3,
					FirstName = "Cassia",
					LastName = "Moonshade",
					PhoneNumber = "7788990011",
					Email = "cassia.moonshade@lunarchive.us ",
					CategoryId = 5,
					Organization = "Celestial Archives",
					DateAdded = new DateTime(2023, 10, 14)
				},
				new Contact
				{
					ContactId = 4,
					FirstName = "Thorne",
					LastName = "Blackthorn",
					PhoneNumber = "9988776655",
					Email = "thorne.blackthorn@shadowcraft.io ",
					CategoryId = 4,
					Organization = "Shadowbound Guild",
					DateAdded = new DateTime(2023, 10, 14)

				},
				new Contact
				{
					ContactId = 5,
					FirstName = "Mira",
					LastName = "Luminaris",
					PhoneNumber = "1122334455",
					Email = "mira.luminaris@lightweave.org ",
					CategoryId = 3,
					Organization = "Weavers of Dawn",
					DateAdded = new DateTime(2023, 10, 14)
				}
			);
		}

	}
}
