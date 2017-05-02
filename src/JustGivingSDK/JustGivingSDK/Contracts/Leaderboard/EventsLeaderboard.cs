using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Leaderboard
{
    public class EventsLeaderboard
    {
        public IList<TopEvent> Events { get; set; }

        public string Currency { get; set; }
    }
}