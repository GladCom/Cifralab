namespace Students.DB.Converter.Model;

/// <summary>
/// Данные о студенте и заявке полученные с Листа1.
/// </summary>
public class StudentWithRequest
{
  /// <summary>
  /// Имя.
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Отчество.
  /// </summary>
  public string? Patron { get; set; }

  /// <summary>
  /// Фамилия.
  /// </summary>
  public string? Family { get; set; }

  /// <summary>
  /// Дата рождения.
  /// </summary>
  public string? BirthDate { get; set; }

  /// <summary>
  /// Уровень образования (высшее, среднее..).
  /// </summary>
  public string? TypeEducation { get; set; }

  /// <summary>
  /// Опыт в IT.
  /// </summary>
  public string? ItExperience { get; set; }

  /// <summary>
  /// Место проживания.
  /// </summary>
  public string? Address { get; set; }

  /// <summary>
  /// Номер телефона.
  /// </summary>
  public string? Phone { get; set; }

  /// <summary>
  /// Электронный адрес.
  /// </summary>
  public string? Email { get; set; }

  /// <summary>
  /// Статус студента (обучается, отчислен...).
  /// </summary>
  public string? StudentStatus { get; set; }

  /// <summary>
  /// Заявка. Статус вступительного испытания
  /// </summary>
  public string? StatusEntranceExams { get; set; }

  /// <summary>
  /// Заявка. Статус заявки (Вступительное испытание, новая заявка, обучение...).
  /// </summary>
  public string? RequestStatus { get; set; }

  /// <summary>
  /// Заявка. Возраст на момент подачи заявки.
  /// </summary>
  public string? AgeCreateRequest { get; set; }

  /// <summary>
  /// Заявка. Дата подачи заявки.
  /// </summary>
  public string? DateCreateRequest { get; set; }

  /// <summary>
  /// Заявка. Дата и  Номер договора.
  /// </summary>
  public string? DataNumberDogovor { get; set; }

  /// <summary>
  /// Заявка. Регистрационный номер документа повышения квалификации.
  /// </summary>
  public string? DocumentRiseQualificationRegistrationNumber { get; set; }

  /// <summary>
  /// Студент. Пол студента.
  /// </summary>
  public string? Sex { get; set; }

  /// <summary>
  /// Студент. СНИЛС.
  /// </summary>
  public string? Snils { get; set; }

  /// <summary>
  /// Студент. Фамилия, указанная в дипломе о ВО или СПО
  /// </summary>
  public string? FullNameDocument { get; set; }

  /// <summary>
  /// Студент. Серия документа о ВО/СПО
  /// </summary>
  public string? DocumentSeries { get; set; }

  /// <summary>
  /// Студент. Номер документа о ВО/СПО
  /// </summary>
  public string? DocumentNumber { get; set; }

  /// <summary>
  /// Студент. Гражданство
  /// </summary>
  public string? Nationality { get; set; }

  /// <summary>
  /// Студент. Сфера деятельности(1 уровень).
  /// </summary>
  public string? ScopeOfActivityLevelOne { get; set; }

  /// <summary>
  /// Студент. Сфера деятельности(2 уровень).
  /// </summary>
  public string? ScopeOfActivityLevelTwo { get; set; }

  /// <summary>
  /// Студент. ОВЗ (инвалид)
  /// </summary>
  public string? Disability { get; set; }

  /// <summary>
  /// Программа обучения.
  /// </summary>
  public string? EducationProgram { get; set; }

  /// <summary>
  /// Программа обучения. Количество часов программы обучения.
  /// </summary>
  public string? HoursCount { get; set; }

  /// <summary>
  /// Программа обучения. Стоимость обучения.
  /// </summary>
  public string? Cost { get; set; }

  /// <summary>
  /// Программа обучения. Форма обучения.
  /// </summary>
  public string? EducationForm { get; set; }

  /// <summary>
  /// Программа обучения. Источник финансирования.
  /// </summary>
  public string? FinancingType { get; set; }

  /// <summary>
  /// Программа обучения. Сетевая форма.
  /// </summary>
  public string? IsNetworkProgram { get; set; }

  /// <summary>
  /// Программа обучения. Применение ДОТ.
  /// </summary>
  public string? IsDotProgram { get; set; }

  /// <summary>
  /// Программа обучения. Применение ДОТ полностью.
  /// </summary>
  public string? IsFullDotProgram { get; set; }

  /// <summary>
  /// Программа обучения. Модульная программа.
  /// </summary>
  public string? IsModularProgram { get; set; }

  /// <summary>
  /// Программа обучения. ВЭД программы.
  /// </summary>
  public string? FeaProgram { get; set; }

  /// <summary>
  /// Группа. Имя группы.
  /// </summary>
  public string? GroupName { get; set; }

  /// <summary>
  /// Группа. Начало обучения.
  /// </summary>
  public string? StartDate { get; set; }

  /// <summary>
  /// Группа. Конец обучения.
  /// </summary>
  public string? EndDate { get; set; }

  /// <summary>
  /// Приказ. Номер приказа + дата приказа о зачислении.
  /// </summary>
  public string? EnrollmentOrder { get; set; }

  /// <summary>
  /// Приказ. Номер приказа + дата приказа об отчислении.
  /// </summary>
  public string? ExpulsionOrder { get; set; }

  /// <summary>
  /// Документ повышения квалификации. Вид документа повышения квалификации.
  /// </summary>
  public string? DocumentRiseQualificationType { get; set; }

  /// <summary>
  /// Вид программы обучения.
  /// </summary>
  public string? KindEducationProgram { get; set; }

  /// <summary>
  /// Документ повышения квалификации. Дата выдачи удостоверения.
  /// </summary>
  public string? DocumentRiseQualificationDate { get; set; }

  /// <summary>
  /// Документ повышения квалификации. Номер выдачи удостоверения.
  /// </summary>
  public string? DocumentRiseQualificationNumber { get; set; }

  /// <summary>
  /// Основные данные.
  /// </summary>
  public string MainInfo => $"{this.Family} {this.Name} {this.Patron} {this.Phone}";

  /// <summary>
  /// Наименование квалификации, профессии, специальности
  /// </summary>
  public string? QualificationName { get; set; }
}