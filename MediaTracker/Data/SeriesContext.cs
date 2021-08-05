using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Models;

namespace MediaTracker.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext (DbContextOptions<SeriesContext> options)
            : base(options)
        {
        }

        public DbSet<MediaTracker.Models.Series> Series { get; set; }
    }
}
