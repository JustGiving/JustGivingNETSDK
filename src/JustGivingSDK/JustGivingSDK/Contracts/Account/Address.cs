namespace JustGivingSDK.Contracts.Account
{
    public class Address
    {
        /// <summary>
        /// The first line of the of the address where the user resides (Required).
        /// </summary>
        public string Line1 { get; set; }
        /// <summary>
        /// The second line of the of the address where the user resides (Optional).
        /// </summary>
        public string Line2 { get; set; }
        /// <summary>
        /// The town or city where the user resides (Required).
        /// </summary>
        public string TownOrCity { get; set; }
        /// <summary>
        /// The county or state where the user resides (Optional).
        /// </summary>
        public string CountyOrState { get; set; }
        /// <summary>
        /// The country where the user resides (Required). A list of allowable countries is available via the Countries API.
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// The postcode or zip of the address where the user resides (Required).
        /// </summary>
        public string PostcodeOrZipcode { get; set; }
    }
}