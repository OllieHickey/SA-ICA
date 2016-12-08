using System.Collections.Generic;

using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Implemented by gift-wrapping supplier adapter classes capable of converting between supplier-specific 
    /// data models and the system domain model.
    /// </summary>
    public interface IGiftWrappingSupplierAdapter
    {
        /// <summary>
        /// Gets the supplier code for the supplier this adapter is designed to work with.
        /// </summary>
        SupplierCode SupplierCode { get; }

        /// <summary>
        /// Retrieves all gift-wrapping products from the supplier.
        /// </summary>
        /// <returns></returns>
        IEnumerable<GiftWrappingProduct> GetAllGiftWrappingProducts();

        /// <summary>
        /// Retrieves a collection of gift-wrapping products from the supplier that match the given criteria.
        /// </summary>
        /// <param name="typeId">The gift-wrapping product type identifier.</param>
        /// <param name="rangeId">The gift-wrapping product range identifier.</param>
        /// <param name="minPrice">The minimum price of gift-wrapping products to return.</param>
        /// <param name="maxPrice">The maximum price of gift-wrapping products to return.</param>
        /// <param name="minSize">The minimum size of gift-wrapping products to return.</param>
        /// <param name="maxSize">The maximum size of gift-wrapping products to return.</param>
        /// <returns></returns>
        IEnumerable<GiftWrappingProduct> SearchGiftWrappingProducts(
            int? typeId = null,
            int? rangeId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null,
            decimal? minSize = null,
            decimal? maxSize = null);

        /// <summary>
        /// Retrieves the gift-wrapping product from the supplier with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the gift-wrapping product.</param>
        /// <returns></returns>
        GiftWrappingProduct GetGiftWrappingProductById(int id);

        /// <summary>
        /// Retrieves a collection of all gift-wrapping types from the supplier.
        /// </summary>
        /// <returns>.</returns>
        IEnumerable<GiftWrappingType> GetAllGiftWrappingTypes();

        /// <summary>
        /// Retrieves the gift-wrapping type from the supplier with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the type.</param>
        /// <returns></returns>
        GiftWrappingType GetGiftWrappingTypeById(int id);

        /// <summary>
        /// Retrieves a collection of gift-wrapping ranges from the supplier.
        /// </summary>
        /// <returns></returns>
        IEnumerable<GiftWrappingRange> GetAllGiftWrappingRanges();

        /// <summary>
        /// Retrieves the gift-wrapping range from the supplier with the specifed ID.
        /// </summary>
        /// <param name="id">The ID of the gift-wrapping range.</param>
        /// <returns></returns>urns>
        GiftWrappingRange GetGiftWrappingRangeById(int id);

        /// <summary>
        /// Places an order with the supplier.
        /// </summary>
        /// <param name="productId">The ID of the gift-wrapping product to order.</param>
        /// <param name="quantity">The quantity of the gift-wrapping product to order.</param>
        /// <param name="accountName">The account name of the customer.</param>
        /// <param name="cardNumber">The payment card number of the customer.</param>
        /// <returns></returns>
        Order PlaceOrder(int productId, int quantity, string accountName, string cardNumber);
    }
}
