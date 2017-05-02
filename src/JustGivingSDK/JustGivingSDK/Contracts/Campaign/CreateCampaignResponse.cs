namespace JustGivingSDK.Contracts.Campaign
{
    public class CreateCampaignResponse
    {
        /// <summary>
        /// The charity short name, unique to the charity.
        /// </summary>
        public string CharityShortName { get; set; }

        /// <summary>
        /// The campaign short url, unique for each campaign on a charity.
        /// </summary>
        public string CampaignShortUrl { get; set; }

        /// <summary>
        /// The url to get the created campaign details from the API.
        /// </summary>
        public string CampaignFullUrl { get; set; }
    }
}
