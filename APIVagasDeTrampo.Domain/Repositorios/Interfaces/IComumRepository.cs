using System;
using System.Linq;
using System.Linq.Expressions;

namespace APIVagasDeTrampo.Domain.Repositorios.Interfaces
{
    public interface IComumRepository<TEntity> where TEntity : class, new()
    {
        TEntity Primeiro(Expression<Func<TEntity, bool>> condicao);

        IQueryable<TEntity> Condicao(Expression<Func<TEntity, bool>> condicao);
        IQueryable<TEntity> Todos();

        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Deletar(TEntity obj);
    }
}
