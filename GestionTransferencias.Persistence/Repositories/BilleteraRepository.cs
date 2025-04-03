
using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Domain.Entities;
using GestionTransferencias.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GestionTransferencias.Persistence.Repositories
{
    public class BilleteraRepository(AppDbContext context) : IBilleteraRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Billetera?> GetByIdAsync(int id)
        {
            return await _context.Billeteras.FindAsync(id);
        }

        public async Task<IEnumerable<Billetera>> GetAllAsync()
        {
            return await _context.Billeteras.ToListAsync();
        }

        public async Task AddAsync(Billetera Billetera)
        {
            await _context.Billeteras.AddAsync(Billetera);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Billetera Billetera)
        {
            _context.Billeteras.Update(Billetera);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Billetera = await _context.Billeteras.FindAsync(id);
            if (Billetera != null)
            {
                _context.Billeteras.Remove(Billetera);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Billeteras.AnyAsync(p => p.Id == id);
        }
    }
}
