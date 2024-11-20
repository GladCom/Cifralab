using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Students.Models;

/// <summary>
/// Студент (в модели это персона)
/// </summary>
public class Student : PhantomStudent
{
  /// <summary>
  /// Гражданство
  /// </summary>
  public string? Nationality { get; set; }

  //список полей вероятно кочующих в таблицу документы

  /// <summary>
  /// Валидированный СНИЛС.
  /// </summary>
  private string? _sNILS;

  /// <summary>
  /// СНИЛС
  /// </summary>
  public string? SNILS
  {
    get => this._sNILS;
    set
    {
      if(value != null)
      {
        if(Regex.IsMatch(value, @"^\d{3}-\d{3}-\d{3} \d{2}$"))
          this._sNILS = value;
        else
          throw new ValidationException("Not a valid SNILS.");
      }
      else
      {
        this._sNILS = null;
      }
    }
  }

  /// <summary>
  /// Проекты
  /// экспорт из заявки
  /// </summary>
  public string? Projects { get; set; }

  /// <summary>
  /// ОВЗ (инвалид)
  /// Справочник
  /// </summary>
  public bool? Disability { get; set; }

  /// <summary>
  /// Специальность
  /// </summary>
  public string? Speciality { get; set; }

  //тут по хорошему тоже отдельный документ должен быть
  /// <summary>
  /// Фамилия, указанная в дипломе о ВО или СПО
  /// </summary>
  public string? FullNameDocument { get; set; }

  /// <summary>
  /// Серия документа о ВО/СПО
  /// </summary>
  public string? DocumentSeries { get; set; }

  /// <summary>
  /// Номер документа о ВО/СПО
  /// </summary>
  public string? DocumentNumber { get; set; }

  /// <summary>
  /// Дата получения диплома
  /// </summary>
  public DateTime? DateTakeDiplom { get; set; }

  /// <summary>
  /// Группы
  /// Многие ко многим (мапирование через третью таблицу GroupPerson)
  /// </summary>
  //[JsonIgnore]
  public virtual ICollection<Group>? Groups { get; set; }

  //public string EmailPrepared { get { return Email.ToLower(); } }

  //Для таблицы Группы Персон для связи многие ко многим (по сути виртуальная сущность - 
  //промежуток между группой обучения и персоной)
  /// <summary>
  /// Свойство связки один ко многим
  /// </summary>
  [JsonIgnore]
  public virtual ICollection<GroupStudent>? GroupStudent { get; set; }

  /// <summary>
  /// Заявки на обучение
  /// </summary>
  //[JsonIgnore]
  public virtual ICollection<Request>? Requests { get; set; }
}
