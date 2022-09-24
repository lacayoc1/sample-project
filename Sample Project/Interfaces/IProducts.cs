using Sample_Project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample_Project.Interfaces
{
    public interface IProducts
    {
        Task<IEnumerable<CProducts>> GetProduct();
        Task<CProducts> GetProduct(int id);
        Task<int> PostProduct(CProducts data);
        Task<int> PutProduct(int id, CProducts data);
        Task<int> DeleteProduct(int id);
    }
}