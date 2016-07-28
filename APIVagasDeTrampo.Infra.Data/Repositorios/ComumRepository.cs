using System;
using System.Linq;
using System.Linq.Expressions;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using APIVagasDeTrampo.Infra.Data.Context;
using System.Data.Entity;

namespace APIVagasDeTrampo.Infra.Data.Repositorios
{
    public abstract class ComumRepository<TEntity> : IComumRepository<TEntity>
        where TEntity : class, new()
    {
        protected IDbContext Db;
        protected IDbSet<TEntity> DbSet;

        public ComumRepository(IDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual TEntity Buscar(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Condicao(Expression<Func<TEntity, bool>> condicao)
        {
            return DbSet.Where(condicao);
        }

        public virtual void Deletar(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual TEntity Primeiro(Expression<Func<TEntity, bool>> condicao)
        {
               return DbSet.FirstOrDefault(condicao);
        }

        public virtual IQueryable<TEntity> Todos()
        {
            return DbSet.AsQueryable();
        }
    }
}
