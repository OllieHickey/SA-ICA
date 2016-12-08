using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Models
{
    public class ProductViewModel
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
        public IEnumerable<PriceViewModel> Prices { get; set; }

        /// <summary>
        /// Gets or sets the name of this product.
        /// </summary>
        public string Name { get; set; }

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
        public SupplierCodeViewModel SupplierCode { get; set; }
    }
}