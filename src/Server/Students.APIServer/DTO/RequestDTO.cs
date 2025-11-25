using Students.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Students.APIServer.DTO;

/// <summary>
/// DTO Новой заявки с фронта.
/// </summary>
public class NewRequestDTO
{
    /// <summary>
    /// Адрес.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Адрес не может быть пустым")]
    [RegularExpression(@"^[А-Яа-яЁё0-9\s-.,/]+$", ErrorMessage = "Адрес проживания должен содержать только символы кириллицы и цифры")]
    public required string address { get; set; }
    /// <summary>
    /// Согласие на обработку персональных данных.
    /// </summary>
    public required bool agreement { get; set; }
    /// <summary>
    /// Дата рождения.
    /// </summary>
    public required DateOnly birthDate { get; set; }
    /// <summary>
    /// Идентификатор программы обучения.
    /// </summary>
    public required Guid educationProgramId { get; set; }
    /// <summary>
    /// Электронная почта.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email не может быть пустым")]
    [EmailAddress(ErrorMessage = "Email неверного формата")]
    public required string email { get; set; }
    /// <summary>
    /// Фамилия.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия не может быть пустой")]
    [RegularExpression(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$", ErrorMessage = "Фамилия должна содержать только символы кириллицы")]
    public required string family { get; set; }
    /// <summary>
    /// Опыт в ИТ.
    /// </summary>
    public required string iT_Experience { get; set; }
    /// <summary>
    /// Имя.
    /// </summary>
    [Required(AllowEmptyStrings =false, ErrorMessage = "Имя не может быть пустым")]
    [RegularExpression(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$", ErrorMessage = "Имя должно содержать только символы кириллицы")]
    public required string name { get; set; }
    /// <summary>
    /// Отчество.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Отчество не может быть пустым")]
    [RegularExpression(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$", ErrorMessage = "Отчество должно содержать только символы кириллицы")]
    public required string patron { get; set; }
    /// <summary>
    /// Телефон.
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Телефон не может быть пустым")]
    [RegularExpression(@"^(?=(?:\D*\d){11}\D*$)\+?\d[\d\-\s()]*$", ErrorMessage = "Неверный формат номера телефона")]
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
    public required int statusEntrancExams { get; set; }
    /// <summary>
    /// Обучающийся
    /// </summary>
    public bool? trained { get; set; } = false;
}

/// <summary>
/// DTO заявок на страницу заявок.
/// </summary>
public class RequestDTO
{
    /// <summary>
    /// ФИО.
    /// </summary>
    public required string StudentFullName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    [RegularExpression(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$", ErrorMessage = "Фамилия должна содержать только символы кириллицы")]
    public string? family { get; set; }
    /// <summary>
    /// Имя.
    /// </summary>
    [RegularExpression(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$", ErrorMessage = "Имя должно содержать только символы кириллицы")]
    public string? name { get; set; }
    /// <summary>
    /// Отчество.
    /// </summary>
    [RegularExpression(@"^[А-Яа-яЁё]+(-[А-Яа-яЁё]+)?$", ErrorMessage = "Отчество должно содержать только символы кириллицы")]
    public string? patron { get; set; }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Адрес, по-хорошему нужен либо справочник, либо формат стандарта ГОСТа Р 6.30-2003.
    /// экспорт из заявки
    /// </summary>
    [RegularExpression(@"^[А-Яа-яЁё0-9\s-]+$", ErrorMessage = "Адрес проживания должен содержать только символы кириллицы и цифры")]
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
    [EmailAddress(ErrorMessage = "Email неверного формата")]
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
    [RegularExpression(@"^(?=(?:\D*\d){11}\D*$)\+?\d[\d\-\s()]*$", ErrorMessage = "Неверный формат номера телефона")]
    public string? phone { get; set; }
    /// <summary>
    /// Ид сферы деятельности 1 уровень.
    /// </summary>
    public Guid? ScopeOfActivityLevelOneId { get; set; }
    /// <summary>
    /// Ид сферы деятельности 2 уровень.
    /// </summary>
    public Guid? ScopeOfActivityLevelTwoId { get; set; }
    /// <summary>
    /// Согласие на обработку данных.
    /// </summary>
    public bool agreement { get; set; }
    /// <summary>
    /// Возраст
    /// </summary>
    public int? Age { get; set; }
    /// <summary>
    /// Обучающийся
    /// </summary>
    public bool? trained { get; set; } = false;

    /// <summary>
    /// Дата создания заявки
    /// </summary>
    public DateTime DateOfCreate { get; set; }
}