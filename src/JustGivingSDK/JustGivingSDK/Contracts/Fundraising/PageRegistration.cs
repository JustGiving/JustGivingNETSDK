using System;
using System.Collections.Generic;
using System.Data;

namespace JustGivingSDK.Contracts.Fundraising
{
    public class PageRegistration
    {
        public string Reference { get; set; }

        /// <summary>
        /// The charityId argument specifies the charity to create the fundraising page for. (Required)
        /// </summary>
        public int? CharityId { get; set; }

        /// <summary>
        /// The eventId argument specifies the event to create the fundraising page for. This argument must be omitted if an activityType is specified.
        /// </summary>
        public int? EventId { get; set; }

        /// <summary>
        /// The pageShortName argument specifies the url you want to assign the new fundraising page. If the short url is available your page will be available at http://www.justgiving.com/{pageShortName} once it is created. (Required)
        /// </summary>
        public string PageShortName { get; set; }

        /// <summary>
        /// The pageTitle argument allows you to provide a title for the page. (Required)
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// The activityType argument specifies the type of activity the page is for. This argument must be omitted if an eventId is specified.
        /// ActivityTypes:
        /// Birthday
        /// Wedding
        /// OtherCelebration
        /// InMemory
        /// </summary>
        public string ActivityType { get; set; }

        /// <summary>
        /// The targetAmount argument allows you to specify a target amount to raise. (Optional)
        /// </summary>
        public decimal? TargetAmount { get; set; }

        /// <summary>
        /// The charityOptIn argument allows you to indicate whether the user wishes to opt in to receive communications from the charity the fundraising page is for. (Required)
        /// </summary>
        public bool CharityOptIn { get; set; }

        /// <summary>
        /// The eventDate argument allows you to specify when the event will take place. Required for event activity types (i.e: Birthday, Wedding, OtherCelebration, InMemory).
        /// </summary>
        public DateTime? EventDate { get; set; }

        /// <summary>
        /// The eventName argument allows you to specify a name for the event. Required for event activity types (i.e: Birthday, Wedding, OtherCelebration, InMemory).
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// The attribution argument allows you to specify who the fundraising page is attributed to. Required for occasion, organised event and in-memory activity types (i.e: all except Birthday, Wedding).
        /// </summary>
        public string Attribution { get; set; }

        /// <summary>
        /// The charityFunded argument specifies whether the charity is contributing in some way to the fundraising, which can affect Gift Aid. For more information about how Gift Aid works http://bit.ly/cZfY1R (Required)
        /// </summary>
        public bool CharityFunded { get; set; }

        /// <summary>
        ///  The causeId argument specifies the cause you are creating a fundraising page for. (Optional)
        /// </summary>
        public int? CauseId { get; set; }

        /// <summary>
        ///  The companyAppealId argument specifies the company appeal you are creating a fundraising page for. (Optional)
        /// </summary>
        public int? CompanyAppealId { get; set; }

        /// <summary>
        /// The date the page should expire. This is ignored if you are creating a fundraising page for a pre-defined event.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        public string PageStory { get; set; }

        /// <summary>
        /// The 'I'm doing action X' part of the fundraising page summary. (Optional). 50 characters max.
        /// </summary>
        public string PageSummaryWhat { get; set; }

        /// <summary>
        /// The 'reason Z' part of the fundraising page summary. (Optional). 50 characters max.
        /// </summary>
        public string PageSummaryWhy { get; set; }

        public PageCustomCodes CustomCodes { get; set; }
        public PageTheme Theme { get; set; }
        public IList<ImageInfo> Images { get; set; }
        public IList<VideoInfo> Videos { get; set; }
        public RememberedPersonReference RememberedPersonReference { get; set; }

        /// <summary>
        /// The teamId argument specifies the team to which the fundraising page will be associated with. 
        /// </summary>
        public int? TeamId { get; set; }

        public string Currency { get; set; }

        public class ImageInfo
        {
            public string Caption { get; set; }
            public string Url { get; set; }
            public bool IsDefault { get; set; }
        }

        public class VideoInfo
        {
            public string Caption { get; set; }
            public string Url { get; set; }
        }
    }
}
