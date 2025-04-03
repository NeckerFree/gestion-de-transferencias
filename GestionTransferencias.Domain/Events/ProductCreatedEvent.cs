using GestionTransferencias.Domain.Entities;

namespace GestionTransferencias.Domain.Events
{

    public class BilleteraCreatedEvent(Billetera Billetera)
    {
        public Billetera Billetera { get; } = Billetera;
    }
}