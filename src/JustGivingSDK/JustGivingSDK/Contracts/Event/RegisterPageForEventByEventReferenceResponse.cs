namespace JustGivingSDK.Contracts.Event
{
    public class RegisterPageForEventByEventReferenceResponse 
    {
        public int EventId { get; set; }

        public RestResponseNavigationElement Next { get; set; }
        
        public int PageId { get; set; }

        /// <summary>
        /// You can redirect your users to this URL and they will be automatically signed in to their newly created fundraising page. 
        /// The URL can only be used once, and must be used within 20 minutes of the page being created.
        /// </summary>
        public string SignOnUrl { get; set; }
    }
}