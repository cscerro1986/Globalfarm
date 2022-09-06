using Microsoft.EntityFrameworkCore;
using Disval.Entidades;

namespace Disval.Contexto
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("baseDeDatos2");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken);
        }
        public DbSet<CCV> CCVs { get; set; } 
        public DbSet<DCV>DCVs { get; set; }
        public DbSet<TFC> TFCs { get; set; }


    }
}
