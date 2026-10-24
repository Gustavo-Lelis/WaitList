using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ListaEspera.Models.Enums;

namespace ListaEspera.Dtos.WaitList
{
    public class WaitListEditStatusDto
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PositionStatus PositionStatus { get; set; } 
    }
}