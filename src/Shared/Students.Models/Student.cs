using System.Text.RegularExpressions;

namespace Students.Models;
/// <summary>
/// Студент
/// </summary>
public class Student
{
    /// <summary>
    /// Id студента
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// ФИО
    /// </summary>
    public string FullName { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly BirthDate { get; set; }
    /// <summary>
    /// Заявки на обучение
    /// </summary>
    public List<Request> Requests { get; set; }
    /// <summary>
    /// СНИЛС
    /// </summary>
    public string SNILS { get; set; }
    /// <summary>
    /// Образование
    /// </summary>
    public StudentEducation StudentEducation { get; set; }
    /// <summary>
    /// Статус
    /// </summary>
    public StudentStatus StudentStatus { get; set; }
    /// <summary>
    /// Направление подготовки / специальность
    /// </summary>
    public string Speciality { get; set; }
    /// <summary>
    /// Опыт в IT
    /// </summary>
    public string JobCV { get; set; }
    /// <summary>
    /// Место проживания
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// E-mail
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// Фамилия, указанная в дипломе о ВО или СПО
    /// </summary>
    public string FullNameDocument { get; set; }
    /// <summary>
    /// Вид выданного документа о квалификации
    /// </summary>
    public StudentDocument DocumentType { get; set; }
    /// <summary>
    /// Серия документа о ВО/СПО
    /// </summary>
    public string DocumentSeries { get; set; }
    /// <summary>
    /// Номер документа о ВО/СПО
    /// </summary>
    public string DocumentNumber { get; set; }
    /// <summary>
    /// Гражданство
    /// </summary>
    public string Nationality { get; set; }
    /// <summary>
    /// Источник финансирования
    /// </summary>
    public FinancingType FinancingType { get; set; }
    /// <summary>
    /// Номер и дата договора об обучении
    /// </summary>
    public string EducationContract { get; set; }
    /// <summary>
    /// Группы
    /// </summary>
    public List<Group> Groups { get; set; }
    /// <summary>
    /// Приказ о зачислении
    /// </summary>
    public string OrderOfAdmission { get; set; }
    /// <summary>
    /// Приказ об отчислении
    /// </summary>
    public string OrderOfExpulsion { get; set; }
    /// <summary>
    /// Сфера деятельности ур. 1
    /// </summary>
    public ScopeOfActivity ScopeOfActivityLv1 { get; set; }
    /// <summary>
    /// Сфера деятельности ур. 2 
    /// </summary>
    public ScopeOfActivity ScopeOfActivityLv2 { get; set; }
    /// <summary>
    /// ОВЗ (Инвалидность)
    /// </summary>
    public bool Disability { get; set; }
    /// <summary>
    /// Информация о трудоустройстве после окончания обучения
    /// </summary>
    public string JobResult { get; set; }
}