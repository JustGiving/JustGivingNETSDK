using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Fundraising;

namespace JustGivingSDK.Clients.Fundraising
{
    public interface IFundraisingClient
    {
        Task<IEnumerable<Update>> GetPageUpdatesById(string pageShortName, int updateId);
        Task PageUpdateAddPost(string pageShortName, Update update);
        Task DeletePageUpdates(string pageShortName, int updateId);
        Task DeleteFundraisingPageImage(string pageShortName, string imageName);
        Task UpdateFundraisingPageTitle(string pageShortName, string title);
        Task UpdateFundraisingPageThankyouMessage(string pageShortName, string thankyouMessage);
        Task<string> GetFundraisingPageThankyouMessage(string pageShortName);
        Task CancelFundraisingPage(string pageShortName);

        Task UpdateNotificationsPreferences(string pageShortName,
            UpdateNotificationsPreferencesRequest updateRequest);

        Task UpdateFundraisingPageSummary(string pageShortName,
            UpdateFundraisingPageSummaryRequest updateRequest);

        Task<IEnumerable<Update>> GetFundraisingPageUpdates(string pageShortName);
        Task UpdateFundraisingPageStory(string pageShortName, string story);
        Task<GetFundraisingPageAttributionResponse> GetFundraisingPageAttribution(string pageShortName);
        Task<IEnumerable<string>> GetSuggestedPageNames(string preferredName);

        Task<IEnumerable<FundraiserSearchResult>> FundraiserSearch(string q, int? page, int? pageSize,
            int? causeId, int? eventId, int? charityId, int? designId, string status, DateTime? startDateRange, DateTime? endDateRange);

        Task<bool> PageExists(string pageShortName);
        Task<IEnumerable<FundraisingPageSummary>> GetFundraisingPages();
        Task<GetFundraisingPageResponse> GetFundraisingPageDetails(int pageId);
        Task<GetFundraisingPageResponse> GetFundraisingPageDetails(string pageShortName);
        Task<GetFundraisingPageDonationsResponse> GetFundraisingPageDonations(string pageShortName, int pageNumber = 1, int pageSize = 20);
        Task<GetFundraisingPageDonationsResponse> GetFundraisingPageDonationsByReference(string pageShortName, string reference);
        Task UpdateFundraisingPage(string pageShortName, string storySupplement);
        Task UpdateFundraisingPageAttribution(string pageShortName, string attribution);
        Task DeleteFundraisingPageAttribution(string pageShortName);
        Task AppendToFundraisingPageAttribution(string pageShortName, string attribution);
        Task UploadImage(string pageShortName, byte[] imageData, string contentType, string caption = "");
        Task UploadImage(string pageShortName, FileInfo image, string contentType, string caption = "");
        Task UploadDefaultImage(string pageShortName, byte[] imageData, string contentType, string caption);
        Task UploadDefaultImage(string pageShortName, FileInfo image, string contentType, string caption);
        Task RegisterFundraisingPage(PageRegistration pageRegistration);

        Task AddImageToFundraisingPage(string pageShortName, Uri imageUri, bool isDefault,
            string caption = "");

        Task<IEnumerable<FundraisingPageImage>> GetImagesForFundraisingPage(string pageShortName);
        Task AddVideoToFundraisingPage(string pageShortName, Uri videoUri, bool isDefault, string caption = "");
        Task<IEnumerable<FundraisingPageVideo>> GetVideosForFundraisingPage(string pageShortName);
        Task<IEnumerable<Currency>> GetValidCurrencyCodes();
        Task UpdateFundraisingPageTarget(string pageShortName, FundraisingTarget target);
        Task UpdateOfflineAmount(string pageShortName, decimal amount);
        Task ExtendFundraisingPage(string pageShortName, DateTime expiryDate);
        Task CloseFundraisingPage(string pageShortName);
        Task ReopenFundraisingPage(string pageShortName);
        Task<PageNotificationPreferences> GetNotificationPreferences(string pageShortName);
    }
}