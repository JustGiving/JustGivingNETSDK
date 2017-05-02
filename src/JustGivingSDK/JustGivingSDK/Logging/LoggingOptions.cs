﻿namespace JustGivingSDK.Logging
{
    public class LoggingOptions
    {
        protected LoggingOptions()
        {
            LogAllMessageContent = false;
            LogFailedRequests = true;
            LogSuccessfulRequests = false;
        }

        /// <summary>
        /// Does what you'd expect. Any sensitive data in requests or responses will be logged.
        /// </summary>
        public static LoggingOptions LogEverything => new LoggingOptions
        {
            LogAllMessageContent = true,
            LogFailedRequests = true,
            LogSuccessfulRequests = true,
        };

        /// <summary>
        /// No logging.
        /// </summary>
        public static LoggingOptions Silent => new LoggingOptions
        {
            LogAllMessageContent = false,
            LogFailedRequests = false,
            LogSuccessfulRequests = false,
        };

        /// <summary>
        /// Minimal information about failing HTTP requests will be logged only. Sensitive data will not be logged.
        /// </summary>
        public static LoggingOptions Default => new LoggingOptions
        {
            LogAllMessageContent = false,
            LogFailedRequests = true,
            LogSuccessfulRequests = false,
        };


        /// <summary>
        /// If enabled, all HTTP request and response message content will be logged. This may include sensitive information. Default is false.
        /// </summary>
        public bool LogAllMessageContent { get; set; }

        /// <summary>
        /// If enabled, the API client will log any request which returns a response status which indicates a problem. Default is true.
        /// </summary>
        public bool LogFailedRequests { get; set; }

        /// <summary>
        /// If enabled, the API client will log any request which returns a successful response status. Default is false.
        /// </summary>
        public bool LogSuccessfulRequests { get; set; }
    }
}
