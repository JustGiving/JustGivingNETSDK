using System.Net.Http;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Donation;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Donation
{
    public class DonationClient : ClientBase, IDonationClient
    {
        public DonationClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<Contracts.Donation.Donation> RetrieveDonation(int donationId)
        {
            var resource = $"/v1/donation/{donationId}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Contracts.Donation.Donation>(request);
        }

        public async Task<DonationResult> RetrieveDonationStatus(int donationId)
        {
            var resource = $"/v1/donation/{donationId}/status";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<DonationResult>(request);
        }

        public async Task<GetDonationsByReferenceResponse> GetDonationsByReference(string reference, int pageNum,
            int pageSize)
        {
            var resource = $"/v1/donation/ref/{reference}?pageNum={pageNum}&pageSize={pageSize}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetDonationsByReferenceResponse>(request);
        }

        public async Task<GetDonationsTotalByReferenceResponse> GetDonationsTotalByReference(string reference, string currencyCode = "GBP")
        {
            var resource = $"/v1/donationtotal/ref/{reference}?currencyCode={currencyCode}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetDonationsTotalByReferenceResponse>(request);
        }
    }
}
