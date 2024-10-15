namespace Students.Models.ReferenceModels;

/// <summary>
/// ВЭД программа.
/// </summary>
public class FEAProgram
{
    /// <summary>
    /// Идентификатор ВЭД.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя ВЭД.
    /// </summary>
    public string? Name { get; set; }
}