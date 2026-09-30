using System;
using ListaEspera.Models.Enuns;

namespace ListaEspera.Models
{
    public class WaitList
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ModalityId { get; set; }
    public int AttendantId { get; set; }

    public CredentialType Credential { get; set; } 
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime? ContactDate { get; set; }
    public PositionStatus PositionStats { get; set; }

    public Client Client { get; set; } = new();
    public Modality Modality { get; set; } = new();
    public Attendant Attendant { get; set; } = new();

}
}

