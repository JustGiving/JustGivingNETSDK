using System;
using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Charity
{
    public class Charity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public string LogoAbsoluteUrl { get; set; }

        public string ProfilePageUrl { get; set; }

        public string RegistrationNumber { get; set; }

        public string WebsiteUrl { get; set; }

        public int Id { get; set; }

        public string PageShortName { get; set; }

        public string SmsShortName { get; set; }

        public string EmailAddress { get; set; }

        public string Keywords { get; set; }

        public DateTime? DateAddedToJustGiving { get; set; }

        public string ThankyouMessage { get; set; }

        public IList<MobileAppeal> MobileAppeals { get; set; }

        public List<string> Categories { get; set; }

        public IList<DonationDisplayAmount> DonationDisplayAmounts { get; set; }

        public string ImpactStatementWhat { get; set; }

        public string ImpactStatementWhy { get; set; }

        public string CountryCode { get; set; }

        public string CurrencyCode { get; set; }
    }
}
