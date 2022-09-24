using Dapper;
using Sample_Project.Interfaces;
using Sample_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Sample_Project.Repositories
{
    public class ProductsRepository : IProducts
    {
        private readonly IDbConnector _dbConnector;

        public ProductsRepository(IDbConnector dbConnector)
        {
            this._dbConnector = dbConnector ?? throw new ArgumentNullException(nameof(dbConnector));
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual async Task<int> DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection connection = this._dbConnector.OpenConnection("DefaultConnection"))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ProductId", id);
                    var row = await connection.ExecuteAsync("ProductsDelete", parameters, commandType: CommandType.StoredProcedure);
                    return row;
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of all products</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual async Task<IEnumerable<CProducts>> GetProduct()
        {
            try
            {
                using (SqlConnection connection = this._dbConnector.OpenConnection("DefaultConnection"))
                {
                    var output = await connection.QueryAsync<CProducts>("ProductsGet", new { }, commandType: CommandType.StoredProcedure);
                    return output;
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Get a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>A product</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual async Task<CProducts> GetProduct(int id)
        {
            try
            {
                using (SqlConnection connection = this._dbConnector.OpenConnection("DefaultConnection"))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ProductId", id);
                    var output = await connection.QueryFirstAsync<CProducts>("ProductsGet", parameters, commandType: CommandType.StoredProcedure);
                    return output;
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Amend a product
        /// </summary>
        /// <param name="data">Product data</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual async Task<int> PostProduct(CProducts data)
        {
            try
            {
                using (SqlConnection connection = this._dbConnector.OpenConnection("DefaultConnection"))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ProductName", data.ProductName);
                    parameters.Add("@ProductDescription", data.ProductDescription);
                    parameters.Add("@ProductPrice", data.ProductPrice);
                    parameters.Add("@ProductQuantity", data.ProductQuantity);
                    parameters.Add("@ProductVisible", data.ProductVisible);
                    parameters.Add("@ProductImages", data.ProductImages);
                    var row = await connection.ExecuteAsync("ProductsPost", parameters, commandType: CommandType.StoredProcedure);
                    return row;
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="data">Product data</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public virtual async Task<int> PutProduct(int id, CProducts data)
        {
            try
            {
                using (SqlConnection connection = this._dbConnector.OpenConnection("DefaultConnection"))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@ProductId", id);
                    parameters.Add("@ProductName", data.ProductName);
                    parameters.Add("@ProductDescription", data.ProductDescription);
                    parameters.Add("@ProductPrice", data.ProductPrice);
                    parameters.Add("@ProductQuantity", data.ProductQuantity);
                    parameters.Add("@ProductVisible", data.ProductVisible);
                    parameters.Add("@ProductImages", data.ProductImages);
                    var row = await connection.ExecuteAsync("ProductsPut", parameters, commandType: CommandType.StoredProcedure);
                    return row;
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}