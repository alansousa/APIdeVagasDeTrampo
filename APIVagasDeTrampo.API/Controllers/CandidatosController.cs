using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIVagasDeTrampo.Infra.Data.Context;
using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;
using System.Web.Http.Cors;

namespace APIVagasDeTrampo.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CandidatosController : BaseController
    {
        private ICandidatoService _service;

        public CandidatosController(IDbContext db, ICandidatoService service)
            : base(db)
        {
            _service = service;
        }

        public List<Candidato> Get()
        {
            return _service
                .Todos()
                .ToList();
        }

        public Candidato Get(int id)
        {
            return _service.Primeiro(x => x.CandidatoId == id);
        }

        public HttpResponseMessage Post([FromBody]Candidato obj)
        {
            try
            {
                _service.Salvar(obj);
                Commit();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var obj = _service.Primeiro(x => x.CandidatoId == id);
                _service.Deletar(obj);
                Commit();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
