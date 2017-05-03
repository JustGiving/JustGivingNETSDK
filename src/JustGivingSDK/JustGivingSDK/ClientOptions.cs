using System;
using System.Net;
using System.Reflection;
using JustGivingSDK.Http;
using JustGivingSDK.Logging;
using JustGivingSDK.Security.Basic;
using JustGivingSDK.Security.OAuth;

namespace JustGivingSDK
{
    public class ClientOptions
    {
        private readonly string _appId;
        private string _sdkVersion;

        public ClientOptions(string appId)
        {
            _appId = appId;
            LoggingOptions = LoggingOptions.Default;
            Endpoint = Endpoints.Production;
        }

        public ClientOptions(string appId, string applicationKey)
        {
            _appId = appId;
            ApplicationKey = applicationKey;
            LoggingOptions = LoggingOptions.Default;
            Endpoint = Endpoints.Production;
        }

		public ClientOptions(string appId, IWebProxy proxy)
		{
			_appId = appId;
			Proxy = proxy;
			LoggingOptions = LoggingOptions.Default;
			Endpoint = Endpoints.Production;
		}

        public string AppId => _appId;

        public Uri Endpoint { get; set; }

		public IWebProxy Proxy {get;set;}

        public OAuthAccessToken OAuthAccessToken { get; set; }

        public BasicCredential BasicAuthSettings { get; set; }

        public AuthorizationMode AuthorizationMode { get; set; }
        /// <summary>
        /// If enabled, all requests to the API will include ?debug=true as a query string parameter, which asks the server to include extended debugging information in any error responses.
        /// </summary>
        public bool RequestDebuggingInfo { get; set; }

        public string ApplicationKey { get; }

        public LoggingOptions LoggingOptions { get; set; }

        public string SdkVersion
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_sdkVersion))
                {
                    _sdkVersion =
                        Assembly.GetAssembly(GetType()).GetName().Version.ToString();
                }

                return _sdkVersion;
            }
        }
    }
}