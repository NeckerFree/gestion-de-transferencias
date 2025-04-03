using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionTransferencias.Persistence.Configurations
{
    public class HistorialMovimientoConfiguration : IEntityTypeConfiguration<HistorialMovimiento>
    {
        public void Configure(EntityTypeBuilder<HistorialMovimiento> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(st => st.WalletId)
            .IsRequired();

            builder.Property(st => st.Amount)
                .IsRequired()
                 .HasPrecision(10, 2);

            builder.Property(st => st.Tipo)
                .IsRequired()
                .HasMaxLength(7);
            builder.HasOne(st => st.Billetera)
                .WithMany(p => p.HistorialMovimientos)
                .HasForeignKey(st => st.WalletId)
                .IsRequired();
            builder.HasData(
                new HistorialMovimiento
                {
                    Id = 1,
                    WalletId = 1,
                    Amount = 34567.67m,
                    Tipo = "Débito",
                    CreatedAt = new DateTime(2025, 4, 2),
                },
                new HistorialMovimiento
                {
                    Id = 2,
                    WalletId = 2,
                    Amount = 56545.00m,
                    Tipo = "Débito",
                    CreatedAt = new DateTime(2025, 4, 2),
                }
               );
        }
    }
}





