using Microsoft.EntityFrameworkCore;
using BackendProj.Models;
using System.Text.Json;

namespace BackendProj.Controllers
{
	public class AppContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		private string Host = "localhost";
		private string Port = "5433";
		private string DBname = "usersdb";
		private string Username = "postgres";
		private string Password = "password";

		public AppContext()
		{
			Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=" + Host + ";Port=" + Port + ";Database=" + DBname + ";Username=" + Username + ";Password=" + Password);
		}
	}
}