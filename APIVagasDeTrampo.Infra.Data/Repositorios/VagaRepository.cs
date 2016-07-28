using System.Linq;
using APIVagasDeTrampo.Infra.Data.Context;
using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using System.Data.Entity;
using System;
using System.Linq.Expressions;

namespace APIVagasDeTrampo.Infra.Data.Repositorios
{
    public class VagaRepository : ComumRepository<Vaga>, IVagaRepository
    {
        public VagaRepository(IDbContext db) : base(db)
        {
        }

        private IQueryable<Vaga> Include()
        {
            return DbSet.Include("Candidatos")
                .Include("Candidatos.Tecnologias")
                .Include("Candidatos.Tecnologias.Tecnologia")
                .Include("VagaTecnologias")
                .Include("VagaTecnologias.Tecnologia");
        }

        public override Vaga Primeiro(Expression<Func<Vaga, bool>> condicao)
        {
            return Include().FirstOrDefault(condicao);
        }

        public override IQueryable<Vaga> Todos()
        {
            return Include();
        }
    }
}
