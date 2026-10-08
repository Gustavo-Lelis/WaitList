using System;
using ListaEspera.Models.Enums;

namespace ListaEspera.Models
{
    public class WaitListModel
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ModalityId { get; set; }
    public int AttendantId { get; set; }

    public CredentialType Credential { get; set; } 
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime? ContactDate { get; set; }
    public PositionStatus PositionStats { get; set; }

    public ClientModel? Client { get; set; }
    public ModalityModel? Modality { get; set; }
    public AttendantModel? Attendant { get; set; }

}
}

