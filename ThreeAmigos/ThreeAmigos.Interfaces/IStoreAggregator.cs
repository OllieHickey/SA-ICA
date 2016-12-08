using System.Collections.Generic;

using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Implemented by aggregator classes capable of combining data across many store adapters.
    /// </summary>
    public interface IStoreAggregator
    {
        /// <summary>
        /// Gets a set of store adapters aggregated by this instance.
        /// </summary>
        IEnumerable<IStoreAdapter> Stores { get; }

        /// <summary>
        /// Gets a collection of errors that occurred during the last operation on this aggregator.
        /// </summary>
        IEnumerable<ISupplierError> Errors { get; }

        /// <summary>
        /// Gets whether or not this aggregator experienced an error during its last operation.
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// Retrieves all products from every store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Retrieves a collection of products from every store that match the given criteria.
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
        /// Retrieves the product from a particular store with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <param name="supplier">The supplier code of the store to query.</param>
        /// <returns></returns>
        Product GetProductById(int id, SupplierCode supplier);

        /// <summary>
        /// Retrieves all categories from every store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetAllCategories();

        /// <summary>
        /// Retrieves the category from a particular store with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        /// <param name="supplier">The supplier code of the store to query.</param>
        /// <returns></returns>
        Category GetCategoryById(int id, SupplierCode supplier);

        /// <summary>
        /// Retrieves all brands from every store.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Brand> GetAllBrands();

        /// <summary>
        /// Retrieves the brand from a particular store with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the brand.</param>
        /// <param name="supplier">The supplier code of the store to query.</param>
        /// <returns></returns>
        Brand GetBrandById(int id, SupplierCode supplier);

        /// <summary>
        /// Places an order with a particular store.
        /// </summary>
        /// <param name="productId">The ID of the product to order.</param>
        /// <param name="quantity">The quantity of the product to order.</param>
        /// <param name="accountName">The account name of the customer.</param>
        /// <param name="cardNumber">The payment card number of the customer.</param>
        /// <param name="supplier">The supplier code of the store to place the order with.</param>
        /// <returns></returns>
        OrderLine PlaceOrder(int productId, int quantity, string accountName, string cardNumber, SupplierCode supplier);

        /// <summary>
        /// Deletes (cancels) the order with the specified ID on a particular store.
        /// </summary>
        /// <param name="id">The ID of the order to be deleted.</param>
        /// <param name="supplier">The supplier code of the store to cancel the order with.</param>
        bool DeleteOrder(int id, SupplierCode supplier);

        /// <summary>
        /// Retrieves the order with the specified ID from a particular store.
        /// </summary>
        /// <param name="id">The ID of the order to be retrieved.</param>
        /// <param name="supplier">The supplier code of the store to retrieve the order from.</param>
        /// <returns></returns>
        OrderLine GetOrder(int id, SupplierCode supplier);

        /// <summary>
        /// Gets the health status of the API that underlies this store adapter.
        /// </summary>
        /// <param name="supplier">The supplier code of the API to check.</param>
        /// <returns></returns>
        ApiHealthStatus GetHealthStatus(SupplierCode supplier);
    }
}
