using Microsoft.AspNetCore.Mvc;

namespace Students.APIServer.Controllers.Interfaces;

public interface ISearchExecutionService
{
  /// <summary>
  /// Выполняет поиск объектов по параметрам, переданным в виде JSON-строки без указания типа.
  /// </summary>
  /// <param name="searchWithoutType">
  /// JSON-строка с параметрами поиска.
  /// </param>
  /// <returns>
  /// HTTP-результат, содержащий список найденных объектов
  /// либо информацию об ошибке выполнения поиска.
  /// </returns>
  Task<IActionResult> SearchAsync(string searchWithoutType);
}