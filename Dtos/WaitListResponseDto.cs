using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaEspera.Models.Enums;

namespace ListaEspera.Dtos
{
    public class WaitListResponseDto
    {
        public string ClassGroupName  { get; set; } 
        public string ClassGroupCode {get; set;} 
        public string ClassGroupDays { get; set; } 
        public string ClassGroupClassTimeTable { get; set; } 
        public int ClassGroupMinAge { get; set; } 
        public int? ClassGroupMaxAge { get; set; }         
        public int ClassGroupYear  { get; set; } 

        public string ClientCpf  { get; set; } 
        public string ClientName {get; set;} 
        public string ClientContactNumber { get; set; }    
        public string AttendantName { get; set; }
        public CredentialType ClientCredential { get; set; } 
        public PositionStatus ClientPositionStatus { get; set; } 

    }
}