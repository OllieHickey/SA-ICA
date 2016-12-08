namespace ThreeAmigos.Data.Models.Store
{
    /// <summary>
    /// Represents a line in an order.
    /// </summary>
    /// <seealso cref="Order"/>
    public class OrderLine
    {
        /// <summary>
        /// Gets or sets the database ID for this order line.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order ID for this order line as held by the supplier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the Order object for this order line.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Gets or sets the product that this order line relates to.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product in the order line.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the supplier code for this order line.
        /// </summary>
        public SupplierCode SupplierCode { get; set; }
    }
}
