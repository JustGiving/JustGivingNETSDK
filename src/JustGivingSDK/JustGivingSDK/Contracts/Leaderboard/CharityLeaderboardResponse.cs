using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Leaderboard
{
    public class CharityLeaderboardResponse 
    {
        public int CharityId { get; set; }

        public string Name { get; set; }

        public IList<LeaderboardPage> Pages { get; set; }

        public string Currency { get; set; }

        public string CurrencySymbol { get; set; }
    }
}