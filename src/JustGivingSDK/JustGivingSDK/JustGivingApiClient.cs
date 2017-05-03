using System;
using System.Net;
using System.Net.Http;
using JustGivingSDK.Clients.Account;
using JustGivingSDK.Clients.Campaign;
using JustGivingSDK.Clients.Donation;
using JustGivingSDK.Clients.Event;
using JustGivingSDK.Clients.Fundraising;
using JustGivingSDK.Clients.Leaderboard;
using JustGivingSDK.Clients.Project;
using JustGivingSDK.Clients.Team;
using JustGivingSDK.Http;
using JustGivingSDK.Logging;
using JustGivingSDK.Security.Basic;
using JustGivingSDK.Security.OAuth;

namespace JustGivingSDK
{
    public class JustGivingApiClient
    {
        private readonly ClientOptions _options;
        private ILogProvider _logProvider;
        private ApiRequestLogger _logger;
        private HttpClient _http;
        private IHttpClientFactory _httpClientFactory;
        private IAccountClient _accountClient;
        private IFundraisingClient _fundraisingClient;
        private IDonationClient _donationClient;
        private ICampaignClient _campaignClient;
        private IEventClient _eventClient;
        private ILeaderboardClient _leaderboardClient;
        private IProjectClient _projectClient;
        private ITeamClient _teamClient;

        /// <summary>
        /// Creates an Api client which uses an OAuth2 access token for authorization. This is the preferred method of authenticating, as it offers the best security and will work with all JustGiving user accounts.
        /// </summary>
        /// <param name="appId">The Application ID you received when you registered your app on the JustGiving developer portal.</param>
        /// <param name="applicationKey">The Application Key you created for your app on the JustGiving developer portal. You must include it here for your app to work.</param>
        /// <param name="oauthAccessToken">A valid OAuth2 access token issued by identity.justgiving.com</param>
        public JustGivingApiClient(string appId, string applicationKey, OAuthAccessToken oauthAccessToken)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("You must provide an appId");
            }

            if (string.IsNullOrWhiteSpace(applicationKey))
            {
                throw new ArgumentException("You must provide a Application Key when using OAuth. To generate an Application Key for your app, log in to the JustGiving developer portal.");
            }

            _options = new ClientOptions(appId, applicationKey)
            {
                AuthorizationMode = AuthorizationMode.OAuth,
                Endpoint = Endpoints.Production,
                OAuthAccessToken = oauthAccessToken,
                LoggingOptions = LoggingOptions.Default
            };
        }

        /// <summary>
        /// Creates an Api client which uses a username and password for Basic authorization. This method carries security risks and will not be available to JustGiving users with different user account types (such as Facebook).
        /// </summary>
        /// <param name="appId">The Application ID you received when you registered your app on the JustGiving developer portal.</param>
        /// <param name="basicAuthCredential">The username and password of a registered JustGiving user.</param>
        public JustGivingApiClient(string appId, BasicCredential basicAuthCredential)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("You must provide an appId");
            }

            if (basicAuthCredential == null)
            {
                throw new ArgumentException("You must provide a credential");
            }

            _options = new ClientOptions(appId)
            {
                AuthorizationMode = AuthorizationMode.Basic,
                Endpoint = Endpoints.Production,
                BasicAuthSettings = basicAuthCredential,
                LoggingOptions = LoggingOptions.Default
            };
        }

        /// <summary>
        /// Creates an Api client which uses a username and password for Basic authorization. This method carries security risks and will not be available to JustGiving users with different user account types (such as Facebook).
        /// </summary>
        /// <param name="appId">The Application ID you received when you registered your app on the JustGiving developer portal.</param>
        /// <param name="applicationKey">If you created a Application Key for this app in the Developer Portal, you must include it here for your app to work.</param>
        /// <param name="basicAuthCredential">The username and password of a registered JustGiving user.</param>
        public JustGivingApiClient(string appId, string applicationKey, BasicCredential basicAuthCredential)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("You must provide an appId");
            }

            if (string.IsNullOrWhiteSpace(applicationKey))
            {
                throw new ArgumentException("Application Key cannot be empty. If you have not created an Application Key for your application, use the overloaded version of this constructor.");
            }

            if (basicAuthCredential == null)
            {
                throw new ArgumentException("You must provide a credential");
            }

            _options = new ClientOptions(appId, applicationKey)
            {
                AuthorizationMode = AuthorizationMode.Basic,
                Endpoint = Endpoints.Production,
                BasicAuthSettings = basicAuthCredential,
                LoggingOptions = LoggingOptions.Default
            };
        }

        /// <summary>
        /// Creates an anonymous Api client using common default settings. This client will not be able to access protected Api resources which require authentication.
        /// </summary>
        /// <param name="appId">The Application ID you received when you registered your app on the JustGiving developer portal.</param>
        public JustGivingApiClient(string appId)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("You must provide an appId");
            }

            _options = new ClientOptions(appId)
            {
                AuthorizationMode = AuthorizationMode.Anonymous,
                Endpoint = Endpoints.Production,
                LoggingOptions = LoggingOptions.Default
            };
        }

        /// <summary>
        /// Creates an anonymous Api client using common default settings. This client will not be able to access protected Api resources which require authentication.
        /// </summary>
        /// <param name="appId">The Appliaction ID you received when you registered your app on the JustGiving developer portal.</param>
        /// <param name="applicationKey">If you created a Application Key for this app in the Developer Portal, you must include it here for your app to work.</param>
        public JustGivingApiClient(string appId, string applicationKey)
        {
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("You must provide an appId");
            }

            if (string.IsNullOrWhiteSpace(applicationKey))
            {
                throw new ArgumentException("Application Key cannot be empty. If you have not created an Application Key for your application, use the overloaded version of this constructor.");
            }

            _options = new ClientOptions(appId, applicationKey)
            {
                AuthorizationMode = AuthorizationMode.Anonymous,
                Endpoint = Endpoints.Production,
                LoggingOptions = LoggingOptions.Default
            };
        }

        /// <summary>
        /// Creates an API client using custom configuration settings. For advanced use.
        /// </summary>
        /// <param name="options"></param>
        public JustGivingApiClient(ClientOptions options)
        {
            _options = options;
        }

        /// <summary>
        /// Tells the API client to use the JustGiving sandbox environment, and turns on verbose logging of all HTTP requests and responses.
        /// </summary>
        public void UseSandbox()
        {
            _options.Endpoint = Endpoints.Sandbox;
        }

        public void UseCustomEndpoint(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Endpoint URI cannot be null");
            }

            _options.Endpoint = uri;
        }

        /// <summary>
        /// Tells the API client to write extremely detailed log information about every API request and response. For development & troubleshooting scenarios.
        /// </summary>
        public void LogEverything()
        {
            _options.LoggingOptions.LogAllMessageContent = true;
            _options.LoggingOptions.LogFailedRequests = true;
            _options.LoggingOptions.LogSuccessfulRequests = true;
            _options.RequestDebuggingInfo = true;
        }

        /// <summary>
        /// Tells the API client the use the JustGiving production (live) environment, with some minimal error logging.
        /// </summary>
        public void UseProduction()
        {
            _options.Endpoint = Endpoints.Production;
        }

		/// <summary>
		/// Tells the client to use the provided proxy for all calls
		/// </summary>
		public void UseProxy(IWebProxy proxy)
		{
			_options.Proxy = proxy;
		}

        /// <summary>
        /// Gets or sets the underlying log infrastructure. Defaults to the Log4NetLogProvider.
        /// </summary>
        public ILogProvider LogProvider
        {
            get { return _logProvider ?? (_logProvider = new ConsoleLogger()); }
            set { _logProvider = value; }
        }

        public IHttpClientFactory HttpClientFactory
        {
            get { return _httpClientFactory ?? (_httpClientFactory = new Http.HttpClientFactory()); }
            set { _httpClientFactory = value; }
        }

        /// <summary>
        /// API resources for working with user accounts and personalised information.
        /// </summary>
        public IAccountClient Accounts
        {
            get
            {
                if (_accountClient == null)
                {
                    _accountClient = new AccountClient(this.Http, this.Logger);
                }

                return _accountClient;
            }
        }

        /// <summary>
        /// API resources for working with fundraising pages.
        /// </summary>
        public IFundraisingClient Fundraising
        {
            get
            {
                if (_fundraisingClient == null)
                {
                    _fundraisingClient = new FundraisingClient(this.Http, this.Logger);
                }

                return _fundraisingClient;
            }
        }

        /// <summary>
        /// API resources for working with donations.
        /// </summary>
        public IDonationClient Donations
        {
            get
            {
                if (_donationClient == null)
                {
                    _donationClient = new DonationClient(this.Http, this.Logger);
                }

                return _donationClient;
            }
        }

        /// <summary>
        /// Resources for working with specific fundraising campaigns
        /// </summary>
        public ICampaignClient Campaigns
        {
            get
            {
                if (_campaignClient == null)
                {
                    _campaignClient = new CampaignClient(this.Http, this.Logger);
                }

                return _campaignClient;
            }
        }

        /// <summary>
        /// Resources for working with fundraising events
        /// </summary>
        public IEventClient Events
        {
            get
            {
                if (_eventClient == null)
                {
                    _eventClient = new EventClient(this.Http, this.Logger);
                }

                return _eventClient;
            }
        }

        /// <summary>
        /// Resources for working with charity leaderboards and event leaderboards
        /// </summary>
        public ILeaderboardClient Leaderboards
        {
            get
            {
                if (_leaderboardClient == null)
                {
                    _leaderboardClient = new LeaderboardClient(this.Http, this.Logger);
                }

                return _leaderboardClient;
            }
        }

        /// <summary>
        /// Resources for working with global projects
        /// </summary>
        public IProjectClient ProjectClient
        {
            get
            {
                if (_projectClient == null)
                {
                    _projectClient = new ProjectClient(this.Http, this.Logger);
                }

                return _projectClient;
            }
        }

        public ITeamClient Teams
        {
            get
            {
                if (_teamClient == null)
                {
                    _teamClient = new TeamClient(this.Http, this.Logger);
                }

                return _teamClient;
            }
        }

        private HttpClient Http => _http ?? (_http = HttpClientFactory.CreateClient(_options));

        protected ApiRequestLogger Logger => _logger ?? (_logger = new ApiRequestLogger(_options, LogProvider));
    }
}
