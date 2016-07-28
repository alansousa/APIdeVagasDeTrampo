using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;

namespace APIVagasDeTrampo.Domain.Servicos
{
    public class CandidatoService : ComumService<Candidato>, ICandidatoService
    {
        private ITecnologiaRepository _tecnologiaRepository;

        public CandidatoService(ICandidatoRepository repository)
            : base(repository)
        {
        }
        
        public override void Salvar(Candidato obj)
        {
            if (obj.CandidatoId > 0)
                Repository.Atualizar(obj);
            else
                Repository.Adicionar(obj);
        }
    }
}
