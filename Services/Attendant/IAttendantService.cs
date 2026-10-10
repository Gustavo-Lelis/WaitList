using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.Attendant
{
    public interface IAttendantService
    {
        Task<ResponseModel<AttendantModel>> CreateAttendant(AttendantDto attendantDto);
    }
}