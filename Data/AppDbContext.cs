using System;
using ListaEspera.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public DbSet<Client> Clients { get; set; }
	public DbSet<Attendant> Attendants { get; set; }
	public DbSet<Modality> Modalitys { get; set; }
	public DbSet<WaitList> WaitLists { get; set; }
}
