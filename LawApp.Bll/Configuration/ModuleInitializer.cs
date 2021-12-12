using LawApp.Bll.Services;
using LawApp.Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LawApp.Bll.Configuration
{
    public static class ModuleInitializer
    {
        public static IServiceCollection ConfigureBll(this IServiceCollection services)
        {
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IDocService, DocService>();
            services.AddTransient<IAdminService, AdminService>();

            return services;
        }
    }
}
