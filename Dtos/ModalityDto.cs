using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaEspera.Dtos
{
    public class ModalityDto
    {
        [Required(ErrorMessage = "Digie o nome da Modalidade")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie o codigo da Modalidade")]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie o horario da Modalidade")]
        public string ClassTimeTable { get; set; } = string.Empty;
    }
}