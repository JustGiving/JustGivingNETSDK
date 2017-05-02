using System;

namespace JustGivingSDK.Contracts.Charity
{
    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public DateTime? CompletionDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime? StartDate { get; set; }

        public string EventType { get; set; }
        public string Location { get; set; }
    }
}