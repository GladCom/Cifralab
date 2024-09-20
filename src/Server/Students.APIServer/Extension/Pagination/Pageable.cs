using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Students.APIServer.Extension.Pagination;

/// <summary>
/// Параметры постраничного вывода
/// </summary>
public class Pageable
{
    const int maxPageSize = 50;
    private int _pageSize = 10;
    /// <summary>
    /// Номер страницы, нумерация начинается с 1
    /// </summary>
    [FromQuery(Name = "page")]
    [Range(1, int.MaxValue, ErrorMessage = "Укажите значение больше чем {1}")]
    public int PageNumber { get; set; }

    /// <summary>
    /// Размер страницы, должен быть больше 0
    /// </summary>
    [Required]
    [FromQuery(Name = "size")]
    [Range(1, int.MaxValue, ErrorMessage = "Укажите значение больше чем {1}")]
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}