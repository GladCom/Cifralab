using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace Students.Models;

/// <summary>
/// Заявка на обучение
/// </summary>
public class Request
{
    /// <summary>
    /// Id заявки
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    ///  Id образовательной программы
    /// </summary>
    public Guid EducationProgramId { get; set; }
    /// <summary>
    /// Образовательная программа
    /// </summary>
    [JsonIgnore]
    public EducationProgram? EducationProgram { get; set; }
    /// <summary>
    /// Информация о прохождении вступительного испытания
    /// </summary>
    public string? EntranceExamination { get; set; }
    /// <summary>
    /// Информация о прохождении собеседования
    /// </summary>
    public string? Interview { get; set; }
    /// <summary>
    /// E-mail
    /// </summary>
    public string Email { get; set; }
    //public string EmailPrepeared { get { return Email.ToLower(); } }
    /// <summary>
    /// Телефон
    /// </summary>
    public string Phone { get; set; }
    //public string PhonePrepeared { get { return Phone.Length > 10 ? Phone.Substring(Phone.Length - 10) : Phone; } }
    /// <summary>
    /// Дата и время подачи заявки
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    ///Id Образования
    /// </summary>
    public Guid? StudentEducationId { get; set; }
    /// <summary>
    /// Образование
    /// </summary>
    [JsonIgnore]
    public StudentEducation? StudentEducation { get; set; }
    /// <summary>
    ///Id Статуса
    /// </summary>
    public Guid? StudentStatusId { get; set; }
    /// <summary>
    /// Статус
    /// </summary>
    [JsonIgnore]
    public StudentStatus? StudentStatus { get; set; }
    /// <summary>
    ///Id Источника финансирования
    /// </summary>
    public Guid? FinancingTypeId { get; set; }
    /// <summary>
    /// Источник финансирования
    /// </summary>
    [JsonIgnore]
    public FinancingType? FinancingType { get; set; }
    /// <summary>
    /// Приказ о зачислении
    /// </summary>
    public string? OrderOfAdmission { get; set; }
    /// <summary>
    /// Приказ об отчислении
    /// </summary>
    public string? OrderOfExpulsion { get; set; }
    /// <summary>
    ///Id Сферы деятельности ур. 1
    /// </summary>
    public Guid? ScopeOfActivityLv1Id { get; set; }
    /// <summary>
    /// Сфера деятельности ур. 1
    /// </summary>
    [JsonIgnore]
    public ScopeOfActivity? ScopeOfActivityLv1 { get; set; }
    /// <summary>
    ///Id Сферы деятельности ур. 2
    /// </summary>
    public Guid? ScopeOfActivityLv2Id { get; set; }
    /// <summary>
    /// Сфера деятельности ур. 2 
    /// </summary>
    [JsonIgnore]
    public ScopeOfActivity? ScopeOfActivityLv2 { get; set; }
    /// <summary>
    /// ОВЗ (Инвалидность)
    /// </summary>
    public bool? Disability { get; set; }
    /// <summary>
    /// Информация о трудоустройстве после окончания обучения
    /// </summary>
    public string? JobResult { get; set; }
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
    /// Номер и дата договора об обучении
    /// </summary>
    public string? EducationContract { get; set; }
    /// <summary>
    /// Id вида документа
    /// </summary>
    public Guid? DocumentTypeId { get; set; }
    /// <summary>
    /// Вид выданного документа о квалификации
    /// </summary>
    [JsonIgnore]
    public StudentDocument? DocumentType { get; set; }
    /// <summary>
    /// Id студента
    /// </summary>
    public Guid? StudentId { get; set; }
    /// <summary>
    /// Cтудент
    /// </summary>
    [JsonIgnore]
    public Student? Student { get; set; }
}
