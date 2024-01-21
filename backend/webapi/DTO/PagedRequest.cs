namespace webapi.DTO
{
    public class PagedRequest<TFilter> where TFilter : BaseFilter
    {
        public string? Query { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public TFilter? Filter { get; set; }
    }
}
