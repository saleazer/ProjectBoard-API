using Microsoft.EntityFrameworkCore;
using System;

namespace ScrumLeaderboard.DATA
{
    public class ScrumLeaderboardContext : DbContext
    {
        public DbSet<BoardItem> BoardItem { get; set; }


        public ScrumLeaderboardContext(DbContextOptions<ScrumLeaderboardContext> options) : base(options)
        {
        }
    }

    

}
