using System.Threading.Tasks;
using JustGivingSDK.Contracts.Leaderboard;

namespace JustGivingSDK.Clients.Leaderboard
{
    public interface ILeaderboardClient
    {
        Task<CharitiesLeaderboard> GetCharitiesLeaderboard(string currency = "GBP");
        Task<EventsLeaderboard> GetEventsLeaderboard(string currency = "GBP");
        Task<CharityLeaderboardResponse> GetCharityLeaderboard(int charityId, string currency = "GBP");
        Task<EventLeaderboardResponse> GetEventLeaderboard(int eventId, string currency = "GBP");
    }
}