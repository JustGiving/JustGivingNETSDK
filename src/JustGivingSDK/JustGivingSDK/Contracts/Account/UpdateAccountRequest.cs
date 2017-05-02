namespace JustGivingSDK.Contracts.Account
{
    public class UpdateAccountRequest
    {
        /// <summary>
        /// The user's firstName (Required).
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user's lastName (Required).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user's email (Required).
        /// </summary>
        public string Email { get; set; }

        public Address Address { get; set; }
    }
}
