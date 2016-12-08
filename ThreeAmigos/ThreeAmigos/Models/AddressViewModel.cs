using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.Models
{
    public class AddressViewModel
    {
        /// <summary>
        /// Gets or sets the ID of this address in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the house number component of this address.
        /// </summary>
        public int HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the house name component of this address.
        /// </summary>
        public string HouseName { get; set; }

        /// <summary>
        /// Gets or sets the first line of this address.
        /// </summary>
        public string FirstLine { get; set; }

        /// <summary>
        /// Gets or sets the second line of this address.
        /// </summary>
        public string SecondLine { get; set; }

        /// <summary>
        /// Gets or sets the third line of this address.
        /// </summary>
        public string ThirdLine { get; set; }

        /// <summary>
        /// Gets or sets the town component of this address.
        /// </summary>
        public string Town { get; set; }

        /// <summary>
        /// Gets or sets the postal code component of this address.
        /// </summary>
        public string Postcode { get; set; }
    }
}