using Students.Models.Enums;

namespace Students.Models.Filters.Filters;

/// <summary>
/// Фильтр заявок.
/// </summary>
public class RequestFilter : Filter<Request>
{
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
  /// Идентификатор уровня образования.
  /// </summary>
  public Guid? TypeEducationId { get; set; }

  /// <summary>
  /// Статус вступительного испытания
  /// </summary>
  public int? StatusEntranceExam { get; set; }

  /// <summary>
  /// Регистрационный номер
  /// </summary>
  public string? RegistrationNumber { get; set; }

  /// <summary>
  /// E-mail
  /// </summary>
  public string? Email { get; set; }

  /// <summary>
  /// Телефон
  /// </summary>
  public string? Phone { get; set; }

  /// <summary>
  /// Согласие на обработу персональных данных
  /// </summary>
  public bool? Agreement { get; set; }

  /// <summary>
  /// Предикат по которому осуществляется фильтрация.
  /// </summary>
  /// <returns>Предикат.</returns>
  public override Predicate<Request> GetFilterPredicate()
  {
    return x =>
        (!this.Id.HasValue || x.Id == this.Id) &&
        (!this.StudentId.HasValue || x.StudentId == this.StudentId) &&
        (!this.EducationProgramId.HasValue || x.EducationProgramId == this.EducationProgramId) &&
        (!this.DocumentRiseQualificationId.HasValue || x.DocumentRiseQualificationId == this.DocumentRiseQualificationId) &&
        (string.IsNullOrEmpty(this.DataNumberDogovor) || x.DataNumberDogovor == this.DataNumberDogovor) &&
        (!this.StatusRequestId.HasValue || x.StatusRequestId == this.StatusRequestId) &&
        (!this.StudentStatusId.HasValue || x.StudentStatusId == this.StudentStatusId) &&
        (!this.TypeEducationId.HasValue ||
          (x.Student is not null && x.Student.TypeEducationId == this.TypeEducationId) ||
          (x.PhantomStudent is not null && x.PhantomStudent.TypeEducationId == this.TypeEducationId)) &&
        (!this.StatusEntranceExam.HasValue || StatusEntranceExam == (int)x.StatusEntrancExams) &&
        (string.IsNullOrEmpty(this.RegistrationNumber) || x.RegistrationNumber == this.RegistrationNumber) &&
        (string.IsNullOrEmpty(this.Email) || x.Email == this.Email) &&
        (string.IsNullOrEmpty(this.Phone) || x.Phone == this.Phone) &&
        (!this.Agreement.HasValue || x.Agreement == this.Agreement);
  }
}
