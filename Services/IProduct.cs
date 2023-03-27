using MyStore_MAUI.Models;

namespace MyStore_MAUI.Services
{
    public interface IProduct
    {

        Task<IEnumerable<MProduct>> GetAllProduct();

        Task<MProduct> GetOneProduct(int id);

        Task<MProduct> CreateProduct(MProduct product);

        Task<bool> UpdateProduct(MProduct product, int id);

        Task<bool> DeleteProduct(int id);
    }
}
