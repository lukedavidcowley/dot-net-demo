using LukeCowley.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LukeCowley.Data.Contexts
{
    public class MarsWeatherContext : DbContext
    {
        public DbSet<Sol> Sols { get; set; }
    }
}
