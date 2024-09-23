namespace Students.Models;

/// <summary>
/// статусы заявок
/// </summary>
public class StatusRequest
{
    /// <summary>
    /// Id статуса
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Имя статуса
    /// </summary>
    public string? Name { get; set; }
}
