using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Account;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Account
{
    public class AccountClient : ClientBase, IAccountClient
    {
        public AccountClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
        }

        public async Task<Contracts.Account.Account> UpdateAccount(Guid userId, UpdateAccountRequest updateAccountRequest)
        {
            var resource = $"/v1/account/{userId}";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            return await Execute<Contracts.Account.Account, UpdateAccountRequest>(request, updateAccountRequest);
        }

        public async Task DeleteProfileImage()
        {
            var resource = "/v1/account/profileimage";
            var request = new HttpRequestMessage(HttpMethod.Delete, resource);
            await Execute(request);
        }

        public async Task SetProfileImageFromUri(Uri imageUri, bool isFromFacebook = false)
        {
            var resource = $"/v1/account/profileimage/uri?imageUri={Uri.EscapeDataString(imageUri.ToString())}&isFromFacebook={isFromFacebook}";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request);
        }

        public async Task<Contracts.Account.Account> RetrieveAccount()
        {
            var resource = "/v1/account";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Contracts.Account.Account>(request);
        }

        public async Task CreateAccount(RegisterAccountRequest registerAccountRequest)
        {
            var resource = "/v1/account";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request, registerAccountRequest);
        }

        public async Task<IEnumerable<FundraisingPageSummary>> GetFundraisingPagesForUser(string email, int? charityId = null)
        {
            var resource = $"/v1/account/{email}/pages";
            if (charityId.HasValue)
            {
                resource += $"?charityId={charityId.Value}";
            }
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<FundraisingPageSummary[]>(request);
        }

        public async Task RequestPasswordReminder(string email)
        {
            var resource = $"/v1/account/{email}/requestpasswordreminder";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request);
        }

        public async Task<ConsumerDonations> GetDonationsForUser()
        {
            var resource = "/v1/account/donations";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<ConsumerDonations>(request);
        }

        public async Task ValidateUser(ValidateUserRequest validateUserRequest)
        {
            var resource = "/v1/account/validate";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request, validateUserRequest);
        }

        public async Task ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            var resource = "/v1/account/password";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request, changePasswordRequest);
        }

        public async Task<AccountInfo> CheckAccountAvailability(string email)
        {
            var resource = $"/v1/account/{email}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<AccountInfo>(request);
        }
    }
}
