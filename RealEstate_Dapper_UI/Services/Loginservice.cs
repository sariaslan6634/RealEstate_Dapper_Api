using System.Security.Claims;

namespace RealEstate_Dapper_UI.Services
{
    public class Loginservice : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Loginservice(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
