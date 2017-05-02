using System;

namespace JustGivingSDK.Http
{
    public static class Endpoints
    {
        private const string ApiSandbox = "https://api.sandbox.justgiving.com";
        private const string ApiProduction = "https://api.justgiving.com";
        public static Uri Sandbox => new Uri(ApiSandbox);
        public static Uri Production => new Uri(ApiProduction);
    }
}
