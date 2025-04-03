using GestionTransferencias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionTransferencias.Application.Interfaces
{
    public interface IBilleteraRepository
    {
        Task<Billetera?> GetByIdAsync(int id);
        Task<IEnumerable<Billetera>> GetAllAsync();
        Task AddAsync(Billetera Billetera);
        Task UpdateAsync(Billetera Billetera);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
