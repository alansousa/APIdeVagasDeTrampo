using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace APIVagasDeTrampo.Domain.Servicos.Interfaces
{
    public interface IComumService<TEntity> where TEntity : class, new()
    {
        TEntity Primeiro(Expression<Func<TEntity, bool>> condicao);

        ICollection<TEntity> Condicao(Expression<Func<TEntity, bool>> condicao);
        ICollection<TEntity> Todos();

        void Salvar(TEntity obj);
        void Deletar(TEntity obj);
    }
}
