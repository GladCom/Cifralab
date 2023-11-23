namespace Students.APIServer.Extension.Pagination;

/// <summary>
/// Параметры постраничного вывода
/// </summary>
public interface IPageable
{
    /// <summary>
    /// Номер страницы, нумерация начинается с 0
    /// </summary>
    int PageNumber { get; }

    /// <summary>
    /// Размер страницы, должен быть больше 0
    /// </summary>
    int PageSize { get; }
}