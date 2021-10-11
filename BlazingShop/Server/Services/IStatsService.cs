using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services
{
    public interface IStatsService
    {
        Task<int> GetVisitsAsync();
        Task ImplementVisitsAsync();
    }
}
