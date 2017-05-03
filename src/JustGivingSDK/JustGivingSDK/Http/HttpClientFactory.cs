using System;
using System.Net.Http;
using System.Net.Http.Headers;
using JustGivingSDK.Security.OAuth;

namespace JustGivingSDK.Http
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient(ClientOptions options);
    }

    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(ClientOptions options)
        {
			var handler = new HttpClientHandler();

			if (options.Proxy != null)
				handler.Proxy = options.Proxy;
			       
			var client = new HttpClient(handler)
            {
                BaseAddress = options.Endpoint
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            switch (options.AuthorizationMode)
            {
                case AuthorizationMode.OAuth:
                    if (options.OAuthAccessToken == null)
                    {
                        throw new InvalidOperationException("Client is configured for OAuth authorization but no access token has been provided");
                    }

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.OAuthAccessToken.Value);

                    break;
                case AuthorizationMode.Basic:
                    if (options.BasicAuthSettings == null)
                    {
                        throw new InvalidOperationException("Client is configured for Basic authentication but no user credential has been provided");
                    }

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", options.BasicAuthSettings.Base64Encode());
                    break;
            }

            if (!string.IsNullOrWhiteSpace(options.ApplicationKey))
            {
                client.DefaultRequestHeaders.Add("x-application-key", options.ApplicationKey);
            }

            client.DefaultRequestHeaders.Add("x-app-id", options.AppId);
            client.DefaultRequestHeaders.Add("x-justgiving-sdk-version", options.SdkVersion);

            return client;
        }
    }
}
