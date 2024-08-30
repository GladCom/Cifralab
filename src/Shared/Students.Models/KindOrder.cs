namespace Students.Models;

/// <summary>
/// Вид приказа
/// </summary>
public class KindOrder
{
    /// <summary>
    /// Id программы
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя программы
    /// </summary>
    public string Name { get; set; }
}