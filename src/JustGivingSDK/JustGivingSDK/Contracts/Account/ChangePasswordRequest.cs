namespace JustGivingSDK.Contracts.Account
{
    public class ChangePasswordRequest
    {
        public string EmailAddress { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
