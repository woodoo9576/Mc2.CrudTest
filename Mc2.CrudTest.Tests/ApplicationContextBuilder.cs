using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Tests
{
    internal class ApplicationContextBuilder : IDisposable
    {
        private bool _disposed = false;
        public ApplicationContext CreateContextForSqLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var option = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(connection)
                .Options;
            var context = new ApplicationContext(option);
            context.Database.EnsureCreated();
            context.Database.EnsureDeleted();
            return context;
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
