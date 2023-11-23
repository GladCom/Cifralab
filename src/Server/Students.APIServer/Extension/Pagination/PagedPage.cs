using Microsoft.EntityFrameworkCore;

namespace Students.APIServer.Extension.Pagination;

public class PagedPage<T> where T : class
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
    public List<T> Data { get; private set; }
    
    public PagedPage(List<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Data = items;
    }
    
    public static async Task <PagedPage<T>> ToPagedPage(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = await source.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedPage<T>(items, count, pageNumber, pageSize);
    }
}