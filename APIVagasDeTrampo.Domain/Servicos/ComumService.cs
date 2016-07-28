using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using System.Linq;

namespace APIVagasDeTrampo.Domain.Servicos
{
    public abstract class ComumService<TEntity> : IComumService<TEntity>
        where TEntity : class, new()
    {
        protected readonly IComumRepository<TEntity> Repository;

        public ComumService(IComumRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public abstract void Salvar(TEntity obj);
        
        
        public ICollection<TEntity> Condicao(Expression<Func<TEntity, bool>> condicao)
        {
            return Repository.Condicao(condicao).ToList();
        }

        public void Deletar(TEntity obj)
        {
            Repository.Deletar(obj);
        }

        public TEntity Primeiro(Expression<Func<TEntity, bool>> condicao)
        {
            return Repository.Primeiro(condicao);
        }

        public virtual ICollection<TEntity> Todos()
        {
            var list = Repository.Todos().ToList();
            return list;
        }
    }
}
