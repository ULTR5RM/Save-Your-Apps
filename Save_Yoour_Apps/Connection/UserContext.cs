using Microsoft.EntityFrameworkCore;
using Save_Yoour_Apps.Models;

namespace Save_Yoour_Apps.Connection
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Config.Configuration.GetConnectionString("UsersDBConnection").ToString());
        }
    }
}
