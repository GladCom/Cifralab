namespace Students.Reports.Core.Services.Options;

/// <summary>
///   Параметры для заполнения участка данными.
/// </summary>
public class FillAreaOptions
{
  /// <summary>
  ///   Список сущностей.
  /// </summary>
  public IEnumerable<object>? Entities { get; set; }

  /// <summary>
  ///   Начальная строка.
  /// </summary>
  public int StartRow { get; set; }

  /// <summary>
  ///   Начальная колонка.
  /// </summary>
  public int StartColumn { get; set; } = 1;

  /// <summary>
  ///   Сдвигать нижнюю часть при добавлении строки.
  /// </summary>
  public bool DownShift { get; set; } = false;
}