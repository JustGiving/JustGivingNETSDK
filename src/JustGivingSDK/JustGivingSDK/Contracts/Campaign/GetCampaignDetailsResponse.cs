using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Campaign
{
    public class GetCampaignDetailsResponse
    {
        /// <summary>
        /// The JustGiving campaign id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Images associated with the campaign.
        /// </summary>
        public List<CampaignImageDto> Images { get; set; }

        /// <summary>
        /// The campaign story.
        /// </summary>
        public string Story { get; set; }

        /// <summary>
        /// The number of fundraisers connected to the campaign.
        /// </summary>
        public int NumberOfFundraisersConnected { get; set; }

        /// <summary>
        /// The target amount in the campaign currency.
        /// </summary>
        public decimal Target { get; set; }

        /// <summary>
        /// The total amount raised in the campaign currency.
        /// </summary>
        public string TotalRaised { get; set; }

        /// <summary>
        /// The total amount raised offline in the campaign currency.
        /// </summary>
        public decimal TotalOffline { get; set; }

        /// <summary>
        /// The total donated in the campaign currency.
        /// </summary>
        public string TotalDonated { get; set; }

        /// <summary>
        /// The total fundraised in the campaign currency.
        /// </summary>
        public string TotalFundraised { get; set; }

        /// <summary>
        /// The number of direct donations to the campaign.
        /// </summary>
        public int NumberOfDirectDonations { get; set; }

        /// <summary>
        /// The percentage of the target that has been raised so far.
        /// </summary>
        public int TargetPercentage { get; set; }

        /// <summary>
        /// The JustGiving charity id of the charity that owns this campaign.
        /// </summary>
        public int CharityId { get; set; }

        /// <summary>
        /// The description of the campaign.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URL of the charity logo.
        /// </summary>
        public string CharityLogoUrl { get; set; }

        /// <summary>
        /// The currency of the campaign.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Whether fundraising has been enabled on the campaign.
        /// </summary>
        public bool FundraisingEnabled { get; set; }

        /// <summary>
        /// The cause id that this campaign is attached to.
        /// </summary>
        public int CauseId { get; set; }

        /// <summary>
        /// The name of the campaign.
        /// </summary>
        public string CampaignPageName { get; set; }

        /// <summary>
        /// The url of the campaign.
        /// </summary>
        public string CampaignUrl { get; set; }
    }
}
