namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CategoryID { get; set; }
        public string coverimage { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
}
