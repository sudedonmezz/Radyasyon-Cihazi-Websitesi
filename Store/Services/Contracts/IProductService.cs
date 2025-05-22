using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllproducts(bool trackchanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        Product? GetOneProduct(int id,bool trackchanges);

        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(ProductDtoForUpdate productDto);
        void DeleteOneProduct(int id);
       ProductDtoForUpdate GetOneProductForUpdate(int id,bool trackchanges);


    }
}