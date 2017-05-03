using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JustGivingSDK.Contracts.Fundraising;
using JustGivingSDK.Logging;

namespace JustGivingSDK.Clients.Fundraising
{
    public class FundraisingClient : ClientBase, IFundraisingClient
    {
        public FundraisingClient(HttpClient http, ApiRequestLogger logger) : base(http, logger)
        {
           
        }

        public async Task<IEnumerable<Update>> GetPageUpdatesById(string pageShortName, int updateId)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/updates/{updateId}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Update[]>(request);
        }

        public async Task PageUpdateAddPost(string pageShortName, Update update)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/updates";
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request, update);
        }

        public async Task DeletePageUpdates(string pageShortName, int updateId)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/updates/{updateId}";
            var request = new HttpRequestMessage(HttpMethod.Delete, resource);
            await Execute(request);
        }

        public async Task DeleteFundraisingPageImage(string pageShortName, string imageName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/images/{imageName}";
            var request = new HttpRequestMessage(HttpMethod.Delete, resource);
            await Execute(request);
        }

        public async Task UpdateFundraisingPageTitle(string pageShortName, string title)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/pageTitle";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, new UpdateFundraisingPageTitleRequest {PageTitle = title});
        }

        public async Task UpdateFundraisingPageThankyouMessage(string pageShortName, string thankyouMessage)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/thankyou";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, new UpdateFundraisingPageThankYouRequest { ThankYou = thankyouMessage });
        }

        public async Task<string> GetFundraisingPageThankyouMessage(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/thankyou";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            var response = await Execute<GetPageThankYouMessageResponse>(request);
            return response.ThankYouMessage;
        }

        public async Task CancelFundraisingPage(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}";
            var request = new HttpRequestMessage(HttpMethod.Delete, resource);
            await Execute(request);
        }

        public async Task UpdateNotificationsPreferences(string pageShortName,
            UpdateNotificationsPreferencesRequest updateRequest)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/notifications";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, updateRequest);
        }

        public async Task UpdateFundraisingPageSummary(string pageShortName,
            UpdateFundraisingPageSummaryRequest updateRequest)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/summary";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, updateRequest);
        }

        public async Task<IEnumerable<Update>> GetFundraisingPageUpdates(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/updates";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Update[]>(request);
        }

        public async Task UpdateFundraisingPageStory(string pageShortName, string story)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/pagestory";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, new UpdateFundraisingPageStoryRequest {Story = story});
        }

        public async Task<GetFundraisingPageAttributionResponse> GetFundraisingPageAttribution(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/attribution";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetFundraisingPageAttributionResponse>(request);
        }

        public async Task<IEnumerable<string>> GetSuggestedPageNames(string preferredName)
        {
            var resource = $"/v1/fundraising/pages/suggest?preferredName={Uri.EscapeDataString(preferredName)}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            var result = await Execute<SuggestedNames>(request);
            return result.Names;
        }

        public async Task<IEnumerable<FundraiserSearchResult>> FundraiserSearch(string q, int? page, int? pageSize,
            int? causeId, int? eventId, int? charityId, int? designId, string status, DateTime? startDateRange, DateTime? endDateRange)
        {
            var resource =
                $"/v1/fundraising/search?q={Uri.EscapeDataString(q)}&page={page?.ToString() ?? string.Empty}&pageSize={pageSize?.ToString() ?? string.Empty}" +
                $"&causeId={causeId?.ToString() ?? string.Empty}&eventId={eventId?.ToString() ?? string.Empty}&charityId={charityId?.ToString() ?? string.Empty}" +
                $"&status={Uri.EscapeDataString(status)}&eventDateRange={FormatDateRange(startDateRange, endDateRange)}";

            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            var result = await Execute<FundraiserSearchResponse>(request);
            return result.SearchResults;
        }

        public async Task<bool> PageExists(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await ResourceExists(request);
        }

        public async Task<IEnumerable<FundraisingPageSummary>> GetFundraisingPages()
        {
            var resource = "/v1/fundraising/pages";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<FundraisingPageSummary[]>(request);
        }

        public async Task<GetFundraisingPageResponse> GetFundraisingPageDetails(int pageId)
        {
            var resource = $"/v1/fundraising/pagebyid/{pageId}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetFundraisingPageResponse>(request);
        }

        public async Task<GetFundraisingPageResponse> GetFundraisingPageDetails(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetFundraisingPageResponse>(request);
        }

        public async Task<GetFundraisingPageDonationsResponse> GetFundraisingPageDonations(string pageShortName, int pageNumber = 1, int pageSize = 20)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/donations?pageNum={pageNumber}&pageSize={pageSize}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetFundraisingPageDonationsResponse>(request);
        }

        public async Task<GetFundraisingPageDonationsResponse> GetFundraisingPageDonationsByReference(string pageShortName, string reference)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/donations/ref/{reference}";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<GetFundraisingPageDonationsResponse>(request);
        }

        public async Task UpdateFundraisingPage(string pageShortName, string storySupplement)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}";
            var payload = new UpdateFundraisingPageRequest
            {
                PageShortName = pageShortName,
                StorySupplement = storySupplement
            };
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request, payload);
        }

        public async Task UpdateFundraisingPageAttribution(string pageShortName, string attribution)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/attribution";
            var payload = new UpdateFundraisingPageAttributionRequest {Attribution = attribution};
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, payload);
        }

        public async Task DeleteFundraisingPageAttribution(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/attribution";
            var request = new HttpRequestMessage(HttpMethod.Delete, resource);
            await Execute(request);
        }

        public async Task AppendToFundraisingPageAttribution(string pageShortName, string attribution)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/attribution";
            var payload = new UpdateFundraisingPageAttributionRequest { Attribution = attribution };
            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            await Execute(request, payload);
        }

        public async Task UploadImage(string pageShortName, byte[] imageData, string contentType, string caption = "")
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/images";
            if (!string.IsNullOrWhiteSpace(caption))
            {
                resource += "?caption=" + Uri.EscapeUriString(caption);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, resource)
            {
                Content = new ByteArrayContent(imageData)
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            await Execute(request);
        }

        public async Task UploadImage(string pageShortName, FileInfo image, string contentType, string caption = "")
        {
            var data = File.ReadAllBytes(image.FullName);
            await UploadImage(pageShortName, data, $"image/{image.Extension.Substring(1)}", caption);
        }


        public async Task UploadDefaultImage(string pageShortName, byte[] imageData, string contentType, string caption)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/images/default";
            if (!string.IsNullOrWhiteSpace(caption))
            {
                resource += "?caption=" + Uri.EscapeUriString(caption);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, resource)
            {
                Content = new ByteArrayContent(imageData)
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            await Execute(request);
        }

        public async Task UploadDefaultImage(string pageShortName, FileInfo image, string contentType, string caption)
        {
            var data = File.ReadAllBytes(image.FullName);
            await UploadDefaultImage(pageShortName, data, $"image/{image.Extension.Substring(1)}", caption);
        }

        public async Task RegisterFundraisingPage(PageRegistration pageRegistration)
        {
            var resource = $"/v1/fundraising/pages";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, pageRegistration);
        }

        public async Task AddImageToFundraisingPage(string pageShortName, Uri imageUri, bool isDefault,
            string caption = "")
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/images";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            var payload = new AddImageToPageRequest
            {
                Caption = caption,
                IsDefault = isDefault,
                Url = imageUri.ToString()
            };
            await Execute(request, payload);
        }

        public async Task<IEnumerable<FundraisingPageImage>> GetImagesForFundraisingPage(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/images";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<FundraisingPageImage[]>(request);
        }

        public async Task AddVideoToFundraisingPage(string pageShortName, Uri videoUri, bool isDefault, string caption = "")
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/videos";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            var payload = new AddVideoToPageRequest
            {
                Caption = caption,
                IsDefault = isDefault,
                Url = videoUri.ToString()
            };
            await Execute(request, payload);
        }

        public async Task<IEnumerable<FundraisingPageVideo>> GetVideosForFundraisingPage(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/videos";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<FundraisingPageVideo[]>(request);
        }

        public async Task<IEnumerable<Currency>> GetValidCurrencyCodes()
        {
            var resource = "/v1/fundraising/currencies";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<Currency[]>(request);
        }

        public async Task UpdateFundraisingPageTarget(string pageShortName, FundraisingTarget target)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/target";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request, target);
        }

        public async Task UpdateOfflineAmount(string pageShortName, decimal amount)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/offline";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            var payload = new OfflineAmount {Amount = amount};
            await Execute(request, payload);
        }

        public async Task ExtendFundraisingPage(string pageShortName, DateTime expiryDate)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/extend";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            var payload = new ExtendFundraisingPageRequest {ExpiryDate = expiryDate};
            await Execute(request, payload);
        }

        public async Task CloseFundraisingPage(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/close";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request);
        }

        public async Task ReopenFundraisingPage(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/reopen";
            var request = new HttpRequestMessage(HttpMethod.Put, resource);
            await Execute(request);
        }

        public async Task<PageNotificationPreferences> GetNotificationPreferences(string pageShortName)
        {
            var resource = $"/v1/fundraising/pages/{pageShortName}/notifications";
            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            return await Execute<PageNotificationPreferences>(request);
        }

        private static string FormatDateRange(DateTime? start, DateTime? end)
        {
            var s = (start ?? DateTime.MinValue);
            var e = (end ?? DateTime.MaxValue);
            return Uri.EscapeDataString($"{s.Year}-{s.Month}-{s.Day};{e.Year}-{e.Month}-{e.Day}");
        }
    }
}
