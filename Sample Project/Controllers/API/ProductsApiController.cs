using Sample_Project.Interfaces;
using Sample_Project.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sample_Project.Controllers.API
{
    public class ProductsApiController : ApiController
    {
        private readonly IProducts products;

        public ProductsApiController(IProducts products)
        {
            this.products = products ?? throw new ArgumentNullException(nameof(products));
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>All products</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct()
        {
            var result = await this.products.GetProduct();
            return Ok(result);
        }

        /// <summary>
        /// Get a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Product information</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var result = await this.products.GetProduct(id);
            return Ok(result);
        }

        /// <summary>
        /// Add a product
        /// </summary>
        /// <param name="data">Product information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> PostProduct([FromBody]CProducts data)
        {
            var result = await this.products.PostProduct(data);
            return Ok(result);
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="data">Product information</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IHttpActionResult> PutProduct(int id, [FromBody] CProducts data)
        {
            var result = await this.products.PutProduct(id, data);
            return Ok(result);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            var result = await this.products.DeleteProduct(id);
            return Ok(result);
        }
    }
}