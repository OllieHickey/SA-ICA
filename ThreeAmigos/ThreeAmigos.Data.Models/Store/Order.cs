using System;
using System.Collections.Generic;
using ThreeAmigos.Data.Models.Account;

namespace ThreeAmigos.Data.Models.Store
{
    /// <summary>
    ///  Represents an order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the database ID for this order.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The ID of this order as held by the provider.
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the user that placed this order.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the device that this order was placed from.
        /// </summary>
        public virtual Device Device { get; set; }

        /// <summary>
        /// Gets or sets the address that this order should be shipped to.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the date and time that this order was placed.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets whether or not this order is flagged as paid.
        /// </summary>
        public bool IsPaid { get; set; }

        /// <summary>
        /// Gets or sets any notes with additional information about this order.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets a collection of order lines that make up this order.
        /// </summary>
        public virtual IEnumerable<OrderLine> OrderLine { get; set; }
    }
}
