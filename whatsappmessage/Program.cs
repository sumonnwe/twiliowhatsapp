using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using DotNetEnv;
using Twilio.Rest.Verify.V2.Service;
using Newtonsoft.Json;
using System.Text;


class Example
{     
   public static async Task Main(string[] args)
   {
       Env.Load();
       // Find your Account SID and Auth Token at twilio.com/console
       // and set the environment variables. See http://twil.io/secure
       string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
       string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
       string fromNumber = Environment.GetEnvironmentVariable("FROM_WHATSAPP");
        string whatsAppId = Environment.GetEnvironmentVariable("WHATSAPP_ID");
        string callback = Environment.GetEnvironmentVariable("STATUS_CALLBACK");

       TwilioClient.Init(accountSid, authToken);
         
        var numbers = new string[] {  "+6591725358"  };
        //string messageBody = "Hello! This is a custom message sent via Twilio WhatsApp API.";

        // Define the message content with line breaks
        string messageWithLineBreaks = "Project Reference: XXX " + "Location: XX " + "Instrument Type: XXXX " + "Reading Date: 20/04/2025 " + "Alert send: 23/04/2025 10:30:00 " + "Please make necessary arrangement to check on the instruments.";

        // Serialize the content with proper handling of line breaks
        var contentVariables = new Dictionary<string, object>
        {
            { "1", messageWithLineBreaks }
        };

        // Serialize the dictionary into a JSON string without indentation
        var serializedContent = JsonConvert.SerializeObject(contentVariables, Formatting.None);
        try
        {
            foreach (var number in numbers)
            {
                var message = await MessageResource.CreateAsync(
                    contentSid: "HX9231de6718a298ea7e45b37d88601126",
                    to: new Twilio.Types.PhoneNumber($"whatsapp:{number}"),
                    from: new Twilio.Types.PhoneNumber(fromNumber),
                    contentVariables: serializedContent,
                    statusCallback: new Uri(callback)
                    );


                Console.WriteLine(message.Body);
                Console.WriteLine("end");
            } 

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


    }  
}