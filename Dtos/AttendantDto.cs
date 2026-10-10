using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaEspera.Dtos
{
    public class AttendantDto
    {
        [Required(ErrorMessage = "Digie o nome")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie o email")]
        public string Email { get; set; } = string.Empty;
        
    }
}