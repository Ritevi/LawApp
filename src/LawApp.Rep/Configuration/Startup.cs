using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LowAppContext = LawApp.Rep.SqlContext.LowAppContext;

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
            using var context = serviceScope.ServiceProvider.GetRequiredService<LowAppContext>();
            context.Database.Migrate();
        }
    }
}
