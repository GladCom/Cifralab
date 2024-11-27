namespace Students.Reports.Core.Generators;

/// <summary>
///   Генератор отчетов.
/// </summary>
public abstract class BaseReportGenerator
{
  /// <summary>
  ///   Путь к файлу.
  /// </summary>
  /// <param name="template">Шаблон.</param>
  /// <returns>Путь.</returns>
  protected string PathTemplate(string template)
  {
    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", $"{template}");
  }
}