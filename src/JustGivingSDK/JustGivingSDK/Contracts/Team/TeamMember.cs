namespace JustGivingSDK.Contracts.Team
{
    public class TeamMember
    {
        public int Id { get; set; }

        public string PageShortName { get; set; }

        public string PageTitle { get; set; }

        public string Ref { get; set; }

        public decimal TotalAmountRaised { get; set; }

        public decimal LocalAmountRaised { get; set; }

        public string LocalCurrencySymbol { get; set; }

        public int NumberOfDonations { get; set; }
    }
}