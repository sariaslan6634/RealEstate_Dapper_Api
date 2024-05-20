using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticsRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("ProductCountByEmployeeID")]
        public IActionResult ProductCountByEmployeeID(int id)
        {
            return Ok(_statisticsRepository.ProductCountByEmployeeID(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusTrue(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticsRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("AllPorductCount")]
        public IActionResult AllPorductCount()
        {
            return Ok(_statisticsRepository.AllPorductCount());
        }
    }
}
