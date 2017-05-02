using System;
using System.Net.Http;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Event;
using JustGivingSDK.Contracts.Fundraising;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Event
{
    public class EventClient : ClientBase, IEventClient
    {
        public EventClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<Contracts.Event.Event> GetEventById(int eventId)
        {
            var resource = $"/v1/event/{eventId}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Contracts.Event.Event>(request);
        }

        public async Task<EventTypeDto[]> GetEventTypes()
        {
            var resource = "/v1/event/types";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<EventTypeDto[]>(request);
        }

        public async Task<EventSearchResponse> EventSearch(string query, int page, int pageSize)
        {
            var resource = $"/v1/event/search?q={Uri.EscapeDataString(query)}&page={page}&pageSize={pageSize}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<EventSearchResponse>(request);
        }

        public async Task<GetPagesForEventResponse> GetPagesForEvent(int eventId)
        {
            var resource = $"/v1/event/{eventId}/pages";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetPagesForEventResponse > (request);
        }

        public async Task<EventRegistrationResponse> RegisterEvent(EventRegistration eventRegistration)
        {
            var resource = "/v1/event";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            return await Execute<EventRegistrationResponse, EventRegistration>(request, eventRegistration);
        }

        public async Task<RegisterPageForEventByEventReferenceResponse> CreatePageForEventByEventReference(string eventRef,
            PageRegistration pageRegistration)
        {
            var resource = $"/v1/event/ref/{eventRef}/pages";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            return await Execute<RegisterPageForEventByEventReferenceResponse, PageRegistration>(request, pageRegistration);
        }
    }
}
