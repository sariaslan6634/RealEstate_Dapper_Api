using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientBuilder _httpClientBuilder;

        public _DashboardLast5ProductComponentPartial(IHttpClientBuilder httpClientBuilder)
        {
            _httpClientBuilder = httpClientBuilder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
