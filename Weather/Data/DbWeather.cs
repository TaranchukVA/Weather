using Microsoft.EntityFrameworkCore;
using Weather.Data.Models;

namespace Weather.Data
{
    public class DbWeather : DbContext
    {
        public DbWeather(DbContextOptions<DbWeather> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<HistoryModel> History { get; set; }
    }
}
