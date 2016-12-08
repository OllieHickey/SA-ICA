using System.Collections.Generic;

using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Implemented by aggregator classes capable of combining data across many gift-wrapping supplier adapters.
    /// </summary>
    public interface IGiftWrappingSupplierAggregator
    {
        /// <summary>
        /// Gets a set of gift-wrapping supplier adapters aggregated by this instance.
        /// </summary>
        IEnumerable<IGiftWrappingSupplierAdapter> Suppliers { get; }

        /// <summary>
        /// Gets a collection of errors that occurred during the last operation on this aggregator.
        /// </summary>
        IEnumerable<ISupplierError> Errors { get; }

        /// <summary>
        /// Gets whether or not this aggregator experienced an error during its last operation.
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// Retrieves all gift-wrapping products from every supplier.
        /// </summary>
        /// <returns></returns>
        IEnumerable<GiftWrappingProduct> GetAllGiftWrappingProducts();

        /// <summary>
        /// Retrieves a collection of products from every gift-wrapping supplier that match the given criteria.
        /// </summary>
        /// <param name="typeId">The gift-wrapping product type identifier.</param>
        /// <param name="rangeId">The gift-wrapping product range identifier.</param>
        /// <param name="minPrice">The minimum price of gift-wrapping products to return.</param>
        /// <param name="maxPrice">The maximum price of gift-wrapping products to return.</param>
        /// <param name="minSize">The minimum size of gift-wrapping products to return.</param>
        /// <param name="maxSize">The maximum size of gift-wrapping products to return.</param>
        /// <returns></returns>
        /// <returns></returns>
        IEnumerable<GiftWrappingProduct> SearchGiftWrappingProducts(
            int? typeId = null,
            int? rangeId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            decimal? minSize = null,
            decimal? maxSize = null);

        /// <summary>
        /// Retrieves the gift-wrapping product from a particular supplier with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the gift-wrapping product.</param>
        /// <param name="supplier">The supplier code of the gift-wrapping supplier to query.</param>
        /// <returns></returns>
        GiftWrappingProduct GetGiftWrappingProductById(int id, SupplierCode supplier);

        /// <summary>
        /// Retrieves allgift-wrapping types from every supplier.
        /// </summary>
        /// <returns></returns>
        IEnumerable<GiftWrappingType> GetAllGiftWrappingTypes();

        /// <summary>
        /// Retrieves the gift-wrapping type from a particular supplier with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the gift-wrapping type.</param>
        /// <param name="supplier">The supplier code of the gift-wrapping supplier to query.</param>
        /// <returns></returns>
        GiftWrappingType GetGiftWrappingTypeById(int id, SupplierCode supplier);

        /// <summary>
        /// Retrieves all gift-wrapping ranges from every supplier.
        /// </summary>
        /// <returns></returns>
        IEnumerable<GiftWrappingRange> GetAllGiftWrappingRanges();

        /// <summary>
        /// Retrieves the gift-wrapping range from a particular supplier with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the gift-wrapping range.</param>
        /// <param name="supplier">The supplier code of the gift-wrapping supplier to query.</param>
        /// <returns></returns>
        GiftWrappingRange GetGiftWrappingRangeById(int id, SupplierCode supplier);

        /// <summary>
        /// Places an order with a particular gift-wrapping supplier.
        /// </summary>
        /// <param name="productId">The ID of the product to order.</param>
        /// <param name="quantity">The quantity of the product to order.</param>
        /// <param name="accountName">The account name of the customer.</param>
        /// <param name="cardNumber">The payment card number of the customer.</param>
        /// <param name="supplier">The supplier code of the gift-wrapping supplier to place the order with.</param>
        /// <returns></returns>
        Order PlaceOrder(int productId, int quantity, string accountName, string cardNumber, SupplierCode supplier);
    }
}
