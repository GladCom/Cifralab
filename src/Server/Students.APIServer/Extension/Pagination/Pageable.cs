using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Students.APIServer.Extension.Pagination;

/// <inheritdoc/>
public class Pageable : IPageable
{
    /// <inheritdoc/>
    [FromQuery(Name = "page")]
    public int PageNumber { get; set; }

    /// <inheritdoc/>
    [Required]
    [FromQuery(Name = "size")]
    [Range(1, int.MaxValue, ErrorMessage = "Укажите значение больше чем {1}")]
    public int PageSize { get; set; }
}