namespace JustGivingSDK.Contracts.Event
{
    public class EventTypeDto
    {
        /// <summary>
        /// JustGiving EventTypeId.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The friendly name of the event type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The system representation of the event type.
        /// </summary>
        public string EventType { get; set; }
    }
}
