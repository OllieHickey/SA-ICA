using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.Models
{
    public class PriceViewModel
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
    }
}