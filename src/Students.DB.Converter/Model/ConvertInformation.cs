namespace Students.DB.Converter.Model;

/// <summary>
/// Сообщение о пройденной/непройденной конвертации данных.
/// </summary>
public class ConvertInformation
{
  #region Поля и свойства

  /// <summary>
  /// Время записи.
  /// </summary>
  public DateTime Datetime { get; set; }

  /// <summary>
  /// Признак ошибки (true, если произошла ошибка при записи информации в БД).
  /// </summary>
  public bool IsError { get; set; }

  /// <summary>
  /// Признак ошибки.
  /// </summary>
  public string IsErrorText => this.IsError ? "Ошибка" : string.Empty;

  /// <summary>
  /// Время записи.
  /// </summary>
  public string Time => this.Datetime.ToShortTimeString();

  /// <summary>
  /// Сообщение.
  /// </summary>
  public string Message { get; set; }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="isError">Признак ошибки.</param>
  /// <param name="message">Сообщение.</param>
  public ConvertInformation(bool isError, string message)
  {
    this.IsError = isError;
    this.Message = message;
    this.Datetime = DateTime.Now;
  }

  #endregion
}