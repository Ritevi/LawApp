using Microsoft.EntityFrameworkCore;

namespace LawApp.Rep.SqlContext
{
    internal class AppContextFactory : IAppContextFactory
    {
        private readonly string _connectionString;

        public AppContextFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public LowAppContext CreateContext()
        {
            var opt = new DbContextOptionsBuilder<LowAppContext>().UseNpgsql(_connectionString).Options;
            return new LowAppContext(opt);
        }
    }
}
