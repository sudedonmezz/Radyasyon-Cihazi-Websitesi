using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,int? categoryId)
        {
            if(categoryId is null)
            return products;
            else
            return products.Where(prd=>prd.CategoryId.Equals(categoryId));
        }
        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,String? searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
            return products;
            else
            return products.Where(prd=>prd.ProductName.ToLower()
            .Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,int MinPrice,int MaxPrice,bool isValidPrice)
        {
            if(isValidPrice)
            return products.Where(prd=>prd.ProductPrice>=MinPrice&& prd.ProductPrice<= MaxPrice);
            else
            return products;
        }
    }
}