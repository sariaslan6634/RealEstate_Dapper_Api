using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {        
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetLast4Contact")]
        public async Task<IActionResult> GetLast4Contact()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }

        [HttpGet("GetAllContactAsync")]
        public async Task<IActionResult> GetAllContactAsync()
        {
            var values = await _contactRepository.GetAllContactAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            _contactRepository.CreateContact(createContactDto);
            return Ok("Kategori başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            return Ok("Kategori Başarılı bir şekilde silindi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _contactRepository.GetContact(id);
            return Ok(values);
        }

    }
}
