using System;

namespace JustGivingSDK.Contracts.Fundraising
{
    public class FundraiserSearchResult
    {
        public string PageUrl { get; set; }
        public string Photo { get; set; }
        public string ImageAbsoluteUrl { get; set; }
        public string PageName { get; set; }
        public string PageOwner { get; set; }
        public string TeamMembers { get; set; }
        public DateTime CreatedDate { get; set; }
        public int EventId { get; set; }
        public int CauseId { get; set; }
        public string Status { get; set; }
        public int CharityId { get; set; }
        public DateTime? EventDate { get; set; }
        public int DesignId { get; set; }
        public int PercentageTargetAchieved { get; set; }
        public decimal TargetAmount { get; set; }
        public string EventName { get; set; }
    }
}