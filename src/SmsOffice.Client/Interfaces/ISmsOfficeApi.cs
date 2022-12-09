using RestEase;
using SmsOffice.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsOffice.Client.Interfaces
{
    public interface ISmsOfficeApi
    {
        [Get("v2/send")]
        Task<SendSmsResult> SendSms([Query] string key, [Query] string destination, [Query] string sender, [Query] string content);

        [Get("getBalance")]
        Task<int> GetBalance([Query] string key);
    }
}
