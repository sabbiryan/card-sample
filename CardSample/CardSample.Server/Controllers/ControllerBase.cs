using System.Web.Http;
using CardSample.Server.Models;

namespace CardSample.Server.Controllers
{
    public abstract class ControllerBase : ApiController
    {
        protected readonly CardSampleDbContext DbContext;

        protected ControllerBase()
        {
            DbContext = CardSampleDbContext.Create();
        }



        public new void Dispose()
        {

            DbContext?.Dispose();
            base.Dispose();
        }

    }
}