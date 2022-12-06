
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
        result.PageSize = pageSize;
        result.RowCount = await query.CountAsync();

        result.PageCount = (int)Math.Ceiling((double)result.RowCount / pageSize);
 
        var skip = (pageNumber - 1) * pageSize;     
        result.Data = await query.Skip(skip).Take(pageSize).ToListAsync();
 
        return result;
    }
    
    public static PagedResult<T> GetPagedViewModel<T>(this IEnumerable<T> query, 
        int pageNumber, int pageSize) where T : class
    {

        pageNumber = pageNumber != 0 ? pageNumber : 1;
        pageSize = pageSize != 0 ? pageSize : 1;
        
        var result = new PagedResult<T>();
        result.CurrentPage = pageNumber;
        result.PageSize = pageSize;
        result.RowCount = query.Count();

        result.PageCount = (int)Math.Ceiling((double)result.RowCount / pageSize);
 
        var skip = (pageNumber - 1) * pageSize;     
        result.Data = query.Skip(skip).Take(pageSize).ToList();
 
        return result;
    }
}