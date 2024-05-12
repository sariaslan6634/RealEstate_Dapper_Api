using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository:IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async void CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            string query = "Insert Into ToDoList(Description,ToDoListStatus) VALUES (@description,@toDoListStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", createToDoListDto.Description);
            parameters.Add("@toDoListStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async void DeleteToDoList(int id)
        {
            string query = "Delete from ToDoList WHERE ToDoListID = @toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoListAsync()
        {
            string query = "Select * from ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDToDoList> GetToDoList(int id)
        {
            string query = "Select * from ToDoList where ToDoListID = @toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoList>(query,parameters);
                return values;
            }
        }

        public async void UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            string query = "Update ToDoList SET Description=@description, ToDoListStatus =@toDoListStatus WHERE ToDoListID = @toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@description", updateToDoListDto.Description);
            parameters.Add("@toDoListStatus", updateToDoListDto.ToDolistStatus);
            parameters.Add("@toDoListID", updateToDoListDto.ToDolistID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
