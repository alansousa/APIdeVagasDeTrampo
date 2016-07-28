using System.Web;
using System.Web.Http;
using APIVagasDeTrampo.Infra.Data.Context;
using APIVagasDeTrampo.Domain.Repositorios.Interfaces;
using APIVagasDeTrampo.Domain.Servicos;
using APIVagasDeTrampo.Domain.Servicos.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Newtonsoft.Json;
using APIVagasDeTrampo.Infra.Data.Repositorios;

namespace APIVagasDeTrampo.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration
                .Formatters.JsonFormatter
                .SerializerSettings
                .ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            IoC();
        }

        private void IoC()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IDbContext, Context>(Lifestyle.Scoped);
            container.Register<ITecnologiaRepository, TecnologiaRepository>(Lifestyle.Scoped);
            container.Register<ITecnologiaService, TecnologiaService>(Lifestyle.Scoped);
            container.Register<IVagaRepository, VagaRepository>(Lifestyle.Scoped);
            container.Register<IVagaService, VagaService>(Lifestyle.Scoped);
            container.Register<ICandidatoRepository, CandidatoRepository>(Lifestyle.Scoped);
            container.Register<ICandidatoService, CandidatoService>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
