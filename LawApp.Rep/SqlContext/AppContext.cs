using Microsoft.EntityFrameworkCore;
using System.Reflection;
using LawApp.Common.Models.Domain;


namespace LawApp.Rep.SqlContext
{
    internal class AppContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
        }

        public AppContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=db;Username=sa;Password=pass;Database=law_app");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppContext))!);
        }
    }


}