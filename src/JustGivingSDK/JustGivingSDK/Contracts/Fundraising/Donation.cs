using System;

namespace JustGivingSDK.Contracts.Fundraising
{
    public class Donation
    {
        public int Id { get; set; }
        public string DonationRef { get; set; }
        public string Image { get; set; }
        public bool HasImage { get; set; }
        public DateTime? DonationDate { get; set; }
        public string DonorDisplayName { get; set; }
        public string Message { get; set; }
        public bool HasMessage { get; set; }
        public decimal? EstimatedTaxReclaim { get; set; }
        public string Amount { get; set; }
        public string DonorRealName { get; set; }
        public string ThirdPartyReference { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string CurrencyCode { get; set; }
        public string DonorLocalAmount { get; set; }
        public string DonorLocalCurrencyCode { get; set; }
    }
}