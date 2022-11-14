using Microsoft.AspNetCore.Mvc;
using WhatsAppNative.Context;
using WhatsAppNative.Models.WhatsAppEntities;

namespace WhatsAppNative.Service
{
    public class IncomingService
    {
        WhatsAppDbContext _context;
        public IncomingService(WhatsAppDbContext context)
        {
            this._context = context;
        }
        public void saveIncoming(IncomingText incoming)
        {
            if (incoming is not null)
            {
               
                _context.IncomingTexts.Add(incoming);
                _context.SaveChanges();

            }

            //  return incoming;
        }

    }
}
