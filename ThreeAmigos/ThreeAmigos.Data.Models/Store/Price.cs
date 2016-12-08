namespace ThreeAmigos.Data.Models.Store
{
    /// <summary>
    /// Represents an product's price.
    /// </summary>
    /// <seealso cref="Product"/>
    public class Price
    {
        /// <summary>
        /// Gets or sets the database ID for this price.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity of products this price relates to.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount for this price.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the associated product.
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
