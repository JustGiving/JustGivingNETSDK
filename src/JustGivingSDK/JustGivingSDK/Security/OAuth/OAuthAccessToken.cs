using System;

namespace JustGivingSDK.Security.OAuth
{
    public class OAuthAccessToken
    {
        public OAuthAccessToken(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Access token cannot be empty");
            }

            Value = value;
        }

        public string Value { get; }
    }
}
