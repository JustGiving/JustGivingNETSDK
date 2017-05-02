using System;

namespace JustGivingSDK.Contracts.Event
{
    public class Event 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// JustGiving EventId, ignored during requests to the RegisterEvent API.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The date the event finishes
        /// </summary>
        public DateTime? CompletionDate { get; set; }
        /// <summary>
        /// The date the event expires and will subsequently become unavailable on the site
        /// </summary>
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// The event start date
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// <para>Event names will be shown on fundraising pages for an event type of: Running_Marathons
        /// Treks, Walks, Cycling, Swimming, Triathlons, Parachuting_Skydives, OtherSportingEvents.
        /// Other event types will be correctly linked, but not visually represented on the page.</para>
        /// </summary>
        public string EventType { get; set; }
        public string Location { get; set; }
    }
}
