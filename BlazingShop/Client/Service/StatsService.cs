using Blazored.LocalStorage;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazingShop.Client.Service
{
    public class StatsService : IStatsService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorageService;

        public StatsService(HttpClient http, ILocalStorageService localStorageService)
        {
            _http = http;
            _localStorageService = localStorageService;
        }

        public async Task GetVisitsAsync()
        {
            int visits = int.Parse(await _http.GetStringAsync("api/stats"));
            Console.WriteLine($"Our visits is now: {visits}");
        }

        public async Task IncrementVisitsAsync()
        {
            DateTime? lastVisit = await _localStorageService.GetItemAsync<DateTime?>("lastvisit");
            if (lastVisit == null || ((DateTime)lastVisit).Date != DateTime.Now.Date)
            {
                await _localStorageService.SetItemAsync("lastvisit", DateTime.Now);
                await _http.PostAsync("api/stats", null);
            }
        }
    }
}
