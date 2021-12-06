using LawApp.Bll.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using LawApp.Rep.Configuration;
using Microsoft.VisualBasic;

namespace LawApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureBll();
            services.ConfigureDal(Configuration);
            var controllers = services.AddControllers();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });


            controllers
                .AddNewtonsoftJson(
                    options =>
                    {
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);



            services.AddSwaggerDocument(c =>
            {
                c.PostProcess = doc =>
                {
                    doc.Info.Version = "v1";
                    doc.Info.Title = "IHub Web Api";
                    doc.Info.Description = "The documentation IHub Web API";
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(cfg =>
            {
                cfg.AllowAnyOrigin();
                cfg.AllowAnyHeader();
                cfg.AllowAnyMethod();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting()
                .UseEndpoints(endpoints => endpoints.MapControllers());


            /*            app.UseSpa(spa =>
                        {
                            spa.Options.SourcePath = "ClientApp";

                            if (env.IsDevelopment())
                            {
                                spa.UseReactDevelopmentServer(npmScript: "start");
                            }
                        });*/

            app
                .UseOpenApi(cfg =>
                {
                    cfg.PostProcess = (document, request) =>
                    {
                        var apiServerUrl = Configuration.GetValue<string>("apiServerUrl");
                        if (!String.IsNullOrWhiteSpace(apiServerUrl))
                        {
                            document.Host = new Uri(apiServerUrl).Authority;
                        }
                    };
                })
                .UseSwaggerUi3(cfg => { cfg.EnableTryItOut = true; });

            Rep.Configuration.Startup.Initialize(app);
        }
    }
}
