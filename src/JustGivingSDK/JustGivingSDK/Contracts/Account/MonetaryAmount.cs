namespace JustGivingSDK.Contracts.Account
{
    public class MonetaryAmount
    {
        public string CurrencySymbol { get; set; }
        public AcceptedIsoCurrencyCode CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}