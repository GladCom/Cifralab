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
    /// Сетевая форма
    /// </summary>
    public bool IsNetworkProgram { get; set; }
    /// <summary>
    /// Применение ДОТ
    /// </summary>
    public bool IsDOTProgram { get; set; }
    /// <summary>
    /// Применение ДОТ полностью
    /// </summary>
    public bool IsFullDOTProgram { get; set; }
    /// <summary>
    /// Студенты
    /// </summary>
    public List<Student>? Students { get; set; }

    //Для таблицы Группы персон для связи многие ко многим
    public virtual ICollection<GroupStudent>? GroupStudent { get; set; }
}