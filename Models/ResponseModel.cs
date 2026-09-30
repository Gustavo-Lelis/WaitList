using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaEspera.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}