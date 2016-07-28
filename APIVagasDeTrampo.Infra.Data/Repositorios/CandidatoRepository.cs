using System.Linq;
using APIVagasDeTrampo.Infra.Data.Context;
using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using System.Data.Entity;
using System;
using System.Linq.Expressions;

namespace APIVagasDeTrampo.Infra.Data.Repositorios
{
    public class CandidatoRepository : ComumRepository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(IDbContext db)
            : base(db)
        {
        }

        public override Candidato Primeiro(Expression<Func<Candidato, bool>> condicao)
        {
            return Include().FirstOrDefault(condicao);
        }

        public override IQueryable<Candidato> Todos()
        {
            return Include();
        }
            private IQueryable<Candidato> Include()
        {
            return DbSet
                .Include("Vaga")
                .Include("Tecnologias")
                .Include("Tecnologias.Tecnologia");
        }
    }
}