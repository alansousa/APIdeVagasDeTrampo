using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using APIVagasDeTrampo.Infra.Data.Context;
using APIVagasDeTrampo.Domain.Entidades;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using APIVagasDeTrampo.Infra.Data.Repositorios;
using APIVagasDeTrampo.Domain.Servicos;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;

namespace DB1.AvaliacaoTecnica.Console.Tests
{
    [TestClass]
    public class TecnologiaServiceTest
    {
        ITecnologiaService _service;

        [TestMethod]
        public void GetNada_Mock()
        {
            var mockdb = new Mock<IDbContext>();
            var list = new List<Tecnologia>();
            //list.Add(new Tecnologia());
            //list.Add(new Tecnologia());
            //list.Add(new Tecnologia());
            //list.Add(new Tecnologia());

            IDbContext db = GetDbMock(mockdb, list);

            ITecnologiaRepository repository = new TecnologiaRepository(db);
            _service = new TecnologiaService(repository);

            Assert.IsFalse(_service.Todos().Any());
        }

        [TestMethod]
        public void AddNovo()
        {
            IDbContext db = new Context();

            ITecnologiaRepository repository = new TecnologiaRepository(db);
            _service = new TecnologiaService(repository);

            _service.Salvar(new Tecnologia() { Descricao = "c#" });
            db.SaveChanges();
        }


        [TestMethod]
        public void GetNada()
        {
            IDbContext db = new Context();

            ITecnologiaRepository repository = new TecnologiaRepository(db);
            _service = new TecnologiaService(repository);

            var lista = _service.Todos();

            Assert.IsTrue(lista.Any());
            Assert.AreEqual(2, lista.Count);
        }


        private static IDbContext GetDbMock(Mock<IDbContext> mockdb, List<Tecnologia> list)
        {
            var queryable = list.AsQueryable();

            var productMock = new Mock<DbSet<Tecnologia>>();
            productMock.As<IQueryable<Tecnologia>>()
                .Setup(m => m.Provider).Returns(queryable.Provider);
            productMock.As<IQueryable<Tecnologia>>()
                .Setup(m => m.Expression).Returns(queryable.Expression);
            productMock.As<IQueryable<Tecnologia>>()
                .Setup(m => m.ElementType).Returns(queryable.ElementType);
            productMock.As<IQueryable<Tecnologia>>()
                .Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            mockdb.Setup(x => x.Set<Tecnologia>()).Returns(productMock.Object);

            var db = mockdb.Object;
            return db;
        }
    }
}
