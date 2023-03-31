using Microsoft.Extensions.Configuration;
using DataBaseSource.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBaseSource
{
    public partial class MistsOfTheGalaxyDbContext : DbContext
    {
        public MistsOfTheGalaxyDbContext() { }

        public string connectionString;

        public MistsOfTheGalaxyDbContext(DbContextOptions<MistsOfTheGalaxyDbContext> options) : base(options) { }

        public DbSet<ObjectTitle> ObjectTitles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
            var config = builder.Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("MistsOfTheGalaxyDatabase"));
        }           

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectTitle>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Object_T__3214EC07FEA7E98E");

                entity.ToTable("Object_Titles");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
