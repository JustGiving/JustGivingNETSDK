using System;

namespace JustGivingSDK.Contracts.Fundraising
{
    public class Update
    {
        public int? Id { get; set; }
        public string Video { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Message { get; set; }
    }
}
