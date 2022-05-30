using Microsoft.EntityFrameworkCore;
using Save_Yoour_Apps.Models;

namespace Save_Yoour_Apps.Connection
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Config.Configuration.GetConnectionString("EventsDBConnection"));
        }
    }
}
