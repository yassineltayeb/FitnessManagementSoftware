namespace Repository.Helpers;

public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }

    public int FirstRowOnPage
    {
        get { return (CurrentPage - 1) * ItemsPerPage + 1; }
    }

    public int LastRowOnPage
    {
        get { return Math.Min(CurrentPage * ItemsPerPage, TotalItems); }
    }
}

public class PagedResult<T> : PagedResultBase where T : class
{
    public IList<T> Data { get; set; }

    public PagedResult()
    {
        Data = new List<T>();
    }
}