using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail(Title,Subtitle,Description1,Description2) values (@1,@2,@3,@4)";
            var parameters = new DynamicParameters();
            parameters.Add("@1", createWhoWeAreDetailDto.Title);
            parameters.Add("@2", createWhoWeAreDetailDto.Subtitle);
            parameters.Add("@3", createWhoWeAreDetailDto.Description1);
            parameters.Add("@4", createWhoWeAreDetailDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete from WhoWeAreDetail where WhoWeAreDetailID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "select * from WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "Select * from WhoWeAreDetail where WhoWeAreDetailID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto UpdateWhoWeAreDetailDto)
        {
            string query = "Update  WhoWeAreDetail Set Title= @Title,Subtitle=@Subtitle,Description1 =@Description1,Description2 = @Description2 where WhoWeAreDetailID = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@Title", UpdateWhoWeAreDetailDto.Title);
            parameters.Add("@Subtitle", UpdateWhoWeAreDetailDto.Subtitle);
            parameters.Add("@Description1", UpdateWhoWeAreDetailDto.Description1);
            parameters.Add("@Description2", UpdateWhoWeAreDetailDto.Description2);
            parameters.Add("@id", UpdateWhoWeAreDetailDto.WhoWeAreDetailID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }
    }
}
