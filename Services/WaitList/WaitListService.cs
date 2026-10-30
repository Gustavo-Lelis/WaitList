using Microsoft.EntityFrameworkCore;
using ListaEspera.Models;
using ListaEspera.Dtos;
using ListaEspera.Services.Client;
using ListaEspera.Services.ClassGroup;
using ListaEspera.Services.Attendant;
using ListaEspera.Models.Enums;
using ListaEspera.Extensions;
using ListaEspera.Dtos.WaitList;

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
                    response.Status = ProcessedResults.NotFound;
                    return response;
                }

                response.Data = dataDb;
                response.Message = "Usuarios encontrados";
                
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErrorServer;
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
                    response.Status = ProcessedResults.Conflict;
                    return response;
                }
                var clientResult = await _iClient.FindClientToId(waitListDto.ClientId);
                if(clientResult.Status != ProcessedResults.Ok)
                {
                    response.Message = clientResult.Message;
                    response.Status = clientResult.Status;
                    return response;
                }
                waitList.Client = clientResult.Data;
                waitList.ClientId = waitList.Client.Id;

                var classResult = await _iClassGroup.FindClassGroupToId(waitListDto.ClassGroupId);
                if(classResult.Status != ProcessedResults.Ok)
                {
                    response.Message = classResult.Message;
                    response.Status = classResult.Status;
                    return response;
                }
                waitList.ClassGroup = classResult.Data;
                waitList.ClassGroupId = waitList.ClassGroup.Id;

                var attendantResult = await _iAttendant.FindAttendantToId(waitListDto.AttendantId);
                if(attendantResult.Status != ProcessedResults.Ok)
                {
                    response.Message = attendantResult.Message;
                    response.Status = attendantResult.Status;
                    return response;
                    
                }
                waitList.Attendant = attendantResult.Data;
                waitList.AttendantId = waitList.Attendant.Id;

                waitList.Credential = waitListDto.Credential;

                _dbContext.Add(waitList);
                await _dbContext.SaveChangesAsync();

               var responseData = await _dbContext.WaitLists
                    .ProjectToDto()
                    .FirstOrDefaultAsync(c => c.Id == waitList.Id); 
                    
                response.Data = responseData;
                response.Message = "Cliente cadastrado na lista";
                response.Status = ProcessedResults.Created;
                
                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErrorServer;
                return response;
            }
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

                if(data.Count == 0)
                {
                    response.Message = "Lista vazia";
                    response.Status = ProcessedResults.NotFound;
                    return response;
                }

                response.Data = data;
                response.Message = data?.Any() == true ? "Lista da turma encontrada" : "Lista não encontrada";
                
                return response;
                
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErrorServer;
                return response;
            }

        }

        public Task<ResponseModel<List<WaitListResponseDto>>> ListOfModality(int ModalityId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<WaitListEditStatusDto>> UpdatePositionStatus(WaitListEditStatusDto editStatus)
        {
            ResponseModel<WaitListEditStatusDto> response = new ResponseModel<WaitListEditStatusDto>();

            try
            {
                var query = await _dbContext.WaitLists.FindAsync(editStatus.Id);
                if(query == null)
                {
                    response.Message = "Usuario não localizado";
                    response.Status = ProcessedResults.NotFound;
                    return response;
                }

                if(editStatus.PositionStatus == PositionStatus.Convidado)
                {
                    query.ContactDate = DateTime.Now;
                }

                query.PositionStatus = editStatus.PositionStatus;

                _dbContext.Update(query);
                await _dbContext.SaveChangesAsync();

                WaitListEditStatusDto data = new WaitListEditStatusDto
                {
                    Id = query.Id,
                    PositionStatus = query.PositionStatus,
                    ContactDate = query.ContactDate
                };

                response.Data = data;
                response.Message = "Update Positon Status";
                

                return response;

            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErrorServer;
                return response;
            }
        }

        public async Task<ResponseModel<WaitListResponseDto>> FindRegisterToId(int id)
        {
           ResponseModel<WaitListResponseDto> response = new ResponseModel<WaitListResponseDto>();

            try
            {
                var data = await _dbContext.WaitLists
                    .ProjectToDto()
                    .FirstOrDefaultAsync(waitList => waitList.Id == id);

                if(data == null)
                {
                    response.Message = "Nenhum resgistro encontrado";
                    response.Status = ProcessedResults.NotFound;
                    
                    return response;
                }


                response.Data = data;
                response.Message = "Registro encontrado";
                response.Status = ProcessedResults.Ok;
                
                return response;
                
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErrorServer;
                return response;
            }
        }
    }
}