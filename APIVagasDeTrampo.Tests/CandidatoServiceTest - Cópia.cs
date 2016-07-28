using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Servicos;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;
using APIVagasDeTrampo.Infra.Data.Context;
using APIVagasDeTrampo.Infra.Data.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DB1.AvaliacaoTecnica.Console.Tests
{
    [TestClass]
    public class CandidatoServiceTest
    {
        ICandidatoService _service;

        [TestMethod]
        public void AdicionarCandidatoETecnologias()
        {
            var db = new Context();
            _service = new CandidatoService(new CandidatoRepository(db));

            var list = new List<Tecnologia>() {
                new Tecnologia() {Descricao = "java" },
                new Tecnologia() {Descricao = "php" },
                new Tecnologia() { Descricao = "python" }
            };

            var candidato = new Candidato()
            {
                Nome = "Alan Oliveira"
            };

            _service.Salvar(candidato);
            db.SaveChanges();
            //_service.AdicionarTecnologias(candidato, list);
            db.SaveChanges();

            var resultado = _service
                .Primeiro(x => x.Nome == "Alan Oliveira");

            Assert.AreEqual(3, resultado.Tecnologias.Count);


        }
    }
}
