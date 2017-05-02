using System.Collections.Generic;
using JustGivingSDK.Contracts.Fundraising;

namespace JustGivingSDK.Contracts.Campaign
{
    public class GetPagesForCampaignResponse
    {
        public string CharityShortName { get; set; }

        public string CampaignShortUrl { get; set; }

        public int CampaignId { get; set; }

        public int TotalFundraisingPages { get; set; }

        public int TotalPages { get; set; }

        public IList<FundraisingPageSummary> FundraisingPageSummaries { get; set; }
    }
}
