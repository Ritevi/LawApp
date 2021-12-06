using LawApp.Rep.SqlContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using LawApp.Common.Repositories;
using LawApp.Rep.Repositories;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace LawApp.Rep.Configuration
{
    public static class ModuleInitializer
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
            AddDependenciesToContainer(services);

            return services;
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("pgConnectionString");
            services.AddDbContext<AppContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            var dbFactory = new AppContextFactory(connectionString);
            services.AddSingleton(typeof(IAppContextFactory), dbFactory);
        }

        private static void AddDependenciesToContainer(IServiceCollection services)
        {
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IDocRepository, DocRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
        }
    }
}
