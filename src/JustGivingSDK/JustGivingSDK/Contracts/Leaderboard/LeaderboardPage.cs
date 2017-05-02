using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Leaderboard
{
    public class LeaderboardPage
    { 
        public string PageTitle { get; set; }

        public decimal Amount { get; set; }

        public string PageShortName { get; set; }

        public string DefaultImage { get; set; }

        public string Owner { get; set; }

        public IDictionary<string, string> OwnerProfileImageUrls { get; set; }

        public decimal TargetAmount { get; set; }
    }
}