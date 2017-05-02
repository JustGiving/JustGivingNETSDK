using System;
using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Donation
{
    public class Donation
    {
        public Donation()
        {
            DonorDisplayName = "Anonymous";
        }

        public int Id { get; set; }

        /// <summary>
        /// The DonationReference presented to the user on their donation receipt
        /// </summary>
        public string DonationRef { get; set; }

        /// <summary>
        /// The image the user selected when leaving a message. Only available if the user has left a message with preferences that allow this information to be shared.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Only available if the user has left a message with preferences that allow this information to be shared.
        /// </summary>
        public bool HasImage { get; set; }

        public DateTime? DonationDate { get; set; }

        /// <summary>
        /// The name the donor left with their donation message
        /// </summary>
        public string DonorDisplayName { get; set; }

        /// <summary>
        /// The message the donor left with their donation.
        /// Only available if the authenticated user credentials match the page owner
        /// or if the donation preferences enable sharing this value on the web.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Only available if the authenticated user credentials match the page owner
        /// or if the donation preferences enable sharing this value on the web.
        /// </summary>
        public bool HasMessage { get; set; }

        public decimal? EstimatedTaxReclaim { get; set; }

        public string Amount { get; set; }

        /// <summary>
        /// Only available if the authenticated user credentials match the page owner.
        /// </summary>
        public string DonorRealName { get; set; }

        /// <summary>
        /// Reference attached to the donation via Simple Donation Integration
        /// </summary>
        public string ThirdPartyReference { get; set; }

        /// <summary>
        /// One of "Accepted", "Rejected", "Cancelled", "Refunded" or "Pending"
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The origin of the donation, one of
        /// "DirectDonations", "SponsorshipDonations", "Ipdd", "Sms"
        /// </summary>
        public string Source { get; set; }

        public string CurrencyCode { get; set; }

        public string DonorLocalAmount { get; set; }

        public string DonorLocalCurrencyCode { get; set; }

        public int CharityId { get; set; }

        public int? EventId { get; set; }

        public string CharityName { get; set; }


        /// <summary>
        /// The payment method, one of
        /// "Card", "DirectDebit", "Sms", "Paypal" , "Other"
        /// </summary>
        public string PaymentType { get; set; }

        public string PageShortName { get; set; }

        public string PageOwnerName { get; set; }

        public string PageTitle { get; set; }

        public int PageId { get; set; }

        public string LogoAbsoluteUrl { get; set; }

        public IDictionary<string, string> OwnerProfileImageUrls { get; set; }
    }
}
