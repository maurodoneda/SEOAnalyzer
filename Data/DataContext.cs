using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Search> Searches { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
