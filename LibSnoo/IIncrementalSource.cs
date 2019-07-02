using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibSnoo
{
    public interface IIncrementalSource<T>
    {
        Task<IEnumerable<T>> GetPagedItems(string token, string subReddit = "all", string getByCriteria = "hot", uint pageSize = 10);
    }
}
