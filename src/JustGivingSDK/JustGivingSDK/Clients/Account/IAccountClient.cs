using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Account;

namespace JustGivingSDK.Clients.Account
{
    public interface IAccountClient
    {
        Task<Contracts.Account.Account> UpdateAccount(Guid userId, UpdateAccountRequest updateAccountRequest);
        Task DeleteProfileImage();
        Task SetProfileImageFromUri(Uri imageUri, bool isFromFacebook = false);
        Task<Contracts.Account.Account> RetrieveAccount();
        Task CreateAccount(RegisterAccountRequest registerAccountRequest);
        Task<IEnumerable<FundraisingPageSummary>> GetFundraisingPagesForUser(string email, int? charityId = null);
        Task RequestPasswordReminder(string email);
        Task<ConsumerDonations> GetDonationsForUser();
        Task ValidateUser(ValidateUserRequest validateUserRequest);
        Task ChangePassword(ChangePasswordRequest changePasswordRequest);
        Task<AccountInfo> CheckAccountAvailability(string email);
    }
}