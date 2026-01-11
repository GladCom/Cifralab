using Microsoft.Extensions.Logging;

namespace TestAPI.Utilities;

/// <summary>
///  Тестовый логгер, заменяет реальный и ничего не пишет.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class TestLogger<TEntity> : ILogger<TEntity> where TEntity : class
{
  public IDisposable? BeginScope<TState>(TState state) where TState : notnull
  {
    return null;
  }

  public bool IsEnabled(LogLevel logLevel)
  {
    return true;
  }

  public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) { }
}
