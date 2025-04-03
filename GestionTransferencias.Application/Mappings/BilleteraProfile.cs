
using AutoMapper;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Domain.Entities;

namespace GestionTransferencias.Application.Mappings
{
    public class BilleteraProfile : Profile
    {
        public BilleteraProfile()
        {
            CreateMap<Billetera, BilleteraDto>();
        }
    }
}