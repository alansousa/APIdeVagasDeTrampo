using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.ObjetosDeValor;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;
using APIVagasDeTrampo.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIVagasDeTrampo.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AvaliacaoController : BaseController
    {
        private IVagaService _service;

        public AvaliacaoController(IDbContext db, IVagaService service)
            : base(db)
        {
            _service = service;
        }
        
        [AcceptVerbs("GET")]
        public List<CandidatoPosicaoRanking> Get(int id)
        {
            return _service.RankingCandidatos(id);
        }

        public HttpResponseMessage Post([FromBody]List<VagaTecnologia> tecnologiaPeso)
        {
            try
            {
                _service.SalvarPesosVaga(tecnologiaPeso);
                Commit();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
