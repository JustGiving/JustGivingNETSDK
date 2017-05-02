using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Charity;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Charity
{
    public class CharityClient : ClientBase, ICharityClient
    {
        public CharityClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<PromotedCharityDonations> GetCharityDonations(int charityId)
        {
            var resource = $"/v1/charity/{charityId}/donations";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<PromotedCharityDonations>(request);
        }

        public async Task<GetCharityCaresResult> GetCharityCares(int charityId)
        {
            var resource = $"/v1/charity/{charityId}/cares";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetCharityCaresResult>(request);
        }

        public async Task CareForCharity(int charityId)
        {
            var resource = $"/v1/charity/{charityId}/care";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request);
        }

        public async Task UncareForCharity(int charityId)
        {
            var resource = $"/v1/charity/{charityId}/un-care";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request);
        }

        public async Task<MyCharityCaresResult> GetMyCaresForCharity(int skip, int take)
        {
            var resource = $"/v1/account/cares/charity/skip/{skip}/take/{take}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<MyCharityCaresResult>(request);
        }

        public async Task<CharityCategory[]> GetCharityCategories()
        {
            var resource = "/v1/charity/categories";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<CharityCategory[]>(request);
        }

        public async Task AppendToFundraisingPageAttribution(string attribution, int charityId, string pageShortName)
        {
            var resource = $"/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var dto = new {attribution};
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute<dynamic>(request, dto);
        }

        public async Task DeleteFundraisingPageAttribution(int charityId, string pageShortName)
        {
            var resource = $"/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new HttpRequestMessage(HttpMethod.Delete, resource);
            await Execute(request);
        }

        public async Task UpdateFundraisingPageAttribution(string attribution, int charityId, string pageShortName)
        {
            var resource = $"/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var dto = new { attribution };
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute<dynamic>(request, dto);
        }

        public async Task<CharityAttribution> GetFundraisingPageAttribution(int charityId, string pageShortName)
        {
            var resource = $"/v1/charity/{charityId}/pages/{pageShortName}/attribution";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<CharityAttribution>(request);
        }

        public async Task<CharitySearchResponse> CharitySearch(string query, int page, int pageSize)
        {
            var resource = $"/v1/charity/search?q={Uri.EscapeDataString(query)}&page={page}&pageSize={pageSize}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<CharitySearchResponse>(request);
        }

        public async Task<Contracts.Charity.Charity> GetCharityById(int id)
        {
            var resource = $"/v1/charity/{id}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Contracts.Charity.Charity>(request);
        }

        public async Task AuthenticateCharityAccount()
        {
            var resource = "/v1/charity/authenticate";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request);
        }

        public async Task<RetrieveEventsResponse> GetEventsByCharityId(int charityId, int pageNum, int pageSize)
        {
            var resource = $"/v1/charity/{charityId}/events?pageNum={pageNum}&pageSize={pageSize}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<RetrieveEventsResponse>(request);
        }
    }
}
