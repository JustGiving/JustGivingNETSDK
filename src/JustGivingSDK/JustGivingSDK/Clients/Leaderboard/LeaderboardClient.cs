using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Leaderboard;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Leaderboard
{
    public class LeaderboardClient : ClientBase, ILeaderboardClient
    {
        public LeaderboardClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<CharitiesLeaderboard> GetCharitiesLeaderboard(string currency = "GBP")
        {
            var resource = $"/v1/leaderboard/charities?currency={currency}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<CharitiesLeaderboard>(request);
        }

        public async Task<EventsLeaderboard> GetEventsLeaderboard(string currency = "GBP")
        {
            var resource = $"/v1/leaderboard/events?currency={currency}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<EventsLeaderboard>(request);
        }

        public async Task<CharityLeaderboardResponse> GetCharityLeaderboard(int charityId, string currency = "GBP")
        {
            var resource = $"/v1/charity/{charityId}/leaderboard?currency={currency}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<CharityLeaderboardResponse>(request);
        }

        public async Task<EventLeaderboardResponse> GetEventLeaderboard(int eventId, string currency = "GBP")
        {
            var resource = $"/v1/event/{eventId}/leaderboard?currency={currency}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<EventLeaderboardResponse>(request);
        }
    }
}
