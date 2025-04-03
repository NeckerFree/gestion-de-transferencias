using System;
using System.Collections.Generic;

namespace GestionTransferencias.Domain.Entities
{

    public class Billetera
    {
        /// <summary>
        ///  identificador único (número entero autoincremental)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///  Documento de identidad de la persona propietaria de la billetera
        /// </summary>
        public required string DocumentId { get; set; }
        /// <summary>
        /// nombre del propietario de la billetera
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Saldo de la billetera
        /// </summary>
        public required decimal Balance { get; set; }
        /// <summary>
        /// fecha de apertura de la billetera.
        /// </summary>
        public required DateTime CreatedAt { get; set; }
        /// <summary>
        /// fecha de última actualización.
        /// </summary>
        public required DateTime UpdatedAt { get; set; }

        public ICollection<HistorialMovimiento> HistorialMovimientos { get; set; } = [];
    }
}
