using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Leaderboard
{
    public class CharitiesLeaderboard
    {
        public IList<TopCharity> Charities { get; set; }

        public string Currency { get; set; }
    }
}
