using Microsoft.EntityFrameworkCore;
using teachers_info_api.Models;

namespace teachers_info_api.Context
{
    public class TeachersInfoDbContext : DbContext
    {
        public TeachersInfoDbContext(DbContextOptions<TeachersInfoDbContext> options) : base(options) { }

        public DbSet<Teacher> Teachers { get; set; }

    }
}

