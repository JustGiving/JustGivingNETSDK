using System.Threading.Tasks;
using JustGivingSDK.Contracts.Donation;

namespace JustGivingSDK.Clients.Donation
{
    public interface IDonationClient
    {
        Task<Contracts.Donation.Donation> RetrieveDonation(int donationId);
        Task<DonationResult> RetrieveDonationStatus(int donationId);

        Task<GetDonationsByReferenceResponse> GetDonationsByReference(string reference, int pageNum,
            int pageSize);

        Task<GetDonationsTotalByReferenceResponse> GetDonationsTotalByReference(string reference, string currencyCode = "GBP");
    }
}