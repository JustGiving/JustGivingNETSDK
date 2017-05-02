namespace JustGivingSDK.Contracts.Account
{
    public class AccountInfo 
    {
        public UserAccountType AccountType { get; set; }

        public enum UserAccountType
        {
            JustGiving, External, None
        }
    }
}
