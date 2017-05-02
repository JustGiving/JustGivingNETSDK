using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Campaign
{
    public class GetCampaignsByCharityIdResponse
    {
        public List<GetCampaignDetailsResponse> CampaignsDetails { get; set; }
    }
}
