using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Services.ClassGroup
{
    public interface IClassGroupService
    {
        Task<ResponseModel<ClassGroupModel>> CreateClass(ClassGroupDto classGroupDto);
    }
}