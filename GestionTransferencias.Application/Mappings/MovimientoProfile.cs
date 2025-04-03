using AutoMapper;
using GestionTransferencias.Application.DTOs;

namespace GestionTransferencias.Application.Mappings
{
    public class HistorialMovimientoProfile : Profile
    {
        public HistorialMovimientoProfile()
        {
            {
                CreateMap<HistorialMovimiento, MovimientoDto>();
            }
        }
    }
}
