using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Models;

namespace ListaEspera.Services.WaitList
{
    public interface IWaitListInterface
    {
        Task<ResponseModel<List<WaitListModel>>> AllUserModality();
    }
}