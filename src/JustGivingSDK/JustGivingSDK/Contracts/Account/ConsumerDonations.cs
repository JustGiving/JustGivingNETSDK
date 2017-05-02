using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Account
{
    public class ConsumerDonations
    {
        public List<ConsumerDonation> Donations { get; set; }
        public Pagination Pagination { get; set; }
        public DonationCharity Charity { get; set; }
    }
}
