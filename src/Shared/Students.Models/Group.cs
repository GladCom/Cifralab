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

    //не хватает сетевой формы и ДОТ которые частично определены в образовательной программе
    //По данным предыдущей комманды и текущий модели есть повторяемость данных для разных
    //сущнотей как буд-то это декорирование свойств наружу от внутренних элементов

    /// <summary>
    /// Студенты
    /// </summary>
    public List<Person>? Persons { get; set; }

    //Для таблицы Группы персон для связи многие ко многим
    public virtual ICollection<GroupPerson>? GroupPerson { get; set; }
}