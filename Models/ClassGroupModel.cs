using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaEspera.Models
{
    public class ClassGroupModel
    {
        public int Id { get; set; }
        public int ModalityId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Days { get; set; } = string.Empty;
	    public string ClassTimeTable { get; set; } = string.Empty;
        public int MinAge { get; set; }
        public int? MaxAge { get; set; }
        public int Year { get; set; }
	    public DateTime CreationDate { get; set; } = DateTime.Now;

        public ModalityModel? Modality {get ; set; }

        public List<WaitListModel> ListaEspera { get; set; } = new List<WaitListModel>();
    }
}