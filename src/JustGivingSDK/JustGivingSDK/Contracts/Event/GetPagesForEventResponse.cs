using System.Collections.Generic;
using JustGivingSDK.Contracts.Fundraising;

namespace JustGivingSDK.Contracts.Event
{
    public class GetPagesForEventResponse
    {
        public int EventId { get; set; }
        public int TotalFundraisingPages { get; set; }
        public int TotalPages { get; set; }
        public List<FundraisingPageSummary> FundraisingPageSummaries { get; set; }
    }
}
