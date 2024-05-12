using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async void CreateContact(CreateContactDto createContactDto)
        {
            string query = "Insert Into Contact(Name,Mail,Subject,Message,SendDate) VALUES (@Name,@Mail,@Subject,@Message,@sendDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@Name", createContactDto.Name);
            parameters.Add("@Mail", createContactDto.Mail);
            parameters.Add("@Subject", createContactDto.Subject);
            parameters.Add("@Message", createContactDto.Message);
            parameters.Add("@sendDate", DateTime.Now);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteContact(int id)
        {
            string query = "Delete From Contact Where ContactID = @contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);   
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "Select * From Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDContactDto> GetContact(int id)
        {
            string query = "Select * From Contact Where ContactID = @contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDContactDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<Last4ContactResultDto>> GetLast4Contact()
        {
            string query = "Select Top(4)* From Contact order by ContactID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDto>(query);
                return values.ToList();
            }
        }
    }
}
