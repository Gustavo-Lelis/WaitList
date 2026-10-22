using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ListaEspera.Dtos;
using ListaEspera.Models;

namespace ListaEspera.Extensions
{
    public static class WaitListExtensions
    {
        public static readonly Expression<Func<WaitListModel, WaitListResponseDto>> Mapping = c => new WaitListResponseDto
        {
                Id = c.Id,

                // Dados da FK ClassGroup
                ClassGroupName = c.ClassGroup.Name,
                ClassGroupCode = c.ClassGroup.Code,
                ClassGroupDays = c.ClassGroup.Days,
                ClassGroupClassTimeTable = c.ClassGroup.ClassTimeTable,
                ClassGroupMinAge = c.ClassGroup.MinAge,
                ClassGroupMaxAge = c.ClassGroup.MaxAge,
                ClassGroupYear = c.ClassGroup.Year,

                // Dados da FK Client
                ClientCpf = c.Client.Cpf,
                ClientName = c.Client.Name,
                ClientContactNumber = c.Client.Contato,

                // Dados da FK Attendant
                AttendantName = c.Attendant.Name,

                ClientCredential = c.Credential,
                ClientPositionStatus = c.PositionStatus,
                CreationDate = c.CreationDate
        };

        public static IQueryable<WaitListResponseDto> ProjectToDto(this IQueryable<WaitListModel> query)
        {
            return query.Select(Mapping);
        }
    }
}