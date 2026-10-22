using ListaEspera.Dtos;
using ListaEspera.Models;
using ListaEspera.Models.Enums;

namespace ListaEspera.Services.WaitList
{
    public interface IWaitListService
    {
        Task<ResponseModel<List<WaitListResponseDto>>> AllUserModality();
        Task<ResponseModel<WaitListResponseDto>> RegisterUser(WaitListDto waitListDto);
        Task<ResponseModel<List<WaitListResponseDto>>> ListOfClassToPosition(int classId, PositionStatus positionStatus);
        Task<ResponseModel<List<WaitListResponseDto>>> ListOfModality(int ModalityId);
        
    }
}