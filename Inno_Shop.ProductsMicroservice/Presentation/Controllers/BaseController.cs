using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Inno_Shop.Services.Products.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal long UserId => !User.Identity.IsAuthenticated
            ? -1
            : long.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
