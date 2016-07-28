using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;

namespace APIVagasDeTrampo.Domain.Servicos
{
    public class TecnologiaService : ComumService<Tecnologia>, ITecnologiaService
    {
        public TecnologiaService(ITecnologiaRepository repository)
            : base(repository)
        {
        }

        public override void Salvar(Tecnologia obj)
        {
            if (obj.TecnologiaId > 0)
                Repository.Atualizar(obj);
            else
                Repository.Adicionar(obj);
        }
    }
}
