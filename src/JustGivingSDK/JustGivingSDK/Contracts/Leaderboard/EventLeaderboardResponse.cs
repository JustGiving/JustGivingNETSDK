using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Leaderboard
{
    public class EventLeaderboardResponse 
    {
        public string EventName { get; set; }
        public IList<LeaderboardPage> Pages { get; set; }
        public string Currency { get; set; }
        public decimal RaisedAmount { get; set; }
    }
}