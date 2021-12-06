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

        public AppContext CreateContext()
        {
            var opt = new DbContextOptionsBuilder<AppContext>().UseNpgsql(_connectionString).Options;
            return new AppContext(opt);
        }
    }
}
