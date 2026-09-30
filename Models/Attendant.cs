using System;

namespace ListaEspera.Models{
	public class Attendant
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string SenhaHash { get; set; } = string.Empty;
		public DateTime CreationDate { get; set; } = DateTime.Now;

    	public List<WaitList> ListaEspera { get; set; } = new();
	}
}