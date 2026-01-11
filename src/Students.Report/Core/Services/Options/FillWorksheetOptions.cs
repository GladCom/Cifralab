namespace Students.Reports.Core.Services.Options;

/// <summary>
/// Параметры для заполнения листа отчета.
/// </summary>
/// <typeparam name="TEntity">Сущность.</typeparam>
public class FillWorksheetOptions<TEntity> where TEntity : class
{
  /// <summary>
  /// Список сущностей.
  /// </summary>
  public IEnumerable<TEntity>? ListEntity { get; set; }

  /// <summary>
  /// Начальная строка.
  /// </summary>
  public int StartingRow { get; set; }

  /// <summary>
  /// Конечная колонка.
  /// </summary>
  public int EndColumn { get; set; }
}
