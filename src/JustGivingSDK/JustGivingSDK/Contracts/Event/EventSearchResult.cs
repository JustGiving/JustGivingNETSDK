using System;

namespace JustGivingSDK.Contracts.Event
{
    public class EventSearchResult 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int NumberOfLivePages { get; set; }

        public bool IsManaged { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public int CategoryId { get; set; }

        public decimal AmountRaised { get; set; }

        public decimal AmountGiftAid { get; set; }
    }
}