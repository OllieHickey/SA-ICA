using System.Collections.Generic;

namespace ThreeAmigos.Domain.Store
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the database ID for the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of this product as held by the provider.
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the International (European) Article Number of the product.
        /// </summary>
        public string Ean { get; set; }

        /// <summary>
        /// Gets or sets a collection of prices for quantities of this product.
        /// </summary>
        public IEnumerable<Price> Prices { get; set; }

        /// <summary>
        /// Gets or sets the name of this product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a collection of brands for this product.
        /// </summary>
        public IEnumerable<Brand> Brands { get; set; }

        /// <summary>
        /// Gets or sets the a collection of categories for this product.
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets a text-based description of this product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets whether or not this product is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the code for the supplier of this product.
        /// </summary>
        public SupplierCode SupplierCode { get; set; }
    }
}
