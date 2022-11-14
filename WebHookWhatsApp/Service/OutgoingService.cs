using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using WhatsAppNative.Context;
using WhatsAppNative.DTOS;
using WhatsAppNative.Models.WhatsAppEntities;

namespace WhatsAppNative.Service
{
    public class OutgoingService
    {
        private readonly WhatsAppDbContext _context;

        public OutgoingService(WhatsAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> sendSave(OutgoingText message)
        {
            if (message is not null)
            {
                var token = "EAAGyZCpMuw2ABACop7fG5H6Ms0OjzEabe6i6RVBzRjHPLQYuydM3p5vAen7pLRiIoyGtEiho8h4ZBo0GZB1mbyw3tbkEu7GdcO5zcfY2NHw45E1y0fNJS5sbe7nADoNLCsmZB2HoIzPEZBU1W066fyWyr4AaAQbEznRftVHeZBrdHo9ZCNPUZBapJsDlaE78wGomhtt3soPvOAZDZD";
                var msgObj = new OutgoingDTO()
                {
                    messaging_product = "whatsapp",
                    to = message.To,
                    type = "text",
                    text = new OutgoingDTO.Texttt
                    {
                        preview_url = false,
                        body = message.Text
                    }
                };
                var json = JsonSerializer.Serialize(msgObj);
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://graph.facebook.com/");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var request = new HttpRequestMessage(HttpMethod.Post, "v15.0/102230042623129/messages");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.SendAsync(request);
              if(response.StatusCode.Equals(200))
                {
                    try
                    {
                        await _context.OutgoingTexts.AddAsync(message);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }

                }
                else
                {
                    return false;
                }

            }
            return true;

        }

        public bool facebookApi(OutgoingText t)
        {
            return true;
        }
    }
}
