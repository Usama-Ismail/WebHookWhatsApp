
using Microsoft.EntityFrameworkCore;
using WhatsAppNative.Models.WhatsAppEntities;

namespace WhatsAppNative.Context
{
    public class WhatsAppDbContext : DbContext
  
    {
        public WhatsAppDbContext(DbContextOptions<WhatsAppDbContext> options) : base(options){}

        public DbSet<IncomingText> IncomingTexts { get; set; }
        public DbSet<OutgoingText> OutgoingTexts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
