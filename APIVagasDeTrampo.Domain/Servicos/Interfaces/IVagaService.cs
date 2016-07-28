using System.Collections.Generic;
using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.ObjetosDeValor;

namespace APIVagasDeTrampo.Domain.Servicos.Interfaces
{
    public interface IVagaService : IComumService<Vaga>
    {
        void SalvarPesosVaga(List<VagaTecnologia> tecnologiaPeso);
        List<CandidatoPosicaoRanking> RankingCandidatos(int vagaId);
    }
}
