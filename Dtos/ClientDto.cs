using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaEspera.Dtos
{
    public class ClientDto
    {
        [Required(ErrorMessage = "Digie o nome do cliente")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie o Cpf")]
        public string Cpf { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digie o contato numerico")]
        public string Contato { get; set; } = string.Empty;
 
    }
}