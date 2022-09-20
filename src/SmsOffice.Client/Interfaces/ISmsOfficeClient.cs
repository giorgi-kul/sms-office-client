using SmsOffice.Client.Models;

namespace SmsOffice.Client.Interfaces
{
    public interface ISmsOfficeClient
    {
        Task<SendSmsResult> SendSms(string senderName, string receiverPhoneNumber, string text);

        Task<int> GetBalance();
    }
}
