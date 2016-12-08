using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.Models
{
    public class BrandViewModel
    {
        /// <summary>
        /// Gets or sets the database ID for the brand.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of this brand as held by the provider.
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the customer-facing name of the brand.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether or not the brand is currently enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the collection of products belonging to this brand.
        /// </summary>
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}