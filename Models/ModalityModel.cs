using System;

namespace ListaEspera.Models
{
	public class ModalityModel
{
	public int Id { get; set; }
	public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
	public DateTime CreationDate { get; set; } = DateTime.Now;

    public List<ClassGroupModel> ClassGroup { get; set; } = new List<ClassGroupModel>();


}
}

