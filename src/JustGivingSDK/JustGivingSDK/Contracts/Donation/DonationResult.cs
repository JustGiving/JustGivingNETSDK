namespace JustGivingSDK.Contracts.Donation
{
    public class DonationResult 
    {
        /// <summary>
        /// Reference attached to the donation via Simple Donation Integration
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// The DonationId
        /// </summary>
        public int DonationId { get; set; }

        /// <summary>
        /// The DonationReference presented to the user on their donation receipt
        /// </summary>
        public string DonationRef { get; set; }

        /// <summary>
        /// One of "Accepted", "Rejected", "Cancelled", "Refunded", "Pending"
        /// </summary>
        public string Status { get; set; }

        public decimal Amount { get; set; }
    }
}
