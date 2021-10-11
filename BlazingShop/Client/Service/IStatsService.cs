using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Client.Service
{
    public interface IStatsService
    {
        Task GetVisitsAsync();
        Task IncrementVisitsAsync();
    }
}
