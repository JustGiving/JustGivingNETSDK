using System;
using System.Net.Http;

namespace JustGivingSDK.Logging
{
    public class ApiRequestLogger
    {
        private readonly ILogProvider _log;

        private readonly ClientOptions _options;
        public ApiRequestLogger(ClientOptions options, ILogProvider log)
        {
            _options = options;
            _log = log;
        }

        /// <summary>
        /// Every time the SDK communicates with the API (or tries to), we can generate a nice log entry to show us exactly what happened and why. 
        /// Depending on the configuration options, this might log all requests, or just the ones which fail. The level of detail can also be
        /// configured depending on different development / production scenarios and PCI considerations.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public void LogRequest(HttpRequestMessage request, HttpResponseMessage response)
        {
            bool success = false;
            bool serverError = false;

            if (response != null)
            {
                success = (int)response.StatusCode < 400 && (int)response.StatusCode > 0;
                serverError = (int)response.StatusCode >= 500;
            }

            if ((_options.LoggingOptions.LogSuccessfulRequests && success))
            {
                var message = FormatLogMessage(request, response);
                _log.Info(message);
            }
            else if ((_options.LoggingOptions.LogFailedRequests && !success))
            {
                var message = FormatLogMessage(request, response);

                if (serverError)
                {
                    _log.Error(message);
                }
                else
                {
                    _log.Warn(message);
                }
            }
        }

        public void LogJsonRequest(string json)
        {
            if (_options.LoggingOptions.LogAllMessageContent)
            {
                _log.Info("[Json]");
                _log.Info(json);
            }
        }

        public void Error(string message)
        {
            _log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }


        private string FormatLogMessage(HttpRequestMessage request, HttpResponseMessage response)
        {
            var message = FormatRequestLogMessage(request);

            if (_options.LoggingOptions.LogAllMessageContent)
            {
                message += FormatExtendedRequestLogMessage(request);
            }

            message += FormatResponseLogMessage(response);

            return message;
        }


        private static string FormatResponseLogMessage(HttpResponseMessage response)
        {
            var message = string.Empty;

            if (response == null)
            {
                message += "\r\n[HttpResponse] No response\r\n";
                return message;
            }

            message += "\r\n[HttpResponse]";
            
            foreach (var header in response.Headers)
            {
                foreach (var value in header.Value)
                {
                    message += $"\r\n[HttpHeader] {header.Key}: {value}\r\n";
                }
            }

            message += $"\r\n[HttpStatus] {(int)response.StatusCode} {response.StatusCode}\r\n";

            return message;
        }


        private string FormatRequestLogMessage(HttpRequestMessage request)
        {
            var message = "\r\n[HttpRequest] ";
            message += $"{request.Method} {request.RequestUri}\r\n";
            message += "[AuthorizationMode] " + _options.AuthorizationMode + "\r\n";
            message += "[AppId] " + _options.AppId + "\r\n";
            message += "[ApplicationKey?] " + (string.IsNullOrWhiteSpace(_options.ApplicationKey) ? "No\r\n" : "Yes\r\n");

            return message;
        }

        private static string FormatExtendedRequestLogMessage(HttpRequestMessage request)
        {
            var message = string.Empty;
            foreach (var header in request.Headers)
            {
                foreach (var value in header.Value)
                {
                    message += $"\r\n[HttpHeader] {header.Key}: {value}\r\n";
                }
            }

            return message;
        }
    }
}
