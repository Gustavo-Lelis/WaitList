using System;

namespace ListaEspera.Models
{
	public class ClientModel
	{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Contato { get; set; } = string.Empty;
	public DateTime CreationDate { get; set; } = DateTime.Now;

	public List<WaitListModel> ListaEspera { get; set; } = new();
    
	}
}

