namespace PersonsDictionary.Common.Models
{
    public class Paging
    {
        #region Constructor
        public Paging()
        {
        }

        public Paging(int page, int perPage)
        {
            CurrentPage = page;
            PerPage = perPage;
        }

        #endregion

        #region Properties
        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int TotalCount { get; set; }

        public int PerPage { get; set; }
        #endregion
    }
}
