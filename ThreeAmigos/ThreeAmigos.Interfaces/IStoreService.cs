using System.Collections.Generic;

using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Interfaces
{
    public interface IStoreService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        IEnumerable<Product> GetProductsBySearch(
            int? categoryId = null,
            int? brandId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null);

        IEnumerable<Product> SortProductList(IEnumerable<Product> products);

        IEnumerable<Product> SortProductList(IEnumerable<Product> products, SortDirection sort);

        IEnumerable<Category> GetAllCategories();

        IEnumerable<Product> GetProductsByCategoryId(int categoryId);

        IEnumerable<Product> GetProductsByCategoryName(string categoryName);

        IEnumerable<Brand> GetAllBrands();

        IEnumerable<Product> GetProductsByBrandId(int brandId);

        IEnumerable<Product> GetProductsByBrandName(string brandName);

        Domain.Store.Brand GetBrandById(int id);

        Domain.Store.Category GetCategoryById(int id);
    }
}
