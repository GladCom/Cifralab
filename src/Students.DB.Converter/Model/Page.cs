namespace Students.DB.Converter.Model;

/// <summary>
/// Лист из Excel.
/// </summary>
public class Page
{
  #region Поля и свойства

  /// <summary>
  /// Номер листа.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Имя листа.
  /// </summary>
  public string Name { get; set; }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="id">Номер страницы.</param>
  /// <param name="name">Имя страницы.</param>
  public Page(int id, string name)
  {
    this.Id = id;
    this.Name = name;
  }

  #endregion
}