using System.Collections.Generic;

namespace ThreeAmigos.Data.Models.Store
{
    /// <summary>
    /// Represents a gift-wrapping product.
    /// </summary>
    public class GiftWrappingProduct
    {
        /// <summary>
        /// Gets or sets the database ID for the gift-wrapping product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of this gift-wrapping product as held by the provider.
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the type of this gift-wrapping product.
        /// </summary>
        public GiftWrappingType Type { get; set; }

        /// <summary>
        /// Gets or sets the range for this gift-wrapping product.
        /// </summary>
        public GiftWrappingRange Range { get; set; }

        /// <summary>
        /// Gets or sets the price of this gift-wrapping product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the size of this gift-wrapping product.
        /// </summary>
        public decimal Size { get; set; }

        /// <summary>
        /// Gets or sets the products 'wrappable' by this gift wrap.
        /// </summary>
        public virtual List<Product> Products { get; set; }
    }
}
