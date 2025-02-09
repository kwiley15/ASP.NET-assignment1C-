using Microsoft.EntityFrameworkCore;

namespace assignment1C_.Models
{
	// Represents the database context for managing Contacts and Categories.
	public class ManagerContext : DbContext
	{
		// Constructor to configure the database context with options.
		public ManagerContext(DbContextOptions<ManagerContext> options)
			: base(options)
		{ }

		// DbSet properties represent tables in the database.
		public DbSet<Contact> Contacts { get; set; } // Represents the "Contacts" table.
		public DbSet<Category> Categories { get; set; } // Represents the "Categories" table.

		// Configures the model and seeds initial data into the database.
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Seed initial data for the "Categories" table.
			modelBuilder.Entity<Category>().HasData(
				new Category
				{
					CategoryId = 1,
					CategoryName = "Assistant"
				},
				new Category
				{
					CategoryId = 2,
					CategoryName = "Employee"
				},
				new Category
				{
					CategoryId = 3,
					CategoryName = "Manager"
				},
				new Category
				{
					CategoryId = 4,
					CategoryName = "Friend"
				},
				new Category
				{
					CategoryId = 5,
					CategoryName = "Family"
				},
				new Category
				{
					CategoryId = 6,
					CategoryName = "Other"
				}
			);

			// Seed initial data for the "Contacts" table.
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
					DateAdded = new DateTime(2023, 10, 14),
					Slug = "1/juan-guerro/"
				},
				new Contact
				{
					ContactId = 2,
					FirstName = "Elara",
					LastName = "Starseeker",
					PhoneNumber = "1234567890",
					Email = "elara.starseeker@stellarnet.com",
					CategoryId = 2,
					Organization = "Stellar Explorations",
					DateAdded = new DateTime(2023, 10, 14),
					Slug = "2/elara-starseeker/"
				},
				new Contact
				{
					ContactId = 3,
					FirstName = "Cassia",
					LastName = "Moonshade",
					PhoneNumber = "7788990011",
					Email = "cassia.moonshade@lunarchive.us",
					CategoryId = 5,
					Organization = "Celestial Archives",
					DateAdded = new DateTime(2023, 10, 14),
					Slug = "3/cassia-moonshade/"
				},
				new Contact
				{
					ContactId = 4,
					FirstName = "Thorne",
					LastName = "Blackthorn",
					PhoneNumber = "9988776655",
					Email = "thorne.blackthorn@shadowcraft.io",
					CategoryId = 4,
					Organization = "Shadowbound Guild",
					DateAdded = new DateTime(2023, 10, 14),
					Slug = "4/thorne-blackthorn/"
				},
				new Contact
				{
					ContactId = 5,
					FirstName = "Mira",
					LastName = "Luminaris",
					PhoneNumber = "1122334455",
					Email = "mira.luminaris@lightweave.org",
					CategoryId = 3,
					Organization = "Weavers of Dawn",
					DateAdded = new DateTime(2023, 10, 14),
					Slug = "5/mira-luminaris/"
				}
			);
		}
	}
}