using System.Net.Http;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Campaign;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Campaign
{
    public class CampaignClient : ClientBase, ICampaignClient
    {
        public CampaignClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<RegisterCampaignFundraisingPageResponse> RegisterCampaignFundraisingPage(
            RegisterCampaignFundraisingPageRequest registerCampaignFundraisingPageRequest)
        {
            var resource = "/v1/campaigns/pages";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            return await Execute<RegisterCampaignFundraisingPageResponse, RegisterCampaignFundraisingPageRequest>(request, registerCampaignFundraisingPageRequest);
        }

        public async Task<GetPagesForCampaignResponse> GetPagesForCampaign(string charityShortName, string campaignShortUrl, int page,
            int pageSize)
        {
            var resource = $"/v1/campaigns/{charityShortName}/{campaignShortUrl}?page={page}&pageSize={pageSize}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetPagesForCampaignResponse>(request);
        }

        public async Task<CreateCampaignResponse> CreateCampaign(CreateCampaignRequest createCampaignRequest)
        {
            var resource = "/v1/campaigns";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            return await Execute<CreateCampaignResponse, CreateCampaignRequest>(request, createCampaignRequest);
        }

        public async Task<GetCampaignDetailsResponse> GetCampaignDetails(string charityName, string campaignName)
        {
            var resource = $"/v1/campaigns/{charityName}/{campaignName}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetCampaignDetailsResponse>(request);
        }

        public async Task<GetCampaignsByCharityIdResponse> GetCampaignsByCharityId(int charityId)
        {
            var resource = $"/v1/campaigns/{charityId}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetCampaignsByCharityIdResponse>(request);
        }
    }

    public interface ICampaignClient
    {
        Task<RegisterCampaignFundraisingPageResponse> RegisterCampaignFundraisingPage(
            RegisterCampaignFundraisingPageRequest registerCampaignFundraisingPageRequest);

        Task<GetPagesForCampaignResponse> GetPagesForCampaign(string charityShortName, string campaignShortUrl, int page,
            int pageSize);

        Task<CreateCampaignResponse> CreateCampaign(CreateCampaignRequest createCampaignRequest);
        Task<GetCampaignDetailsResponse> GetCampaignDetails(string charityName, string campaignName);
        Task<GetCampaignsByCharityIdResponse> GetCampaignsByCharityId(int charityId);
    }
}
