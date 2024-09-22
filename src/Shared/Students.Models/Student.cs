using System.ComponentModel.DataAnnotations;

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
    [Required]
    public required string Family { get; set; }
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
    public string FullName => $"{Family} {Name} {Patron}";
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly BirthDate { get; set; }
    /// <summary>
    /// Возраст
    /// </summary>
    public int Age
    {
        get
        {
            var age = DateTime.Now.Year - BirthDate.Year;
            //День рождения еще не наступил
            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
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
    public SexHuman Sex { get; set; }
    /// <summary>
    /// Гражданство
    /// </summary>
    public string? Nationality { get; set; }

    //список полей вероятно кочующих в таблицу документы
    /// <summary>
    /// СНИЛС
    /// </summary>
    public string? SNILS { get; set; }

    /// <summary>
    /// Адрес, по хорошему нужен либо справочник, либо формат стандарта ГОСТа Р 6.30-2003
    /// экспорт из заявки
    /// </summary>
    [Required]
    public required string Address { get; set; }


    //список полей для связи, вероятно нужно в отдельную таблицу
    /// <summary>
    /// Телефон
    /// экспорт из заявки
    /// </summary>
    [Required]
    public required string Phone { get; set; }
    //public string PhonePrepeared { get { return Phone.Length > 10 ? Phone.Substring(Phone.Length - 10) : Phone; } }
    /// <summary>
    /// Электронный адрес
    /// экспорт из заявки
    /// </summary>
    [Required]
    public required string Email { get; set; }

    /// <summary>
    /// Проекты
    /// экспорт из заявки
    /// </summary>
    public string? Projects { get; set; }

    /// <summary>
    /// опыт в ИТ
    /// экспорт из заявки
    /// </summary>
    [Required]
    public required string IT_Experience { get; set; }

    /// <summary>
    /// ОВЗ (инвалид)
    /// Справочник
    /// </summary>
    public bool? Disability { get; set; }
    /// <summary>
    /// Ид Уровень образования
    /// экспорт из заявки,хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО
    /// </summary>
    public Guid? TypeEducationId { get; set; }
    /// <summary>
    /// Уровень образования
    /// экспорт из заявки,хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО
    /// </summary>
    public TypeEducation? TypeEducation { get; set; }
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
    /// Сфера деятельности, уже есть как бы класс сфера деятельности с уровнями
    /// Хоть и список, но по факту должен содержать только 2 значения (1 уровень и второй???)
    /// </summary>
    public ScopeOfActivity? ScopeOfActivityLevelOne { get; set; }

    /// <summary>
    /// Сфера деятельности, уже есть как бы класс сфера деятельности с уровнями
    /// Хоть и список, но по факту должен содержать только 2 значения (1 уровень и второй???)
    /// </summary>
    public ScopeOfActivity? ScopeOfActivityLevelTwo { get; set; }
    
    /// <summary>
    /// Группы
    /// Многие ко многим (мапирование через третью таблицу GroupPerson)
    /// </summary>
    public List<Group>? Groups { get; set; }
    
	//public string EmailPrepeared { get { return Email.ToLower(); } }

    //Для таблицы Группы Персон для связи многие ко многим (по сути виртуальная сущность - 
    //промежуток между группой обучения и персоной)
    /// <summary>
    /// Свойство связки один ко многим
    /// </summary>
	public virtual ICollection<GroupStudent>? GroupStudent { get; set; }

    /// <summary>
    /// Заявки на обучение
    /// </summary>
    public List<Request>? Requests { get; set; }
}
