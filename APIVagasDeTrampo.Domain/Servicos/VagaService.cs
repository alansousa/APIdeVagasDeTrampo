using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.ObjetosDeValor;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIVagasDeTrampo.Domain.Servicos
{
    public class VagaService : ComumService<Vaga>, IVagaService
    {
        public VagaService(IVagaRepository repository)
            : base(repository)
        {
        }

        public List<CandidatoPosicaoRanking> RankingCandidatos(int vagaId)
        {
            List<CandidatoPosicaoRanking> ranking = new List<CandidatoPosicaoRanking>();
            var vaga = Repository.Primeiro(x => x.VagaId == vagaId);
            
            foreach (var candidato in vaga.Candidatos)
                ranking.Add(new CandidatoPosicaoRanking(candidato, vaga.VagaTecnologias));

            return ranking
                .OrderByDescending(x => x.Pontuacao)
                .ToList();
        }

        public override void Salvar(Vaga obj)
        {
            if (obj.VagaId > 0)
                Repository.Atualizar(obj);
            else {
                obj.DataPostagem = DateTime.Today;
                Repository.Adicionar(obj);
            }
        }

        public void SalvarPesosVaga(List<VagaTecnologia> tecnologiasPeso)
        {
            tecnologiasPeso = tecnologiasPeso
                .Where(x => x.PesoTecnologia > 0 && x.PesoTecnologia <= 10)
                .Select(x => new VagaTecnologia(x.PesoTecnologia, x.TecnologiaId, x.VagaId))
                .ToList();

            if (!tecnologiasPeso.Any()) return;

            var vagaaux = tecnologiasPeso.FirstOrDefault();
            var vaga = Repository.Primeiro(x => x.VagaId == vagaaux.VagaId);

            vaga.VagaTecnologias = tecnologiasPeso;
            Repository.Atualizar(vaga);
        }
    }
}
