using Microsoft.EntityFrameworkCore;
using Projeto_Harmonia.Models;
using System;


//dotnet ef migrations add InitialCreate to create migration 
//dotnet ef database update to apply migration
public class PHDbContext : DbContext
{
	public PHDbContext(DbContextOptions<PHDbContext> options) : base(options) { }
	public DbSet<User> Users { get; set; }
	public DbSet<Family> Families { get; set; }
}