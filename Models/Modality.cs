using System;

namespace ListaEspera.Models
{
	public class Modality
{
	public int Id { get; set; }
	public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
	public string ClassTimeTable { get; set; } = string.Empty;
	public DateTime CreationDate { get; set; } = DateTime.Now;

    public List<WaitList> ListaEspera { get; set; } = new();


}
}

