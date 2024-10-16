using Students.Models.Enums;

namespace Students.APIServer.DTO;

/// <summary>
/// DTO Новой заявки с фронта.
/// </summary>
public class NewRequestDTO
{
  /// <summary>
  /// Адрес.
  /// </summary>
  public required string address { get; set; }
  /// <summary>
  /// Согласие на обработку персональных данных.
  /// </summary>
  public required bool agreement { get; set; }
  /// <summary>
  /// Дата рождения.
  /// </summary>
  public required string birthDate { get; set; }
  /// <summary>
  /// Идентификатор программы обучения.
  /// </summary>
  public required Guid educationProgramId { get; set; }
  /// <summary>
  /// Электронная почта.
  /// </summary>
  public required string email { get; set; }
  /// <summary>
  /// Фамилия.
  /// </summary>
  public required string family { get; set; }
  /// <summary>
  /// Опыт в ИТ.
  /// </summary>
  public required string iT_Experience { get; set; }
  /// <summary>
  /// Имя.
  /// </summary>
  public required string name { get; set; }
  /// <summary>
  /// Отчество.
  /// </summary>
  public required string patron { get; set; }
  /// <summary>
  /// Телефон.
  /// </summary>
  public required string phone { get; set; }
  /// <summary>
  /// Участие в проектах.
  /// </summary>
  public required string projects { get; set; }
  /// <summary>
  /// Область деятельности первого уровня.
  /// </summary>
  public required Guid scopeOfActivityLevelOneId { get; set; }
  /// <summary>
  /// Область деятельности второго уровня.
  /// </summary>
  public Guid? scopeOfActivityLevelTwoId { get; set; }
  /// <summary>
  /// Специальность.
  /// </summary>
  public required string speciality { get; set; }
  /// <summary>
  /// Идентификатор статуса заявки.
  /// </summary>
  public Guid statusRequestId { get; set; }
  /// <summary>
  /// Идентификатор типа/уровня образования.
  /// </summary>
  public required Guid typeEducationId { get; set; }
  /// <summary>
  /// Статус сзади вступительного экзамена.
  /// </summary>
  public required int statusEntranceExams { get; set; }
}

/// <summary>
/// DTO заявок на страницу заявок.
/// </summary>
public class RequestsDTO
{
  /// <summary>
  /// ФИО.
  /// </summary>
  public required string StudentFullName { get; set; }

  /// <summary>
  /// Фамилия.
  /// </summary>
  public string? family { get; set; }
  /// <summary>
  /// Имя.
  /// </summary>
  public string? name { get; set; }
  /// <summary>
  /// Отчество.
  /// </summary>
  public string? patron { get; set; }

  /// <summary>
  /// Дата рождения.
  /// </summary>
  public DateOnly? BirthDate { get; set; }

  /// <summary>
  /// Адрес, по-хорошему нужен либо справочник, либо формат стандарта ГОСТа Р 6.30-2003.
  /// экспорт из заявки
  /// </summary>
  public string? Address { get; set; }

  /// <summary>
  /// Уровень образования
  /// экспорт из заявки, хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО.
  /// </summary>
  public string? TypeEducation { get; set; }

  /// <summary>
  /// Уровень образования
  /// экспорт из заявки, хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО.
  /// </summary>
  public Guid? TypeEducationId { get; set; }

  /// <summary>
  /// Электронный адрес
  /// экспорт из заявки.
  /// </summary>
  public string? Email { get; set; }

  /// <summary>
  /// Id заявки, Как буд-то тут перебор необходимых данных.
  /// </summary>
  public Guid? Id { get; set; }

  /// <summary>
  /// Id Персона
  /// экспорт из заявки.
  /// </summary>
  public Guid? StudentId { get; set; }

  /// <summary>
  ///  Id образовательной программы.
  /// </summary>
  public Guid? EducationProgramId { get; set; }
  /// <summary>
  /// Образовательная программа.
  /// </summary>
  public string? EducationProgram { get; set; }

  /// <summary>
  /// Статус заявки.
  /// </summary>
  public string? StatusRequest { get; set; }

  /// <summary>
  /// Идентификатор статуса студента.
  /// </summary>
  public Guid? StatusRequestId { get; set; }

  /// <summary>
  /// Опыт в ИТ.
  /// </summary>
  public string? IT_Experience { get; set; }
  /// <summary>
  /// Специальность.
  /// </summary>
  public string? speciality { get; set; }
  /// <summary>
  /// Проекты.
  /// </summary>
  public string? projects { get; set; }
  /// <summary>
  /// Состояние сдачи экзамена.
  /// </summary>
  public StatusEntrancExams statusEntrancExams { get; set; }
  //public string age { get; set; }
  /// <summary>
  /// Телефон.
  /// </summary>
  public string? phone { get; set; }
  /// <summary>
  /// Ид сферы деятельности 1 уровень.
  /// </summary>
  public Guid ScopeOfActivityLevelOneId { get; set; }
  /// <summary>
  /// Ид сферы деятельности 2 уровень.
  /// </summary>
  public Guid? ScopeOfActivityLevelTwoId { get; set; }
  /// <summary>
  /// Согласие на обработку данных.
  /// </summary>
  public bool agreement { get; set; }
}