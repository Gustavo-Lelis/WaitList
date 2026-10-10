using System;
using ListaEspera.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public DbSet<ClientModel> Clients { get; set; }
	public DbSet<AttendantModel> Attendants { get; set; }
	public DbSet<ModalityModel> Modalitys { get; set; }
	public DbSet<WaitListModel> WaitLists { get; set; }
	public DbSet<ClassGroupModel> ClassGroups { get; set; }
}
