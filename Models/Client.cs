using System;

namespace ListaEspera.Models
{
	public class Client
	{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Contato { get; set; } = string.Empty;
	public DateTime CreationDate { get; set; } = DateTime.Now;

	public List<WaitList> ListaEspera { get; set; } = new();
    
	}
}

