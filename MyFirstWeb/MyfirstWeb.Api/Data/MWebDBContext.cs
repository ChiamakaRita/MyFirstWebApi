using Microsoft.EntityFrameworkCore;
using MyfirstWeb.Api.Models.Domain;

namespace MyfirstWeb.Api.Data
{
    public class MWebDBContext: DbContext
    {
        public MWebDBContext(DbContextOptions<MWebDBContext> options): base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
