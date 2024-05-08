using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreDetailRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreDetailRepository;

        public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreDetailRepository)
        {
            _whoWeAreDetailRepository = whoWeAreDetailRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreDetailRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetailList(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            _whoWeAreDetailRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
            return Ok("Hakkımızda kısmı başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreDetailRepository.DeleteWhoWeAreDetail(id);
            return Ok("Hakkımızda kısmı Başarılı bir şekilde silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _whoWeAreDetailRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("Hakkımızda kısmı Başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var values = await _whoWeAreDetailRepository.GetWhoWeAreDetail(id);
            return Ok(values);
        }
    }
}
