namespace whatsapp_webhook.Models
{
    public class TwilioMessageStatus
    {
        public string ChannelPrefix { get; set; }
        public string ApiVersion { get; set; }
        public string MessageStatus { get; set; }
        public string SmsSid { get; set; }
        public string SmsStatus { get; set; }
        public string ErrorCode { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string MessageSid { get; set; }

        public string ErrorMessage { get; set; }
        public string AccountSid { get; set; }
        public string ChannelToAddress { get; set; }
        public string Body { get; set; }
        public string httpResponse { get; set; }
    }
} 