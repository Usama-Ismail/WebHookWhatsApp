using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WhatsAppNative.DTOS;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using WhatsAppNative.Service;
using WhatsAppNative.Models.WhatsAppEntities;
using WhatsAppNative.Helper;

namespace WebHookWhatsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatsAppController : ControllerBase
    {
        private string verify_token = "usama123";
        private IncomingService _incomingService;
        private OutgoingService _outgoingService;
        public WhatsAppController(IncomingService incomingService, OutgoingService outgoingService)
        {
            _incomingService = incomingService;
            _outgoingService = outgoingService;
        }

        [HttpGet]
        [Route("/webhook")]
        public IActionResult verification()
        {
            string folder = @"C:\Temp\";
            string fileName = "Verified.txt";
            string fullPath = folder + fileName;

            string mode = HttpContext.Request.Query["hub.mode"];
            string token = HttpContext.Request.Query["hub.verify_token"];
            string challenge = HttpContext.Request.Query["hub.challenge"];
            if (mode is not null && token is not null)
            {
                if (mode.Equals("subscribe") && token.Equals(verify_token))
                {
                    Utility.saveMessage("Verifiedd", fullPath);
                    return Ok(challenge);
                }
                else
                {
                    return StatusCode(403);
                }
            }
            return BadRequest();

        }


        [HttpPost]
        [Route("/webhook")]
        public IActionResult IncomingMessages([FromBody] IncomingDTO message)
        {
            string folder = @"C:\Temp\";
            string fileName = "Message.txt";
            string fullPath = folder + fileName;

            if (message != null)
            {

                var js = JsonSerializer.Serialize(message);
                Utility.saveMessage(js, fullPath);

                //Run when you received message from the customer
                if (message.entry is not null && message.entry[0].changes is not null && message.entry[0].changes[0] is not null &&
                    message.entry[0].changes[0].value.messages is not null && message.entry[0].changes[0].value.messages[0] is not null)
                {
                    if (message.entry[0].changes[0].value.messages[0].type.Equals("text"))
                    {


                        var phone_number_id = message.entry[0].changes[0].value.metadata.phone_number_id;
                        var from = message.entry[0].changes[0].value.messages[0].from;
                        var msg_body = message.entry[0].changes[0].value.messages[0].text.body;
                        var to = message.entry[0].changes[0].value.metadata.display_phone_number;
                        var from_name = message.entry[0].changes[0].value.contacts[0].profile.name;
                        var time_stamp = Utility.convertUnixToDt(Double.Parse(message.entry[0].changes[0].value.messages[0].timestamp));
                        var msg_id = message.entry[0].changes[0].value.messages[0].id;


                        var incoming = new IncomingText
                        {
                            From = from,
                            To = to,
                            FromName = from_name,
                            TimeStamp =time_stamp,
                            MessageId = msg_id,
                            Message = msg_body

                        };

                        _incomingService.saveIncoming(incoming);
                    }


                }
            }
            return Ok("Ok");
        }

        [HttpPost]
        [Route("/SendMessage")]
        public IActionResult WhatsAppSendMessage(OutgoingText message)
        {
            
            var result = _outgoingService.sendSave(message);
            
            return Ok(result);
        }


    }



}