using Microsoft.EntityFrameworkCore;
using System.Reflection;
using LawApp.Common.Models.Domain;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LawApp.Rep.SqlContext
{
    internal class LowAppContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Doc> Docs { get; set; }
 
        public LowAppContext()
        {
        }

        public LowAppContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //todo check if work nice
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();
                var connectionString = configuration.GetConnectionString("ConnectionStrings:pgConnectionString");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(LowAppContext))!);
        }
    }


}