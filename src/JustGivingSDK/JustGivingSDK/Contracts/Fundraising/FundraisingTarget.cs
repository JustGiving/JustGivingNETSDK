namespace JustGivingSDK.Contracts.Fundraising
{
    public class FundraisingTarget
    {
        public decimal Amount { get; set; }

        /// <summary>
        /// Must be a valid ISO currency code.
        /// </summary>
        public string Currency { get; set; }
    }
}
