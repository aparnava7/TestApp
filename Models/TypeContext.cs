using Microsoft.EntityFrameworkCore;

namespace TestApplication.Models
{
    public class TypeContext : DbContext
    {
        public TypeContext(DbContextOptions<GroupContext> options)
        : base(options)
        {
        }

        public DbSet<Type> TypeItems { get; set; } = null!;

    }
}
