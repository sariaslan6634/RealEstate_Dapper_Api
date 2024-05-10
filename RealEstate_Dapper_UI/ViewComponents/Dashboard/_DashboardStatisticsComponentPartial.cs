using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            #region Statistics1 - Toplam ilan sayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44353/api/Statistics/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion

            #region İstatistik2 - En başarılı personel
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44353/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData2;
            #endregion

            #region İstatistik3 -İlandaki şehir sayıları
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44353/api/Statistics/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData3;
            #endregion

            #region İstatistik4-Ortalama Kira
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44353/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            decimal a = decimal.Parse(jsonData4, CultureInfo.InvariantCulture);
            ViewBag.averageProductPriceByRent = a.ToString("0.00");
            #endregion

            return View();
        }
    }
}
