using System.Collections.Generic;
using System.Net;

using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Implemented by store adapter classes capable of converting between provider-specific 
    /// data models and the system domain model.
    /// </summary>
    public interface IStoreAdapter
    {
        /// <summary>
        /// Gets the supplier code for the provider this adapter is designed to work with.
        /// </summary>
        SupplierCode SupplierCode { get; }

        /// <summary>
        /// Retrieves all products from the store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Retrieves a collection of products from the store that match the given criteria.
        /// </summary>
        /// <param name="categoryId">The product category identifier.</param>
        /// <param name="categoryName">The product category name.</param>
        /// <param name="brandId">The product brand identifier.</param>
        /// <param name="minPrice">The minimum price of products to return.</param>
        /// <param name="maxPrice">The maximum price of products to return.</param>
        /// <returns></returns>
        /// <returns></returns>
        IEnumerable<Product> SearchProducts(
            int? categoryId = null,
            string categoryName = null,
            int? brandId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null);

        /// <summary>
        /// Retrieves the product from the store with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns></returns>
        Product GetProductById(int id);

        /// <summary>
        /// Retrieves all categories from the store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Retrieves the category from the store with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        /// <returns></returns>
        Category GetCategoryById(int id);

        /// <summary>
        /// Retrieves all brands from the store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Brand> GetAllBrands();

        /// <summary>
        /// Retrieves the brand from the store with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the brand.</param>
        /// <returns></returns>
        Brand GetBrandById(int id);

        /// <summary>
        /// Places an order with the store.
        /// </summary>
        /// <param name="productId">The ID of the product to order.</param>
        /// <param name="quantity">The quantity of the product to order.</param>
        /// <param name="accountName">The account name of the customer.</param>
        /// <param name="cardNumber">The payment card number of the customer.</param>
        /// <returns></returns>
        OrderLine PlaceOrder(int productId, int quantity, string accountName, string cardNumber);

        /// <summary>
        /// Deletes (cancels) the order with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the order to be deleted.</param>
        bool DeleteOrder(int id);

        /// <summary>
        /// Retrieves the order with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the order to be retrieved.</param>
        /// <returns></returns>
        OrderLine GetOrder(int id);
    }
}
