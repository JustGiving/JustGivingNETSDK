using System;
using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Campaign
{
    public class CreateCampaignRequest
    {
        /// <summary>
        /// The url to assign to the campaign. 
        /// The full url created will be of the form /charity/{charityShortName}/{campaignUrl}.
        /// This must abide the following rules:
        /// - Must start with a letter
        /// - Subsequent valid characters are letters, numbers and dashes (-).
        /// (Required)
        /// </summary>
        public string CampaignUrl { get; set; }

        /// <summary>
        /// The name of the campaign. Max length 100 characters. (Required)
        /// </summary>
        public string CampaignName { get; set; }

        /// <summary>
        /// A summary description of the campaign. Max length 200 characters. (Required)
        /// </summary>
        public string CampaignSummary { get; set; }

        /// <summary>
        /// The campaign story. This must be no longer than 1000 characters. (Required)
        /// </summary>
        public string CampaignStory { get; set; }

        /// <summary>
        /// The three-letter currency code of the currency for the campaign.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The target to be raised for the campaign.
        /// This can't be less than 0.
        /// </summary>
        public decimal CampaignTarget { get; set; }

        /// <summary>
        /// The campaign logos.
        /// If there is a campaign specific logo you can add it here. It will replace the charity logo on the campaign page and on the campaign's fundraising pages.
        /// </summary>
        public IList<CreateCampaignImage> CampaignLogos { get; set; }

        /// <summary>
        /// The campaign cover photos.
        /// A high resolution cover photo that will be used whenever a campaign is featured. Minimum image width 650px. (Required)
        /// </summary>
        public IList<CreateCampaignImage> CampaignCoverPhotos { get; set; }

        /// <summary>
        /// Additional photos for the campaign.
        /// </summary>
        public IList<CreateCampaignImage> CampaignPhotos { get; set; }

        /// <summary>
        /// The campaign deadline.
        /// </summary>
        public DateTime CampaignDeadline { get; set; }

        /// <summary>
        /// The thank you message sent to donor after donating to the campaign.
        /// Max length of 200 characters. (Required)
        /// </summary>
        public string CampaignThankYouMessage { get; set; }

        /// <summary>
        /// Whether fundraising is enabled for the campaign.
        /// If set to false, fundraisers will not be able to create pages for the campaign. 
        /// (Direct donations to the campaign are enabled in either case).
        /// </summary>
        public bool FundraisingEnabled { get; set; }
    }
}