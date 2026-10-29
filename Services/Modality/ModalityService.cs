using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListaEspera.Dtos;
using ListaEspera.Models;
using ListaEspera.Models.Enums;

namespace ListaEspera.Services.Modality
{
    public class ModalityService : IModalityService
    {
        private readonly AppDbContext _dbContext;
    
        public ModalityService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<ModalityModel>> CreateModality(ModalityDto modalityDto)
        {
            ResponseModel<ModalityModel> response = new ResponseModel<ModalityModel>();

            try
            {
                ModalityModel modality = new ModalityModel();
                
                modality.Name = modalityDto.Name;
                modality.Code = modalityDto.Code;
                

                _dbContext.Add(modality);
                await _dbContext.SaveChangesAsync();

                response.Data = modality;
                response.Message = "Create Modality with Sucess";
                response.Status = ProcessedResults.Created;

                return response;
                
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErrorServer;
                return response; 
            }
        }

        public async Task<ResponseModel<List<ModalityModel>>> ListModality()
        {
            ResponseModel<List<ModalityModel>> response = new ResponseModel<List<ModalityModel>>();

            try
            {
                var datadb = await _dbContext.Modalitys.ToListAsync();

                if(datadb.Count == 0)
                {
                    response.Message = "Nenhum dados encontrados";
                    response.Status = ProcessedResults.NotFound;
                    return response;
                }

                response.Data = datadb;
                response.Message = "List lista encontrada com sucesso "; 
                   
                       
                return response;
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ProcessedResults.ErrorServer;
                return response;
            }
        }

        public async Task<ResponseModel<ModalityModel>> FindModalityToId(int modalityId)
        {
            ResponseModel<ModalityModel> response = new ResponseModel<ModalityModel>();

            try
            {
                var data = await _dbContext.Modalitys.FindAsync(modalityId);

                if(data == null)
                {
                    response.Message = "Nenhuma modalidade encontrado";
                    response.Status = ProcessedResults.NotFound;
                    
                    return response;
                }

                response.Data = data;
                response.Message = "Modalidade encontrado";
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