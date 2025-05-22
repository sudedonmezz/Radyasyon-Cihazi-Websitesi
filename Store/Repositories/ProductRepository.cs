using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;
namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public ProductRepository(RepositoryContext context):base(context)
        {

        }
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);


        public Product? GetOneProduct(int id,bool trackChanges)
        {
            return FindByCondition(p=>p.ProductId.Equals(id),trackChanges);
        }

        public void CreateProduct(Product product) =>Create(product);
        
       public void DeleteProduct(Product product)=> Remove(product);

       public void UpdateOneProduct(Product product)=>Update(product);

      public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
       {
        return _context
        .Products
        .FilteredByCategoryId(p.CategoryId)
        .FilteredBySearchTerm(p.SearchTerm)
        .FilteredByPrice(p.MinPrice,p.MaxPrice,p.isValidPrice);
        

       }

        
    }
}