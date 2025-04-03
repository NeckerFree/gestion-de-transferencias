using GestionTransferencias.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionTransferencias.Persistence.Configurations
{
    public class BilleteraConfiguration : IEntityTypeConfiguration<Billetera>
    {
        public void Configure(EntityTypeBuilder<Billetera> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DocumentId)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Balance)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(p => p.CreatedAt)
               .IsRequired();

            builder.Property(p => p.UpdatedAt)
               .IsRequired();

            builder.HasData(
                new Billetera
                {
                    Id = 1,
                    DocumentId = "11111111",
                    Name = "Mi Billetera 1",
                    Balance = 34567.67m,
                    CreatedAt = new DateTime(2025, 4, 2),
                    UpdatedAt = new DateTime(2025, 4, 2),
                },
                new Billetera
                {
                    Id = 2,
                    DocumentId = "22222222",
                    Name = "Mi Billetera 2",
                    Balance = 56545.00m,
                    CreatedAt = new DateTime(2025, 4, 2),
                    UpdatedAt = new DateTime(2025, 4, 2),
                }
            );
        }
    }
}