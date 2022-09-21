using Microsoft.Extensions.Options;
using SmsOffice.Client.Extensions;
using SmsOffice.Client.Interfaces;
using SmsOffice.Client.Models;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Web;

namespace SmsOffice.Client
{
    public class SmsOfficeClient : ISmsOfficeClient
    {
        private readonly SmsOfficeClientOptions _options;
        private readonly HttpClient _httpClient;


        public SmsOfficeClient(
           HttpClient httpClient,
           IOptions<SmsOfficeClientOptions> options)
        {
            _options = options.Value;
            _httpClient = httpClient;
        }

        public async Task<SendSmsResult> SendSms(string senderName, string receiverPhoneNumber, string text)
        {
            if (string.IsNullOrEmpty(senderName))
            {
                throw new ArgumentNullException(nameof(senderName));
            }

            if (string.IsNullOrEmpty(receiverPhoneNumber))
            {
                throw new ArgumentNullException(nameof(receiverPhoneNumber));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var queryParams = new Dictionary<string, string>
            {
                { "key", _options.ApiKey },
                { "destination", receiverPhoneNumber.ToNormalizedPhoneNumber().ToUrlEncoded() },
                { "sender", senderName.ToUrlEncoded() },
                { "content", text.ToUrlEncoded() }
            };

            var endpoint = $"{_options.BaseUrl}/v2/send?{string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))}";

            return await MakeHttpGetRequest<SendSmsResult>(endpoint);
        }

        public async Task<int> GetBalance()
        {
            var endpoint = $"{_options.BaseUrl}/getBalance?key={_options.ApiKey}";

            return await MakeHttpGetRequest<int>(endpoint);
        }

        private async Task<T> MakeHttpGetRequest<T>(string endpoint)
        {
            var httpResponseMessage = await _httpClient.GetAsync(endpoint);

            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<T>();
        }
    }
}