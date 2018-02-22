using System;
using System.Diagnostics;
using System.Threading;
using JustGivingSDK;
using JustGivingSDK.Contracts.Account;
using JustGivingSDK.Contracts.Fundraising;
using JustGivingSDK.Security.Basic;

namespace SampleClient
{
    /// <summary>
    /// This sample app will create a new user account and then create a fundraising page using the newly created credential.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            const string appId = "e488ce85";
            var client = new JustGivingApiClient(appId);

            client.UseSandbox();
            client.LogEverything();

			//If you need to set a proxy, do so like this
			//client.UseProxy(new WebProxy()); 

            var password = Guid.NewGuid().ToString();
            var email = $"example-{Guid.NewGuid():N}@justgiving.com";

			client.Accounts.CreateAccount(new RegisterAccountRequest()
            {
                FirstName = "Joe",
                LastName = "bloggs",
                Email = email,
                AcceptTermsAndConditions = true,
                Password = password,
                Reference = "SDKSample"
            });

            Thread.Sleep(3000);

            client = new JustGivingApiClient(appId, new BasicCredential(email, password));
            client.UseSandbox();
            client.LogEverything();

            var pageName = "Sdk-test-" + DateTime.Now.ToFileTimeUtc();
            Console.WriteLine($"Creating fundraising page with page name '{pageName}'");

            var createPage = new PageRegistration
            {
                ActivityType = ActivityTypes.Birthday,
                CharityId = 2050,
                PageShortName = pageName,
                PageTitle = "My Sandbox Page",
                EventName = "My Birthday",
                EventDate = DateTime.Now.AddMonths(1).Date,
                PageStory = "I created this page using the JustGiving SDK",
                PageSummaryWhat = "What",
                PageSummaryWhy = "Why",
                Currency = "GBP",
                ExpiryDate = DateTime.Now.AddDays(3),
                Attribution = "Joe Bloggs",
                CharityFunded = false,
                CharityOptIn = true
            };

            client.Fundraising.RegisterFundraisingPage(createPage);

            Thread.Sleep(5000);

            Process.Start($"https://v3-sandbox.justgiving.com/{pageName}");

            Console.ReadKey();
        }
    }
}
