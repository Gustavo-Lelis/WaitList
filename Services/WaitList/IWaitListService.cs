using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.WaitList
{
    public interface IWaitListService
    {
        Task<ResponseModel<List<WaitListModel>>> AllUserModality();
        Task<ResponseModel<WaitListModel>> RegisterUser(WaitListDto waitListDto);
        
    }
}