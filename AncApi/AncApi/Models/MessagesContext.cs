using Microsoft.EntityFrameworkCore;

namespace AncApi.Models
{
    public class MessagesContext : DbContext
    {
        public DbSet<Message> MessagesNew { get; set; }
        public MessagesContext(DbContextOptions<MessagesContext> options)
            : base(options)
        { }
    }
}
