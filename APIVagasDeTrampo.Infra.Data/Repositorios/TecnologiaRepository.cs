using System.Linq;
using APIVagasDeTrampo.Infra.Data.Context;
using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using System.Data.Entity;

namespace APIVagasDeTrampo.Infra.Data.Repositorios
{
    public class TecnologiaRepository : ComumRepository<Tecnologia>, ITecnologiaRepository
    {
        public TecnologiaRepository(IDbContext db)
            : base(db)
        {
        }

        public override IQueryable<Tecnologia> Todos()
        {
            return DbSet
                .Include("Candidatos")
                .Include("TecnologiaVagas");
        }

        public override void Deletar(Tecnologia obj)
        {
            var set = Db.Set<VagaTecnologia>();
            var vagasTecnologias = Db.Set<VagaTecnologia>().Where(x => x.TecnologiaId == obj.TecnologiaId);
            if (vagasTecnologias != null) set.RemoveRange(vagasTecnologias);

            base.Deletar(obj);
        }
    }
}