using GestionTransferencias.Domain.Entities;
using System;

public class HistorialMovimiento
{
    /// <summary>
    ///  identificador único(número entero autoincremental).
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Identificador de la billetera.
    /// </summary>
    public int WalletId { get; set; }
    /// <summary>
    ///  monto de la transferencia.
    /// </summary>
    public required decimal  Amount { get; set; }
    /// <summary>
    /// Tipo de operación (Débito/Crédito).
    /// </summary>
    public required string Tipo { get; set; }
    /// <summary>
    ///  Fecha del movimiento.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public Billetera? Billetera { get; set; }
}
