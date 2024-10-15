using System.Text.Json.Serialization;
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

  #region PotomuchtoMincifraNeOtdaetSNILS

  /// <summary>
  /// E-mail
  /// </summary>
  public required string Email { get; set; }

  //public string EmailPrepeared { get { return Email.ToLower(); } }
  /// <summary>
  /// Телефон
  /// </summary>
  public required string Phone { get; set; }

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
