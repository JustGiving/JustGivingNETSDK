namespace JustGivingSDK.Contracts.Donation
{
    public class GetDonationsTotalByReferenceResponse
    {
        public decimal DonationsTotal { get; set; }

        public decimal TotalEstimatedTaxReclaim { get; set; }

        public string ThirdPartyReference { get; set; }

        public string CurrencyCode { get; set; }

        public int NumberOfDonations { get; set; }
    }
}
