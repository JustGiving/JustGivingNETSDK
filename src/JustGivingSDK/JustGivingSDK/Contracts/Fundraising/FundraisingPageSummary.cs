﻿using System;
using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Fundraising
{
    public class FundraisingPageSummary
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public string PageStatus { get; set; }
        public string PageShortName { get; set; }
        public decimal RaisedAmount { get; set; }
        public int DesignId { get; set; }
        public int CompanyAppealId { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal OfflineDonations { get; set; }
        public decimal TotalRaisedOnline { get; set; }
        public decimal GiftAidPlusSupplement { get; set; }
        public List<string> PageImages { get; set; }
        public List<FundraisingPageImage> Images { get; set; }
        public string EventName { get; set; }
        public int EventId { get; set; }
        public string Domain { get; set; }
        public InMemoryPerson InMemoryPerson { get; set; }
        public string SmsCode { get; set; }
        public int CharityId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
