using System.Threading.Tasks;
using JustGivingSDK.Contracts.Event;
using JustGivingSDK.Contracts.Fundraising;

namespace JustGivingSDK.Clients.Event
{
    public interface IEventClient
    {
        Task<Contracts.Event.Event> GetEventById(int eventId);
        Task<EventTypeDto[]> GetEventTypes();
        Task<EventSearchResponse> EventSearch(string query, int page, int pageSize);
        Task<GetPagesForEventResponse> GetPagesForEvent(int eventId);
        Task<EventRegistrationResponse> RegisterEvent(EventRegistration eventRegistration);
        Task<RegisterPageForEventByEventReferenceResponse> CreatePageForEventByEventReference(string eventRef, PageRegistration pageRegistration);
    }
}