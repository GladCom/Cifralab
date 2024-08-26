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
    /// Id заявки, Как буд-то тут перебор необходимых данных
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    /// <summary>
    /// Id Персона
    /// экспорт из заявки
    /// </summary>
    public Guid? PersonId { get; set; }
    /// <summary>
    /// Персона
    /// </summary>
    [JsonIgnore]
    public Person? Person { get; set; }

    /// <summary>
    ///  Id образовательной программы 
    /// </summary>
    //(в соответсвии с моделью  - это фиксированный список, но уже сделан справочник и это хорошо)
    public Guid EducationProgramId { get; set; }
    /// <summary>
    /// Образовательная программа
    /// </summary>
    [JsonIgnore]
    public EducationProgram? EducationProgram { get; set; }

    /// <summary>
    /// Вид документа повышения квалификации для него сделать пеерчисление или классический справочник
    /// </summary>
    public KindDocumentRiseQualification? KindDocumentRiseQualification { get; set; }

    /// <summary>
    /// lдата и  Номер договора - че за нах это отдельная сущность или два реквизита в одной строке????
    /// </summary>
    public string DataNumberDogovor { get; set; }

    /// <summary>
    /// Статус заявки
    /// </summary>
    public StatusRequest Status { get; set; }

    /// <summary>
    /// Статус вступительного испытания
    /// </summary>
    public StatusEntrancExams StatusEntrancExams { get; set; }

    /// <summary>
    /// Приказы
    /// Приказы нужно делать
    /// </summary>
    public List<Order> Orders { get; set; }

    ///Вся ниже лежащая ересь похоже на реквизиты одного документа КАРЛ!!!
    /// <summary>
    /// Дата выдачи удостоверения назовите это нормально
    /// </summary>
    public DateTime DateTakeUdostoverenie { get; set; }

    /// <summary>
    /// Номер выдачи удостоверения назовите это нормально
    /// </summary>
    public DateTime NumberTakeUdostoverenie { get; set; }

    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string RegistrationNumber


    /* вот это вот все реквизиты картоки персоны, 
       хз не понятно зачем это проксируется сюда, как буд-то это уже DTO с объединеением внутренних данных
        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateOnly BirthDate { get; set; }

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

        Приказ это отдельная сущность и ее сейчас нет
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
        */
}
