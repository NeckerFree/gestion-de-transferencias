using Microsoft.Extensions.Logging;

namespace GestionTransferencias.Api.Logger
{
    public class FileLogger(string categoryName, string filePath) : ILogger
    {

        IDisposable? ILogger.BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            var logMessage = $"{DateTime.Now: yyyy-MM-dd HH:mm:ss.fff} [{logLevel}] {categoryName}: {formatter(state, exception)}{Environment.NewLine}";
            string? directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory) && directory is not null)
            {
               Directory.CreateDirectory(directory);
            }
            File.AppendAllText(filePath, logMessage);
        }
    }
}