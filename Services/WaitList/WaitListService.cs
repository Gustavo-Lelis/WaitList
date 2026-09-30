using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListaEspera.Models;

namespace ListaEspera.Services.WaitList
{
    public class WaitListService : IWaitListInterface
    {
        private readonly AppDbContext _dbContext;

        public WaitListService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel<List<WaitListModel>>> AllUserModality()
        {
            ResponseModel<List<WaitListModel>> response = new ResponseModel<List<WaitListModel>>();

            try
            {
                var dataDb = await _dbContext.WaitLists.ToListAsync();

                if(dataDb.Count == 0)
                {
                    response.Message = "Nenhum dados encontrados";
                    response.Status = false;
                    return response;
                }

                response.Data = dataDb;
                response.Message = "Usuarios encontrados";
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