using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML;
using Twilio.AspNet.Core;
using whatsapp_webhook.Models;

namespace whatsapp_webhook.Controllers
{
    [ApiController]
    [Route("api/twilio")]
    public class TwilioWebhookController : ControllerBase
    {
        // Webhook for incoming messages
        [HttpPost("webhook")]
        //json
        //public IActionResult Webhook([FromBody] TwilioMessageWebhook model)
        //x-www-form-urlencoded
        public IActionResult Webhook([FromForm] TwilioMessageWebhook model)
        {
            if (model == null)
            {
                return BadRequest("Invalid payload");
            }
            Console.WriteLine($"📩 Received Message from {model.From}: {model.Body}");
            return Ok();
        }

        // Status callback for message updates (sent, delivered, failed)
        [HttpPost("status")]
        public IActionResult StatusCallback([FromForm] TwilioMessageStatus model)
        {
            if (model == null)
            {
                return BadRequest("Invalid payload");
            }
            Console.WriteLine($"📬 Message to {model.To} status: {model.SmsStatus}, SID: {model.MessageSid}, ErrorCode: {model.ErrorCode}, ErrorMessage: {model.ErrorMessage} ");
            return Ok();
        }

        // Fallback if webhook fails
        [HttpPost("fallback")]
        public IActionResult Fallback([FromForm] TwilioMessageWebhook model)
        {
            if (model == null)
            {
                return BadRequest("Invalid payload");
            }
            Console.WriteLine($"❗Fallback triggered: From {model.From}, SID: {model.MessageSid}");
            return Ok();
        }
    }
} 

