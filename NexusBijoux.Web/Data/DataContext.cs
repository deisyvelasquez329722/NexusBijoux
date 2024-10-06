
using NexusBijoux.web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NexusBijoux.web.Data
{
    public class DataContext : DbContext
    {
        public DataContextDbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Permission> Permissions { get; set; }
    }
}
