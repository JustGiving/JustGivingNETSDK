using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Donation
{
    public class GetDonationsByReferenceResponse
    {
        public List<Donation> Donations { get; set; }

        public Pagination Pagination { get; set; }

    }
}
