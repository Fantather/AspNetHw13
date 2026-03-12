namespace AspNetHw13.Models
{
    public record class PaginationParameters
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            init => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }


        public int PageIndex { get; init; } = 1;
        public string? Query { get; init; }
    }
}
