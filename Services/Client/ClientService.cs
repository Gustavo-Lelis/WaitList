using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;
using ListaEspera.Models.Enums;

namespace ListaEspera.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ClientService> _logger;

        public ClientService(AppDbContext dbContext, ILogger<ClientService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
                response.Status = ProcessedResults.Created;

                return response;
            }
            catch(Exception ex)
            {
                response.Message = "Ocorreu um erro ao tentar criar o client";
                response.Status = ProcessedResults.ErrorServer;
                _logger.LogError(ex, "Erro ao processar");
                return response;
            }
        }

        public async Task<ResponseModel<ClientModel>> FindClientToId(int clientId)
        {
            ResponseModel<ClientModel> response = new ResponseModel<ClientModel>();

            try
            {
                var data = await _dbContext.Clients.FindAsync(clientId);

                if(data == null)
                {
                    response.Message = "Nenhum usuario encontrado";
                    response.Status = ProcessedResults.NotFound;
                    return response;
                }

                response.Data = data;
                response.Message = "Cliiente encontrado";
               
                return response;
                
            }catch(Exception ex)
            {
                response.Message = "Ocorreu um erro ao buscar cliente";
                response.Status = ProcessedResults.ErrorServer;
                _logger.LogError(ex, "Erro ao processar");
                return response;
            }
        }
    }
}