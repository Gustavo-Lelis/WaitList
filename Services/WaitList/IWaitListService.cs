using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.WaitList
{
    public interface IWaitListService
    {
        Task<ResponseModel<List<WaitListResponseDto>>> AllUserModality();
        Task<ResponseModel<WaitListResponseDto>> RegisterUser(WaitListDto waitListDto);
        
    }
}