using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediaTracker.Models;

namespace MediaTracker.Data
{
    public class EpisodeContext : DbContext
    {
        public EpisodeContext (DbContextOptions<EpisodeContext> options)
            : base(options)
        {
        }

        public DbSet<MediaTracker.Models.Episode> Episode { get; set; }
    }
}
