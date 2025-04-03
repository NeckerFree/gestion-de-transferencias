//using GestionTransferencias.Domain.Entities;
//using System;

//namespace GestionTransferencias.Infrastructure.Repository
//{
//    public class BilleteraRepository(AppDbContext context) : IBilleteraRepository
//    {
//        private readonly AppDbContext _context = context;

//        public async Task AddAsync(Billetera Billetera)
//        {
//            await _context.Billeteras.AddAsync(Billetera);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<Billetera?> GetByIdAsync(int id)
//        {
//            return await _context.Billeteras.FindAsync(id);
//        }
//    }
//}
