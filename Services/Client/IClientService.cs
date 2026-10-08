using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.Client
{
    public interface IClientService
    {
        Task<ResponseModel<ClientModel>> CreateClient(ClientDto clientDto);
    }
}