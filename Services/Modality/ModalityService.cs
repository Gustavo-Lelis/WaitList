using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListaEspera.Dtos;
using ListaEspera.Models;

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

                return response;
                
            }catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
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
                    response.Status = false;
                    return response;
                }

                response.Data = datadb;
                response.Message = "List lista encontrada com sucesso ";         
                       
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