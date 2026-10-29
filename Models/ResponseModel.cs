using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Models.Enums;

namespace ListaEspera.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public ProcessedResults Status { get; set; } = ProcessedResults.Ok;
    }
}