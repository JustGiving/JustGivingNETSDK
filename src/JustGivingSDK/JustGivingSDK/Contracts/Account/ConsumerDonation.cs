using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Account
{
    public class ConsumerDonation
    {
        /// <summary>
        /// Charity id
        /// </summary>
        public int CharityId { get; set; }
        /// <summary>
        /// Charity name
        /// </summary>
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