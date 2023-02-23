using Z3950.Api.Models;

namespace Z3950.Api.Services
{
    public interface IZ3950Service
    {
        List<object> Search(SearchParam searchParam);
    }
}
