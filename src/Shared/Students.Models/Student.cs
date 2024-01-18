using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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
    /// Заявки на обучение
    /// </summary>

    public List<Request>? Requests { get; set; }
    /// <summary>
    /// СНИЛС
    /// </summary>
    public string SNILS { get; set; }
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
    /// Гражданство
    /// </summary>
    public string? Nationality { get; set; }
    /// <summary>
    /// Группы
    /// </summary>

    public List<Group>? Groups { get; set; }
    public string Phone { get; set; }
    //public string PhonePrepeared { get { return Phone.Length > 10 ? Phone.Substring(Phone.Length - 10) : Phone; } }
    public string Email { get; set; }
	//public string EmailPrepeared { get { return Email.ToLower(); } }

    //Для таблицы Группы студентов для связи многие ко многим
	public virtual ICollection<GroupStudent>? GroupStudent { get; set; }

}
