using Microsoft.Extensions.Options;
using RestEase;
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
        private readonly ISmsOfficeApi _api;


        public SmsOfficeClient(
           IOptions<SmsOfficeClientOptions> options)
        {
            _options = options.Value;
            _api = RestClient.For<ISmsOfficeApi>(_options.BaseUrl);
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

            return await _api.SendSms(_options.ApiKey, receiverPhoneNumber.ToNormalizedPhoneNumber().ToUrlEncoded(), senderName.ToUrlEncoded(), text.ToUrlEncoded());
        }

        public async Task<int> GetBalance()
        {
            return await _api.GetBalance(_options.ApiKey);
        }
    }
}