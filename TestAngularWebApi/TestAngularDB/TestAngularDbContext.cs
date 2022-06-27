using Microsoft.EntityFrameworkCore;
using TestAngularWebApi.TestAngularDB.TableModels;

namespace TestAngularWebApi.TestAngularDB
{
    public class TestAngularDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageTheme> MessageThemes { get; set; }

        public TestAngularDbContext(DbContextOptions<TestAngularDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
