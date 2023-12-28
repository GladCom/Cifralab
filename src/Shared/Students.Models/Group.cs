using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Students.Models;

/// <summary>
/// Группа обучения
/// </summary>
public class Group
{
    /// <summary>
    /// Id группы
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя группы
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Id образовательной программы
    /// </summary>
    public Guid EducationProgramId { get; set; }
    /// <summary>
    /// Образорвательная программа
    /// </summary>
    [JsonIgnore]
    public EducationProgram? EducationProgram { get; set; }
    /// <summary>
    /// Начало обучения
    /// </summary>
    public DateOnly StartDate { get; set; }
    /// <summary>
    /// Конец обучения
    /// </summary>
    public DateOnly EndDate { get; set; }
    /// <summary>
    /// Студенты
    /// </summary>
    public List<Student>? Students { get; set; }

	//Для таблицы Группы студентов для связи многие ко многим
	public virtual ICollection<GroupStudent>? GroupStudent { get; set; }
}