using GestionTransferencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionTransferencias.Application.Interfaces
{
    public interface IHistorialMovimientoRepository
    {
        Task<HistorialMovimiento?> GetByIdAsync(int id);
        Task<IEnumerable<HistorialMovimiento>> GetAllAsync();
        Task AddAsync(HistorialMovimiento Movimiento);
        Task<bool> ExistsAsync(int id);
    }
}
