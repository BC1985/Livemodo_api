using System;
using Livemodo_db.Models;
using Microsoft.EntityFrameworkCore;

namespace Livemodo_db.Data
{
    public class LivemodoContext : DbContext
    {
        public LivemodoContext(DbContextOptions<LivemodoContext> opt) : base(opt)
        {

        }
        public DbSet<Review> Commands { get; set; }
    }
}
