using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaEspera.Dtos
{
    public class ClassGroupDto
    {
        [Required(ErrorMessage = "Digie a modalidade")]
        public int ModalityId { get; set; }
        [Required(ErrorMessage = "Digie a coigo da turma")]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie a turma")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie a data")]
        public string Days { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie o horario")]
	    public string ClassTimeTable { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie a idade minima")]
        public int MinAge { get; set; }
        [Required(ErrorMessage = "Digie a idade maxima")]
        public int? MaxAge { get; set; }
        [Required(ErrorMessage = "Digie o ano")]
        public int Year { get; set; }
    }
}