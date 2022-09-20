namespace SmsOffice.Client.Models
{
    public class SendSmsResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Output { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}