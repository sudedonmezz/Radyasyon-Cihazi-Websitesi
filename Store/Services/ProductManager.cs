using Services.Contracts;
using Entities.Models;
using Repositories.Contracts;
using Entities.Dtos;
using AutoMapper;
using Entities.RequestParameters;
namespace Services
{
    public class ProductManager:IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager,IMapper mapper)
        {
            _mapper=mapper;
            _manager=manager;
        }
       public IEnumerable<Product> GetAllproducts(bool trackChanges)
       {
        return _manager.Product.GetAllProducts(trackChanges);
       }
        public Product? GetOneProduct(int id,bool trackChanges)
        {
        var product = _manager.Product.GetOneProduct(id,trackChanges);
        if(product is null)
        throw new Exception("Product is not found!");
        return product;
      
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product=_mapper.Map<Product>(productDto);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
{
    //var entity = _manager.Product.GetOneProduct(productDto.ProductId,true);
    //if (entity is null)
      //  return;

    
    var entity=_mapper.Map<Product>(productDto);
    _manager.Product.UpdateOneProduct(entity);
    

    _manager.Save();
}


        public void DeleteOneProduct(int id)
        {
            Product product=GetOneProduct(id,false);
            if(product is not null)
            {
                _manager.Product.DeleteProduct(product);
                _manager.Save();
            }
            
        }

      public  ProductDtoForUpdate GetOneProductForUpdate(int id,bool trackchanges)
      {
            var product = GetOneProduct(id,trackchanges);
            var productDto= _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
      }

     public IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
     {
        return _manager.Product.GetAllProductsWithDetails(p);
     }
    }
}