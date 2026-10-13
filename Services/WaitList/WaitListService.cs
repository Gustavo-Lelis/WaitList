using Microsoft.EntityFrameworkCore;
using ListaEspera.Models;
using ListaEspera.Dtos;
using ListaEspera.Services.Client;
using ListaEspera.Services.ClassGroup;

namespace ListaEspera.Services.WaitList
{
    public class WaitListService : IWaitListService
    {
        private readonly AppDbContext _dbContext;
        private readonly IClientService _iClient;
        private readonly IClassGroupService _iClassGroup;

        public WaitListService(AppDbContext dbContext, IClientService iClient, IClassGroupService iClassGroup)
        {
            _dbContext = dbContext;
            _iClient = iClient;
            _iClassGroup = iClassGroup;
        }
        public async Task<ResponseModel<List<WaitListModel>>> AllUserModality()
        {
            ResponseModel<List<WaitListModel>> response = new ResponseModel<List<WaitListModel>>();

            try
            {
                var dataDb = await _dbContext.WaitLists.ToListAsync();

                if (dataDb.Count == 0)
                {
                    response.Message = "Nenhum dados encontrados";
                    response.Status = false;
                    return response;
                }

                response.Data = dataDb;
                response.Message = "Usuarios encontrados";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<WaitListModel>> RegisterUser(WaitListDto waitListDto)
        {
            ResponseModel<WaitListModel> response = new ResponseModel<WaitListModel>();

            try
            {
                WaitListModel waitList = new WaitListModel();

                var clientResult = EntityVlidate(await _iClient.FindClientToId(waitListDto.ClientId), "Client");
                waitList.Client = clientResult;
                waitList.ClientId = waitList.Client.Id;
                var classResult = EntityVlidate(await _iClassGroup.FindClassGroupToId(waitListDto.ClassGroupId), "Class Group");
                waitList.ClassGroup = classResult;
                waitList.ClassGroupId = waitList.ClassGroup.Id;


                _dbContext.Add(waitList);
                await _dbContext.SaveChangesAsync();

                response.Data = waitList;
                response.Message = "Cliente cadastrado na lista";
                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public T EntityVlidate<T>(ResponseModel<T> response, string entityName)
        {
            if (response == null || response.Data == null)
            {
                throw new InvalidOperationException($"{entityName} não encontrado.");
            }

            return response.Data;
        }
        /*public Enum EnumValidate(T data , String enun)
        {
            if (!Enum.IsDefined(typeof(StatusPedido), pedido.Status))
            {
                return BadRequest("Status inválido.");
            }
        }
        */

    }
}