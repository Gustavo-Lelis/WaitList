using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ListaEspera.Models.Enums;

namespace ListaEspera.Dtos
{
    public class WaitListDto
    {
        [Required(ErrorMessage = "Digie o id do Cliete")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Digie o id da turma")]
        public int ClassGroupId { get; set; }
        [Required(ErrorMessage = "Digie o id do atendente")]
        public int AttendantId { get; set; }
        [Required(ErrorMessage = "Digie a ccredencial")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CredentialType Credential { get; set; }
        [Required(ErrorMessage = "Digie o numero de contato do Cliete")]
        public DateTime? ContactDate { get; set; }
        [Required(ErrorMessage = "Digie o status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PositionStatus PositionStatus { get; set; }
    }
}