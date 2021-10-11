using BlazingShop.Server.Data;
using BlazingShop.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services
{
    public class StatsService : IStatsService
    {
        private readonly DataContext _data;

        public StatsService(DataContext data)
        {
            _data = data;
        }

        public async Task<int> GetVisitsAsync()
        {
            var stats = await _data.Stats.FirstOrDefaultAsync();
            if (stats == null)
            {
                return 0;
            }

            return stats.Visits;
        }

        public async Task ImplementVisitsAsync()
        {
            var stats = await _data.Stats.FirstOrDefaultAsync();
            if (stats == null)
            {
                _data.Stats.Add(new Stats() { Visits = 1, LastVisite = DateTime.Now });
            }
            else
            {
                stats.Visits++;
                stats.LastVisite = DateTime.Now;
            }

            await _data.SaveChangesAsync();
        }
    }
}
