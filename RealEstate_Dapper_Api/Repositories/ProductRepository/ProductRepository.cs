﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,Type,Address,CoverImage,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "Select top(5) ProductID,Title,Price,City,District,ProductCategory,CategoryName,AdvertisementDate from product inner join Category on Product.ProductCategory = Category.CategoryID where type = 'Kiralık' order by ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
            
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployee>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,Type,Address,CoverImage,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryID WHERE EmployeeID = @employeeID AND ProductStatus = 0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployee>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployee>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "select ProductID,Title,Price,City,District,CategoryName,Type,Address,CoverImage,DealOfTheDay from Product inner join Category on Product.ProductCategory = Category.CategoryID WHERE EmployeeID = @employeeID  AND ProductStatus = 1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployee>(query,parameters);
                return values.ToList();
            }

        }

        public async void ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update product set DealOfTheDay =0 WHERE ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
                
            }
        }

        public async void ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "Update product set DealOfTheDay =1 WHERE ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
