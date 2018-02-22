using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JustGivingSDK.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JustGivingSDK.Clients
{
    public abstract class ClientBase
    {
        private readonly HttpClient _http;
        private readonly ApiRequestLogger _logger;

        protected ClientBase(HttpClient http, ApiRequestLogger logger)
        {
            _http = http;
            _logger = logger;
        }

        protected async Task<bool> ResourceExists(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await _http.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.NotFound) return false;
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception e)
            {
                _logger.Error("An error occurred while executing an HTTP request", e);
                if (response != null)
                {
                    var text = await response.Content.ReadAsStringAsync();
                    _logger.Error(text);
                }
                
                throw;
            }
            finally
            {
                _logger.LogRequest(request, response);
            }
        }

        protected async Task Execute(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            string responseContent = "";
            try
            {
                response = await _http.SendAsync(request);
                responseContent = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                _logger.Error("An error occurred while executing an HTTP request", e);
                _logger.Error(responseContent);
                throw;
            }
            finally
            {
                _logger.LogRequest(request, response);
            }
        }

        protected async Task<T> Execute<T>(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _http.SendAsync(request);
                response.EnsureSuccessStatusCode();
				var responseContent = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(responseContent);
			}
            catch (Exception e)
            {
                _logger.Error("An error occurred while executing an HTTP request", e);
                if (response != null)
                {
                    var text = await response.Content.ReadAsStringAsync();
                    _logger.Error(text);
                }
                throw;
            }
            finally
            {
                _logger.LogRequest(request, response);
            }
        }

        protected async Task<TResponse> Execute<TResponse, TRequestContent>(HttpRequestMessage request,
            TRequestContent content)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var jsonString = JsonConvert.SerializeObject(content, jsonSerializerSettings);
            var json = new StringContent(jsonString, Encoding.UTF8, "application/json");
            _logger.LogJsonRequest(jsonString);
            request.Content = json;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await Execute<TResponse>(request);
        }

        protected async Task Execute<TRequestContent>(HttpRequestMessage request, TRequestContent content)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var jsonString = JsonConvert.SerializeObject(content, jsonSerializerSettings);
            var json = new StringContent(jsonString, Encoding.UTF8, "application/json");
            request.Content = json;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            _logger.LogJsonRequest(jsonString);
            await Execute(request);
        }
    }
}
