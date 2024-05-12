namespace RealEstate_Dapper_UI.Dtos.ToDoListDtos
{
    public class UpdateToDoListDto
    {
        public int ToDolistID { get; set; }
        public string Description { get; set; }
        public bool ToDolistStatus { get; set; }
    }
}
