namespace Students.Models;

/// <summary>
/// Вид приказа
/// По хорошему это можно вынести в базовый дженерик класс Справочник и наследовать от него не плодя свойства одни и те же (кому-то предать на доработку)
/// </summary>
public class KindOrder
{
  /// <summary>
  /// Id программы
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Имя программы
  /// </summary>
  public string? Name { get; set; }
}