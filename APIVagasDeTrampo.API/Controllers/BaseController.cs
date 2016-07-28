using System.Web.Http;
using APIVagasDeTrampo.Infra.Data.Context;

namespace APIVagasDeTrampo.API.Controllers
{
    public class BaseController : ApiController
    {
        private IDbContext Context;

        public BaseController(IDbContext db)
        {
            Context = db;
        }

        protected void Commit()
        {
            Context.SaveChanges();
        }
    }
}
