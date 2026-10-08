using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _dbContext;

        public ClientService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel<ClientModel>> CreateClient(ClientDto clientDto)
        {
            ResponseModel<ClientModel> response = new ResponseModel<ClientModel>();

            try
            {
                ClientModel client = new ClientModel();

                client.Name = clientDto.Name;
                client.Cpf = clientDto.Cpf;
                client.Contato = clientDto.Contato;

                _dbContext.Add(client);
                await _dbContext.SaveChangesAsync();

                response.Data = client;
                response.Message = "Client Create with Sucess";

                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}