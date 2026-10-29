using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;
using ListaEspera.Models.Enums;

namespace ListaEspera.Services.Attendant
{
    public class AttendantService : IAttendantService
    {
        private readonly AppDbContext _dbContext;

        public AttendantService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<AttendantModel>> CreateAttendant(AttendantDto attendantDto)
        {
            ResponseModel<AttendantModel> response = new ResponseModel<AttendantModel>();

            try
            {
                AttendantModel attendant = new AttendantModel();

                attendant.Name = attendantDto.Name;
                attendant.Email = attendantDto.Email;

                _dbContext.Add(attendant);
                await _dbContext.SaveChangesAsync();

                response.Data = attendant;
                response.Message = "Create Attendant With Sucessed";
                

                return response;
                
                
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErroServer;
                return response;
            }
        }

        public async Task<ResponseModel<AttendantModel>> FindAttendantToId(int attendantId)
        {
            ResponseModel<AttendantModel> response = new ResponseModel<AttendantModel>();

            try
            {
                var data = await _dbContext.Attendants.FindAsync(attendantId);

                if(data == null)
                {
                    response.Message = "Nenhuma attendant encontrado";
                    response.Status = ProcessedResults.NotFound;
                    return response;
                }

                response.Data = data;
                response.Message = "attedant  encontrado";
                
                return response;
                
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErroServer;
                return response;
            }
        }
    }
}