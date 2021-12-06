using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppContext = LawApp.Rep.SqlContext.AppContext;

namespace LawApp.Rep.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class Startup
    {
        public static void Initialize(IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<AppContext>();
            context.Database.Migrate();
        }
    }
}
