using Z3950.Api.Models;
using Zoom.Net;

namespace Z3950.Api.Services
{
    public interface IZ3950Service
    {
        (List<string>, int) Paging(SearchParam searchParam, int skip, int limit);
        List<string> Search(SearchParam searchParam);
        int SearchAndPrint(SearchParam searchParam);
    }
}
