namespace JustGivingSDK.Contracts.Account
{
    public class RegisterAccountRequest
    {
        /// <summary>
        /// Your reference (Optional).
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// The user's title. One of "Mr", "Mrs", "Miss", "Ms", "Dr", "Other" (Required).
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The user's firstName (Required).
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The user's lastName (Required).
        /// </summary>
        public string LastName { get; set; }
        public Address Address { get; set; }
        /// <summary>
        /// The user's email (Required).
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The user's password should be at least 6 characters long (Required).
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// A Boolean indicating whether user accepts JustGiving's Terms and conditions. Note providing false will fail validation (Required).
        /// </summary>
        public bool? AcceptTermsAndConditions { get; set; }
        /// <summary>
        /// The cause you anticipate the user will be fundraising for (optional). This will determine the visual design of email communications from JG to that user and their donors.
        /// </summary>
        public int? CauseId { get; set; }
    }
}
