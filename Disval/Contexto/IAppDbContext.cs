using Disval.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Disval.Contexto
{
    public interface IAppDbContext
    {
        DbSet<CCV> CCVs { get; set; }

        DbSet<DCV> DCVs { get; set; }
        DbSet<TFC> TFCs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}