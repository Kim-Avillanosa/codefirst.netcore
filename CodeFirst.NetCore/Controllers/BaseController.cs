using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CodeFirst.NetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _Mediator;
        protected IMediator Mediator
        {
            get
            {
                return _Mediator ?? (_Mediator = HttpContext.RequestServices.GetService<IMediator>());
            }
        }

    }
}
