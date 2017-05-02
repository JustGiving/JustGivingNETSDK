using System;

namespace JustGivingSDK.Contracts.Charity
{
    public class CharityDonationMessage
    {
        public string DonorDisplayName { get; set; }

        public string Message { get; set; }

        public decimal? Amount { get; set; }

        public decimal? EstimatedTaxReclaim { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DonationDate { get; set; }

        public string CurrencyCode { get; set; }

        public decimal? DonorLocalAmount { get; set; }

        public string DonorLocalCurrencyCode { get; set; }
    }
}