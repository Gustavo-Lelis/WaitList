using Microsoft.EntityFrameworkCore;
using ListaEspera.Models;
using ListaEspera.Dtos;
using ListaEspera.Services.Client;
using ListaEspera.Services.ClassGroup;
using ListaEspera.Services.Attendant;
using ListaEspera.Models.Enums;
using ListaEspera.Extensions;

namespace ListaEspera.Services.WaitList
{
    public class WaitListService : IWaitListService
    {
        private readonly AppDbContext _dbContext;
        private readonly IClientService _iClient;
        private readonly IClassGroupService _iClassGroup;
        private readonly IAttendantService _iAttendant;

        public WaitListService(AppDbContext dbContext, IClientService iClient, IClassGroupService iClassGroup, IAttendantService iAttendant)
        {
            _dbContext = dbContext;
            _iClient = iClient;
            _iClassGroup = iClassGroup;
            _iAttendant = iAttendant;
        }
        public async Task<ResponseModel<List<WaitListResponseDto>>> AllUserModality()
        {
            ResponseModel<List<WaitListResponseDto>> response = new ResponseModel<List<WaitListResponseDto>>();

            try
            {
                var dataDb = await _dbContext.WaitLists
                .ProjectToDto()
                .ToListAsync();


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

        public async Task<ResponseModel<WaitListResponseDto>> RegisterUser(WaitListDto waitListDto)
        {
            ResponseModel<WaitListResponseDto> response = new ResponseModel<WaitListResponseDto>();

            try
            {
                WaitListModel waitList = new WaitListModel();
                if (await ClientValidateClassGroup(waitListDto.ClientId, waitListDto.ClassGroupId))
                {
                    response.Message = "Usuario ja Cadastrado ";
                    response.Status = false;
                    return response;
                }
                var clientResult = EntityValidate(await _iClient.FindClientToId(waitListDto.ClientId), "Client");
                waitList.Client = clientResult;
                waitList.ClientId = waitList.Client.Id;

                var classResult = EntityValidate(await _iClassGroup.FindClassGroupToId(waitListDto.ClassGroupId), "Class Group");
                waitList.ClassGroup = classResult;
                waitList.ClassGroupId = waitList.ClassGroup.Id;

                var attendantResult = EntityValidate(await _iAttendant.FindAttendantToId(waitListDto.AttendantId), "Attedant");
                waitList.Attendant = attendantResult;
                waitList.AttendantId = waitList.Attendant.Id;

                waitList.Credential = waitListDto.Credential;

                _dbContext.Add(waitList);
                await _dbContext.SaveChangesAsync();

                WaitListResponseDto responseData = new WaitListResponseDto
                {
                    Id = waitList.Id,

                    // Dados da FK ClassGroup
                    ClassGroupName = waitList.ClassGroup.Name,
                    ClassGroupCode = waitList.ClassGroup.Code,
                    ClassGroupDays = waitList.ClassGroup.Days,
                    ClassGroupClassTimeTable = waitList.ClassGroup.ClassTimeTable,
                    ClassGroupMinAge = waitList.ClassGroup.MinAge,
                    ClassGroupMaxAge = waitList.ClassGroup.MaxAge,
                    ClassGroupYear = waitList.ClassGroup.Year,

                    // Dados da FK Client
                    ClientCpf = waitList.Client.Cpf,
                    ClientName = waitList.Client.Name,
                    ClientContactNumber = waitList.Client.Contato,

                    // Dados da FK Attendant
                    AttendantName = waitList.Attendant.Name,

                    ClientCredential = waitList.Credential,
                    ClientPositionStatus = waitList.PositionStatus,
                    CreationDate = waitList.CreationDate
                };

                response.Data = responseData;
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

        private static T EntityValidate<T>(ResponseModel<T> response, string entityName)
        {
            if (response == null || response.Data == null)
            {
                throw new InvalidOperationException($"{entityName} não encontrado.");
            }

            return response.Data;
        }

        private async Task<bool> ClientValidateClassGroup(int clientId, int classGroupId)
        {
            return await _dbContext.WaitLists.AnyAsync(c => c.ClientId == clientId && c.ClassGroupId == classGroupId);

        }

        public async Task<ResponseModel<List<WaitListResponseDto>>> ListOfClassToPosition(int classId, PositionStatus positionStatus)
        {
            ResponseModel<List<WaitListResponseDto>> response = new ResponseModel<List<WaitListResponseDto>>();
            
            try
            {
                var data = await _dbContext.WaitLists
                .Where(c => c.ClassGroupId == classId && c.PositionStatus == positionStatus)
                .ProjectToDto()
                .OrderBy(c => c.CreationDate)
                .ToListAsync();

                response.Data = data;
                response.Message = data?.Any() == true ? "Lista da turma encontrada" : "Lista não encontrada";

                return response;
                
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public Task<ResponseModel<List<WaitListResponseDto>>> ListOfModality(int ModalityId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<WaitListModel>> UpdatePositionStatus(WaitListResponseDto waitListDto)
        {
            ResponseModel<WaitListModel> response = new ResponseModel<WaitListModel>();

            try
            {
                var query = await _dbContext. WaitLists.FindAsync(waitListDto.Id);
                if(query == null)
                {
                    response.Message = "Usuario não localizado";
                    return response;
                }

                query.PositionStatus = waitListDto.ClientPositionStatus;

                _dbContext.Update(query);
                await _dbContext.SaveChangesAsync();

                response.Data = query;
                response.Message = "Update Positon Status";

                return response;

            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}