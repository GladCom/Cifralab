using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Students.Models.Enums;
using Students.Models.ReferenceModels;

namespace Students.Models;

/// <summary>
/// Заявка на обучение
/// </summary>
public class Request
{
  /// <summary>
  /// Id заявки, Как буд-то тут перебор необходимых данных
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Id Персона
  /// экспорт из заявки
  /// </summary>
  public Guid? StudentId { get; set; }

  /// <summary>
  ///  Id образовательной программы 
  /// </summary>
  public Guid? EducationProgramId { get; set; }

  /// <summary>
  /// Идентификатор Вида документа повышения квалификации
  /// </summary>
  public Guid? DocumentRiseQualificationId { get; set; }

  /// <summary>
  /// Дата и  Номер договора - че за нах это отдельная сущность или два реквизита в одной строке????
  /// </summary>
  public string? DataNumberDogovor { get; set; }

  /// <summary>
  /// Идентификатор Статус заявки
  /// </summary>

  public Guid? StatusRequestId { get; set; }

  /// <summary>
  /// Идентификатор статуса студента
  /// </summary>
  public Guid? StudentStatusId { get; set; }

  /// <summary>
  /// Статус вступительного испытания
  /// </summary>
  public StatusEntrancExams? StatusEntrancExams { get; set; }

  ///Вся ниже лежащая ересь похоже на реквизиты одного документа КАРЛ и похоже на документ повышения квалификации!!!

  /// <summary>
  /// Регистрационный номер
  /// </summary>
  public string? RegistrationNumber { get; set; }

  /// <summary>
  /// Уже проходил обучение.
  /// </summary>
  public bool? IsAlreadyStudied { get; set; }

  #region PotomuchtoMincifraNeOtdaetSNILS

  /// <summary>
  /// Валидированный E-mail.
  /// </summary>
  private string _email;

  /// <summary>
  /// E-mail
  /// </summary>
  public required string Email
  {
    get => _email;
    set
    {
      value = value.ToLower();
      if (Regex.IsMatch(value,@"^\s*[\w\-\+_']+(\.[\w\-\+_']+)*\@[A-Za-z0-9]([\w\.-]*[A-Za-z0-9])?\.[A-Za-z][A-Za-z\.]*[A-Za-z]$") && MailAddress.TryCreate(value, out var address))
        _email = address.Address;
      else
        throw new ValidationException("Not a valid Email address.");
    }
  }

  //public string EmailPrepeared { get { return Email.ToLower(); } }

  /// <summary>
  /// Валидированный телефон.
  /// </summary>
  private string _phone;

  /// <summary>
  /// Телефон
  /// </summary>
  public required string Phone
  {
    get => _phone;
    set
    {
      if(Regex.IsMatch(value, @"^\+7\s\(\d{3}\)\s\d{3}-\d{2}-\d{2}$"))
        _phone = value;
      else
        throw new ValidationException("Not a valid phone number.");
    }
  }

  #endregion PotomuchtoMincifraNeOtdaetSNILS

  /// <summary>
  /// Персона
  /// </summary>
  [JsonIgnore]
  public virtual Student? Student { get; set; }

  /// <summary>
  /// Образовательная программа
  /// </summary>
  [JsonIgnore]
  public virtual EducationProgram? EducationProgram { get; set; }

  /// <summary>
  /// Вид документа повышения квалификации
  /// </summary>
  [JsonIgnore]
  public virtual DocumentRiseQualification? DocumentRiseQualification { get; set; }

  /// <summary>
  /// Статус заявки
  /// </summary>
  [JsonIgnore]
  public virtual StatusRequest? Status { get; set; }

  /// <summary>
  /// Статус студента. Правильно было бы внести этот статус именно в класс студента
  /// Сам класс студента разделить на 2 класса - студент и персона.
  /// Персона содержала бы информацию о личных данных, без ссылок (просто справочник). Студент имел бы ссылку на Персону
  /// Сам студент был бы связан с заявкой
  /// </summary>
  [JsonIgnore]
  public virtual StudentStatus? StudentStatus { get; set; }

  /// <summary>
  /// Приказы
  /// </summary>
  [JsonIgnore]
  public virtual ICollection<Order>? Orders { get; set; }

  /// <summary>
  /// Согласие на обработу персональных данных
  /// </summary>
  public required bool Agreement { get; set; }
}
