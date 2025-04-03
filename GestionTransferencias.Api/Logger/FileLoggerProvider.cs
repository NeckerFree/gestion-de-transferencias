namespace GestionTransferencias.Api.Logger
{
    public class FileLoggerProvider(string filePath) : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName,filePath);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
