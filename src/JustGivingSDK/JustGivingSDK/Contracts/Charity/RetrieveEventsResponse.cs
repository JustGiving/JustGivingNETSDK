using System.Collections.Generic;

namespace JustGivingSDK.Contracts.Charity
{
    public class RetrieveEventsResponse
    {
        public List<Event> Events { get; set; }

        public int CharityId { get; set; }
    }
}
