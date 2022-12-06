
using Microsoft.EntityFrameworkCore;
using Repository.Helpers;

namespace Repository.Extensions;


public static class PaginationExtensions
{
    public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query, 
        int pageNumber, int pageSize) where T : class
    {

        pageNumber = pageNumber != 0 ? pageNumber : 1;
        pageSize = pageSize != 0 ? pageSize : 1;
        
        var result = new PagedResult<T>();
        result.CurrentPage = pageNumber;
        result.ItemsPerPage = pageSize;
        result.TotalItems = await query.CountAsync();

        result.PageCount = (int)Math.Ceiling((double)result.TotalItems / pageSize);
 
        var skip = (pageNumber - 1) * pageSize;     
        result.Data = await query.Skip(skip).Take(pageSize).ToListAsync();
 
        return result;
    }
    
    public static PagedResult<T> GetPagedViewModel<T>(this IEnumerable<T> query, 
        int itemsCount, int pageNumber, int pageSize) where T : class
    {

        pageNumber = pageNumber != 0 ? pageNumber : 1;
        pageSize = pageSize != 0 ? pageSize : 10;
        
        var result = new PagedResult<T>();
        result.CurrentPage = pageNumber;
        result.ItemsPerPage = pageSize;
        result.TotalItems = itemsCount;

        result.PageCount = (int)Math.Ceiling((double)result.TotalItems / pageSize);
 
        result.Data = query.ToList();
 
        return result;
    }
}