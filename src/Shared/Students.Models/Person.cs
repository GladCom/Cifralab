using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Students.Models;

/// <summary>
/// Пол человека
/// </summary>
public enum SexHuman
{
    Men,
    Woman
}

/// <summary>
/// Студент (в модели это персона)
/// </summary>
public class Person
{
    /// <summary>
    /// Id студента
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// Фамилия
    /// экспорт из заявки
    /// </summary>
    public string Family { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Отчество
    /// экспорт из заявки
    /// </summary>
    public string Patron { get; set; }
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
    public DateOnly Age => DateTime.Now - BirthDate;
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
    public string SNILS { get; set; }

    /// <summary>
    /// Адрес, по хорошему нужен либо справочник, либо формат стандарта ГОСТа Р 6.30-2003
    /// экспорт из заявки
    /// </summary>
    public string Address { get; set; }


    //список полей для связи, вероятно нужно в отдельную таблицу
    /// <summary>
    /// Телефон
    /// экспорт из заявки
    /// </summary>
    public string Phone { get; set; }
    //public string PhonePrepeared { get { return Phone.Length > 10 ? Phone.Substring(Phone.Length - 10) : Phone; } }
    /// <summary>
    /// Электронный адрес
    /// экспорт из заявки
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Проекты
    /// экспорт из заявки
    /// </summary>
    public string Projects { get; set; }

    /// <summary>
    /// Проекты
    /// экспорт из заявки
    /// </summary>
    public string IT_Experience { get; set; }

    /// </summary>
    /// ОВЗ (инвалид)
    /// Справочник
    /// </summary>
    public bool? Disability { get; set; }

    //Поля блока образования, вероятно, если заморачиваться, тоже скинуть в отдельную таблицу
    /// <summary>
    /// Уровень образования
    /// экспорт из заявки,хотя по факту тут тоже некий справочник Высшее образование / Среднее профессиональное образование / Студент ВО / Студент СПО
    /// </summary>
    public string? EducationLevel { get; set; }
    /// <summary>
    /// Специальность
    /// </summary>
    public string? Speciality { get; set; }
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
    punlic Datetime DateTakeDiplom { get; set; }

    /// <summary>
    /// Сфера деятельности, уже есть как бы класс сфера деятельности с уровнями
    /// Хоть и список, но по факту должен содержать только 2 значения (1 уровень и второй???)
    /// </summary>
    public ScopeOfActivity ScopeOfActivityLevelOne { get; set; }

    /// <summary>
    /// Сфера деятельности, уже есть как бы класс сфера деятельности с уровнями
    /// Хоть и список, но по факту должен содержать только 2 значения (1 уровень и второй???)
    /// </summary>
    public ScopeOfActivity ScopeOfActivityLevelTwo { get; set; }
    
    /// <summary>
    /// Группы
    /// Многие ко многим (мапирование через третью таблицу GroupPerson)
    /// </summary>
    public List<Group>? Groups { get; set; }
    
	//public string EmailPrepeared { get { return Email.ToLower(); } }

    //Для таблицы Группы Персон для связи многие ко многим (по сути виртуальная сущность - 
    //промежуток между группой обучения и персоной)
	public virtual ICollection<Group>? GroupPerson { get; set; }

    /// <summary>
    /// Заявки на обучение
    /// </summary>
    public List<Request>? Requests { get; set; }
}
