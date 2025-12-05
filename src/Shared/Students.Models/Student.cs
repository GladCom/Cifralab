using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Students.Models.Enums;
using Students.Models.ReferenceModels;

namespace Students.Models;

/// <summary>
/// Студент (в модели это персона)
/// </summary>
public class Student
{
  /// <summary>
  /// Id студента
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Фамилия
  /// экспорт из заявки
  /// </summary>
  public required string Surname { get; set; }

  /// <summary>
  /// Имя
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Отчество
  /// экспорт из заявки
  /// </summary>
  public string? Patron { get; set; }

  /// <summary>
  /// ФИО
  /// экспорт из заявки
  /// </summary>
  //Возможно нужна стратегия отображения ФИО, но тогда через конструктор
  public string FullName => $"{this.Surname} {this.Name} {this.Patron}";

  /// <summary>
  /// Дата рождения
  /// </summary>
  public required DateOnly BirthDate { get; set; }

  /// <summary>
  /// Возраст
  /// </summary>
  public int Age
  {
    get
    {
      var age = DateTime.Now.Year - this.BirthDate.Year;
      //День рождения еще не наступил
      if(DateTime.Now.DayOfYear < this.BirthDate.DayOfYear)
      {
        age--;
      }
      return age;
    }
  }

  /// <summary>
  /// Пол
  /// Справочник
  /// </summary>
  public required SexHuman Sex { get; set; }

  /// <summary>
  /// Адрес, по-хорошему нужен либо справочник, либо формат стандарта ГОСТа Р 6.30-2003
  /// экспорт из заявки
  /// </summary>
  public required string Address { get; set; }

  /// <summary>
  /// Валидированный телефон.
  /// </summary>
  private string _phone;

  //список полей для связи, вероятно нужно в отдельную таблицу
  /// <summary>
  /// Телефон
  /// экспорт из заявки
  /// </summary>
  public required string Phone
  {
    get => this._phone;
    set
    {
      if(Regex.IsMatch(value, @"^\+7\s\(\d{3}\)\s\d{3}-\d{2}-\d{2}$"))
        this._phone = value;
      else
        throw new ValidationException("Not a valid phone number.");
    }
  }

  /// <summary>
  /// Валидированный электронный адрес.
  /// </summary>
  private string _email;

  //public string PhonePrepared { get { return Phone.Length > 10 ? Phone.Substring(Phone.Length - 10) : Phone; } }
  /// <summary>
  /// Электронный адрес
  /// экспорт из заявки
  /// </summary>
  public required string Email
  {
    get => this._email;
    set
    {
      value = value.ToLower();
      if(Regex.IsMatch(value, @"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$") && MailAddress.TryCreate(value, out var address))
        this._email = address.Address;
      else
        throw new ValidationException("Not a valid Email address.");
    }
  }

  /// <summary>
  /// Опыт в ИТ
  /// экспорт из заявки
  /// </summary>
  public string? IT_Experience { get; set; }

  /// <summary>
  /// Ид Уровень образования
  /// экспорт из заявки, хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО
  /// </summary>
  public Guid? TypeEducationId { get; set; }

  /// <summary>
  /// Id сферы деятельности(1 уровень).
  /// </summary>
  public required Guid ScopeOfActivityLevelOneId { get; set; }

  /// <summary>
  /// Id сферы деятельности(2 уровень).
  /// </summary>
  public Guid? ScopeOfActivityLevelTwoId { get; set; }

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
  /// Уровень образования
  /// экспорт из заявки, хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО
  /// </summary>
  [JsonIgnore]
  public virtual TypeEducation? TypeEducation { get; set; }

  /// <summary>
  /// Сфера деятельности, уже есть как бы класс сфера деятельности с уровнями
  /// Хоть и список, но по факту должен содержать только 2 значения (1 уровень и второй???)
  /// </summary>
  [JsonIgnore]
  public virtual ScopeOfActivity? ScopeOfActivityLevelOne { get; set; }

  /// <summary>
  /// Сфера деятельности, уже есть как бы класс сфера деятельности с уровнями
  /// Хоть и список, но по факту должен содержать только 2 значения (1 уровень и второй???)
  /// </summary>
  [JsonIgnore]
  public virtual ScopeOfActivity? ScopeOfActivityLevelTwo { get; set; }

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
