using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.ClassGroup
{
    public class ClassGroupService : IClassGroupService
    {
        private readonly AppDbContext _dbContext;
    
        public ClassGroupService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<ClassGroupModel>> CreateClass(ClassGroupDto classGroupDto)
        {
            ResponseModel<ClassGroupModel> response = new ResponseModel<ClassGroupModel>();

            try
            {
                ClassGroupModel classGroup = new ClassGroupModel();

                classGroup.ModalityId = classGroupDto.ModalityId;                
                classGroup.Name = classGroupDto.Name;
                classGroup.Code = classGroupDto.Code;
                classGroup.Days = classGroupDto.Days;
                classGroup.ClassTimeTable = classGroupDto.ClassTimeTable;
                classGroup.MinAge = classGroupDto.MinAge;
                classGroup.MaxAge = classGroupDto.MaxAge;
                classGroup.Year = classGroupDto.Year;
                

                _dbContext.Add(classGroup);
                await _dbContext.SaveChangesAsync();

                response.Data = classGroup;
                response.Message = "Create Class with Sucessed";

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