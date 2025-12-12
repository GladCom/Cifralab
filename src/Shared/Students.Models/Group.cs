using System.Text.Json.Serialization;

namespace Students.Models;

/// <summary>
/// Группа обучения.
/// </summary>
public class Group
{
  /// <summary>
  /// Id группы.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Имя группы.
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Id образовательной программы.
  /// </summary>
  public required Guid EducationProgramId { get; set; }

  /// <summary>
  /// Начало обучения.
  /// </summary>
  public required DateOnly StartDate { get; set; }

  /// <summary>
  /// Конец обучения.
  /// </summary>
  public required DateOnly EndDate { get; set; }

  /// <summary>
  /// Образовательная программа.
  /// </summary>
  [JsonIgnore]
  public virtual EducationProgram? EducationProgram { get; set; }

  /// <summary>
  /// Студенты.
  /// </summary>
  public virtual ICollection<Student> Students { get; set; } = new List<Student>();

  //Для таблицы Группы персон для связи многие ко многим.
  /// <summary>
  /// Свойство связка многие ко многим.
  /// </summary>
  [JsonIgnore] 
  public virtual ICollection<GroupStudent> GroupStudent { get; set; } = new List<GroupStudent>();
}