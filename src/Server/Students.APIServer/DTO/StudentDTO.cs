using System.ComponentModel.DataAnnotations;

namespace Students.APIServer.DTO
{
  /// <summary>
  /// DTO студента.
  /// </summary>
  public class StudentDTO
  {
    /// <summary>
    /// Id студента
    /// </summary>
    public Guid StudentId { get; set; }

    /// <summary>
    /// Фамилия
    /// экспорт из заявки
    /// </summary>
    [Required]
    public required string StudentFamily { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string? StudentName { get; set; }

    /// <summary>
    /// Отчество
    /// экспорт из заявки
    /// </summary>
    public string? StudentPatron { get; set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public string StudentFullName { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly BirthDate { get; set; }

    /// <summary>
    /// МестоПроживания. Адрес, по хорошему нужен либо справочник, либо формат стандарта ГОСТа Р 6.30-2003
    /// экспорт из заявки
    /// </summary>
    [Required]
    public required string Address { get; set; }


    

    /// <summary>
    /// Id заявки
    /// </summary>
    public Guid? RequestId { get; set; }

    /// <summary>
    /// Идентификатор Статус заявки
    /// </summary>

    public Guid? StatusRequestId { get; set; }

    /// <summary>
    /// Статус заявки.
    /// </summary>
    public string? StatusRequestName { get; set; }

    /// <summary>
    /// Идентификатор программы обучения.
    /// </summary>
    public Guid? EducationProgramId { get; set; }

    /// <summary>
    /// Наименование программы.
    /// </summary>
    public string? ProgramName { get; set; }

    /// <summary>
    /// Id группы.
    /// </summary>
    public Guid? GroupId { get; set; }

    /// <summary>
    /// Имя группы.
    /// </summary>
    public string? GroupName { get; set; }

    /// <summary>
    /// Начало обучения.
    /// </summary>
    public DateOnly? GroupStartDate { get; set; }

    /// <summary>
    /// Конец обучения.
    /// </summary>
    public DateOnly? GroupEndDate { get; set; }
    
  }
}
