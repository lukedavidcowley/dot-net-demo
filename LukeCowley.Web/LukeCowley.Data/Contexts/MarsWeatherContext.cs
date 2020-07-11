using LukeCowley.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LukeCowley.Data.Contexts
{
    public class MarsWeatherContext : DbContext
    {
        public DbSet<Sol> Sols { get; set; }
    }
}
