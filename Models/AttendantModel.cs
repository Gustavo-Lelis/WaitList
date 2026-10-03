using System;

namespace ListaEspera.Models{
	public class AttendantModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public DateTime CreationDate { get; set; } = DateTime.Now;

    	public List<WaitListModel> ListaEspera { get; set; } = new List<WaitListModel>();
	}
}