using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.Attendant
{
    public class AttendantService : IAttendantService
    {
        private readonly AppDbContext _dbContext;

        public AttendantService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<AttendantModel>> CreateAttendant(AttedantDto attendantDto)
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
                response.Status = false;
                return response;
            }
        }
    }
}