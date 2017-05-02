namespace JustGivingSDK.Contracts.Fundraising
{
    public class UpdateNotificationsPreferencesRequest
    {
        public bool DonationAlerts { get; set; }
        public bool FundraisingTips { get; set; }
        public bool RegularUpdates { get; set; }
    }
}
