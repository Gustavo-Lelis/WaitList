using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.Modality
{
    public class ModalityService : IModalityService
    {
        public readonly AppDbContext _dbContext;
        public readonly IMapper _mapper;
    
        public ModalityService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseModel<ModalityModel>> CreateModality(ModalityDto modalityDto)
        {
            ResponseModel<ModalityModel> response = new ResponseModel<ModalityModel>();

            try
            {
                ModalityModel modality = new ModalityModel();
                
                modality.Name = modalityDto.Name;
                modality.Code = modalityDto.Code;
                modality.ClassTimeTable = modalityDto.ClassTimeTable;

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
    }
}