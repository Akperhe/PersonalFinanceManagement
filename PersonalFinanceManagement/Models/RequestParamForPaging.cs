namespace PersonalFinanceManagement.Models
{
    public class RequestParamForPaging
    {

        const int maxPageSize = 2;
        public int PageNumber { get; set; } = 1; // you cant introduces 0 here is not in the induced o cos its out of range
        private int _pageSize = 2;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value; //value is a key word its the value passed by the client in the query sections
            }
        }
    }
}
