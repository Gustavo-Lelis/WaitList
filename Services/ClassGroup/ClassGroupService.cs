using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;
using ListaEspera.Models.Enums;

namespace ListaEspera.Services.ClassGroup
{
    public class ClassGroupService : IClassGroupService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<ClassGroupService> _logger;
    
        public ClassGroupService(AppDbContext dbContext, ILogger<ClassGroupService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
                response.Status = ProcessedResults.Created;

                return response;
                
            }catch(Exception ex)
            {
                response.Message = "Ocorreu um erro ao tentar cadastrar uma turma";
                response.Status = ProcessedResults.ErrorServer;
                _logger.LogError(ex, "Erro ao processar");
                return response; 
            }
        }

        public async Task<ResponseModel<ClassGroupModel>> FindClassGroupToId(int classId)
        {
            ResponseModel<ClassGroupModel> response = new ResponseModel<ClassGroupModel>();

            try
            {
                var data = await _dbContext.ClassGroups.FindAsync(classId);

                if(data == null)
                {
                    response.Message = "Nenhuma turma encontrado";
                    response.Status = ProcessedResults.NotFound;
                    return response;
                }

                response.Data = data;
                response.Message = "Turma encontrado";
                
                return response;
                
            }catch(Exception ex)
            {
                response.Message = "Ocorreu um erro ao tentar encontrar a turma";
                response.Status = ProcessedResults.ErrorServer;
                _logger.LogError(ex, "Erro ao processar");
                return response;
            }
        }
    }
}