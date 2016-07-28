using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace APIVagasDeTrampo.Infra.Data.Context
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        int SaveChanges();
    }
}
