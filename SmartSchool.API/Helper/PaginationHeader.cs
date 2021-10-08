namespace SmartSchool.API.Helper
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public PaginationHeader(int currentPage, int totalPages, int itemsPerPage, int totalItems)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
        }
    }
}
