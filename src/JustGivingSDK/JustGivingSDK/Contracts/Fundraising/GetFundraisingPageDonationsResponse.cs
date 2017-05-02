using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Fundraising
{
    public class GetFundraisingPageDonationsResponse
    {
        public List<Donation> Donations { get; set; }
        public Pagination Pagination { get; set; }
        public string PageShortUrl { get; set; }
    }
}
