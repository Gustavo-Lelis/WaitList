using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.Modality
{
    public interface IModalityService
    {
        Task<ResponseModel<ModalityModel>> CreateModality(ModalityDto modalityDto);
        Task<ResponseModel<List<ModalityModel>>> ListModality();
    }
}