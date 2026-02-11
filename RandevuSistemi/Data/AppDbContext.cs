using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models;

namespace RandevuSistemi.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Customer> Customers => Set<Customer>();
		public DbSet<Appointment> Appointments => Set<Appointment>();
	}
}
