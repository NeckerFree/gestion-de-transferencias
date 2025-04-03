using System;

namespace GestionTransferencias.Domain.Exceptions
{
    public class NotPermitedTransactionException(string message) : Exception(message)
    {
    }
}
