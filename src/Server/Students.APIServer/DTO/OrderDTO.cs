using Students.Models;
using Students.Models.ReferenceModels;

namespace Students.APIServer.DTO
{
  /// <summary>
  /// DTO приказа.
  /// </summary>
  public class OrderDTO
  {
    /// <summary>
    /// Id приказа.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Номер приказа.
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// Дата приказа.
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Вид приказа.
    /// </summary>
    public string? KindOrderName { get; set; }

    /// <summary>
    /// Группа.
    /// </summary>
    public IEnumerable<Group>? Groups { get; set; }

    /// <summary>
    /// Студент.
    /// </summary>
    public string? StudentName { get; set; }

  }
}
