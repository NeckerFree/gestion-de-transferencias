using System;

namespace GestionTransferencias.Domain.Exceptions.Base
{
    public class NotFoundException(string message): Exception( message)
    {
    }
}
