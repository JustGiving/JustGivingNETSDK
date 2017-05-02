using System;
using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Account
{
    public class Account
    {
        public string Email { get; set; }
        public int ActivePageCount { get; set; }
        public int CompletedPagesCount { get; set; }
        public decimal TotalDonatedGiftAid { get; set; }
        public decimal TotalGiftAid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IDictionary<string, string> ProfileImageUrls { get; set; }
        public string Town { get; set; }
        public Address Address { get; set; }
        public DateTime? JoinDate { get; set; }
        public List<MonetaryAmount> DonationTotalsInSupportedCurrencies { get; set; }
        public List<MonetaryAmount> RaisedTotalsInSupportedCurrencies { get; set; }
        public List<string> AccountTypes { get; set; }
        public Guid UserId { get; set; }
        public int AccountId { get; set; }
    }
}
