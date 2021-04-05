using Microsoft.Extensions.Caching.Memory;
using RestSharp;
using RestSharp.Authenticators;
using RoutingApi.Application.Common.Interfaces;
using RoutingApi.Application.Common.Models;
using System;
using System.Net;
using System.Security.Authentication;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoutingApi.Infrastructure.RestSharp.RestClient
{
    public class RestSharpUtils : IRestSharpUtils
    {
        private readonly IMemoryCache _cache;
        private readonly global::RestSharp.RestClient _restClient;

        public RestSharpUtils(IMemoryCache cache)
        {
            _cache = cache;
            _restClient = new global::RestSharp.RestClient();
        }

        public async Task<string> GetRoute(OneToOneRequestDto requestDto, string userName, string password, string baseUri, string endpoint)
        {
            _restClient.BaseUrl = new Uri(baseUri);
            var accessToken = await GetTokenCached(userName, password, baseUri, "api/Identity/GenerateToken");

            _restClient.Authenticator = new JwtAuthenticator(accessToken);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var requestData = JsonSerializer.Serialize(requestDto, options);
            var request = new RestRequest(endpoint, Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json; charset=utf-8", requestData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ClearCache();
                throw new UnauthorizedAccessException("Token expired");
            }

            if (response.StatusCode != HttpStatusCode.Unauthorized && response.StatusCode != HttpStatusCode.OK)
                throw new InvalidCredentialException(response.Content);

            return response.Content;
        }

        public async Task<string> AddTaskToRoute(OneToOneRequestDto requestDto, string userName, string password, string baseUri, string endpoint)
        {
            _restClient.BaseUrl = new Uri(baseUri);
            var accessToken = await GetTokenCached(userName, password, baseUri, "api/Identity/GenerateToken");

            _restClient.Authenticator = new JwtAuthenticator(accessToken);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var requestData = JsonSerializer.Serialize(requestDto, options);
            var request = new RestRequest(endpoint, Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json; charset=utf-8", requestData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ClearCache();
                throw new UnauthorizedAccessException("Token expired");
            }

            if (response.StatusCode != HttpStatusCode.Unauthorized && response.StatusCode != HttpStatusCode.OK)
                throw new InvalidCredentialException(response.Content);

            return response.Content;
        }


        private async Task<string> GetToken(string userName, string password, string baseUrl, string endpoint)
        {
            _restClient.BaseUrl = new Uri(baseUrl);
            var requestParams = new LoginDto
            {
                UserName = userName,
                Password = password
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            var requestData = JsonSerializer.Serialize(requestParams, options);
            var request = new RestRequest(endpoint, Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json; charset=utf-8", requestData, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            IRestResponse response = await _restClient.ExecuteAsync(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidCredentialException(response.Content);

            return response.Content.Replace("\"", "");
        }

        public async Task<string> GetTokenCached(string userName, string password, string baseUrl, string endpoint)
        {
            //1: cache key
            const string key = "DistanceApi_AccessToken";

            //2: We will try to get the Cache data
            //If the data is present in cache
            //The condition will be true else it is false
            if (_cache.TryGetValue(key, out string result)) return result;

            //3.fetch the data from the object
            result = await GetToken(userName, password, baseUrl, endpoint);
            //4.Save the received data in cache
            _cache.Set(key, result,
                new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1)));

            return result;
        }

        private void ClearCache()
        {
            _cache.Remove("DistanceApi_AccessToken");
        }
    }
}