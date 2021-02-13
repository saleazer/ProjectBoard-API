using Microsoft.EntityFrameworkCore;
using System;

namespace ProjectBoard.Data
{
    public class ProjectBoardContext : DbContext
    {
        public DbSet<BoardItem> BoardItem { get; set; }

        public DbSet<Project> Project { get; set; }

        public ProjectBoardContext(DbContextOptions<ProjectBoardContext> options) : base(options)
        {
        }
    }
}
