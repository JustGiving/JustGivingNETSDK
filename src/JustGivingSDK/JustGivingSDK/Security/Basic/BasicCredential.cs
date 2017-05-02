using System;

namespace JustGivingSDK.Security.Basic
{
    public class BasicCredential
    {
        public BasicCredential(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty");
            }

            Username = username;
            Password = password;
        }

        public string Username { get; }

        public string Password { get; }

        public string Base64Encode()
        {
            var plainText = Username + ":" + Password;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
