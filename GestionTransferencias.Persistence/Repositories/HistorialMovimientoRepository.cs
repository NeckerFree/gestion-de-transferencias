using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GestionTransferencias.Persistence.Repositories
{
    public class HistorialMovimientoRepository(AppDbContext context) : IHistorialMovimientoRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<HistorialMovimiento?> GetByIdAsync(int id)
        {
            return await _context.HistorialMovimientos.FindAsync(id);
        }

        public async Task<IEnumerable<HistorialMovimiento>> GetAllAsync()
        {
            return await _context.HistorialMovimientos.ToListAsync();
        }

        public async Task AddAsync(HistorialMovimiento  historialMovimiento)
        {
            await _context.HistorialMovimientos.AddAsync(historialMovimiento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HistorialMovimiento  historialMovimiento)
        {
            _context.HistorialMovimientos.Update(historialMovimiento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var historialMovimiento = await _context.HistorialMovimientos.FindAsync(id);
            if (historialMovimiento != null)
            {
                _context.HistorialMovimientos.Remove(historialMovimiento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.HistorialMovimientos.AnyAsync(p => p.Id == id);
        }
    }
}
