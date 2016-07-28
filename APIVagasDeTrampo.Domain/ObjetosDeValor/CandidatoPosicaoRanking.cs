using APIVagasDeTrampo.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace APIVagasDeTrampo.Domain.ObjetosDeValor
{
    public class CandidatoPosicaoRanking
    {
        public Candidato Candidato { get; set; }

        public int Pontuacao { get { return PontuacaoCandidato(); } }

        private ICollection<VagaTecnologia> _vagaTecnologias;

        private int PontuacaoCandidato()
        {
            int pontos = 0;

            _vagaTecnologias
                .ToList()
                .ForEach(x =>pontos += Candidato.Tecnologias
                    .Any(a => a.TecnologiaId == x.TecnologiaId) ? x.PesoTecnologia : 0);

            return pontos;
        }

        public CandidatoPosicaoRanking(Candidato candidato, ICollection<VagaTecnologia> pesosTecnologia)
        {
            Candidato = candidato;
            _vagaTecnologias = pesosTecnologia;
        }

    }
}
