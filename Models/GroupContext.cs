using Microsoft.EntityFrameworkCore;

namespace TestApplication.Models
{
    public class GroupContext : DbContext
    {
        public GroupContext(DbContextOptions<GroupContext> options)
        : base(options)
        {
        }

        public DbSet<Group> GroupItems { get; set; } = null!;

    }
}
