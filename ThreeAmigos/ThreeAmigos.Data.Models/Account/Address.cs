using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreeAmigos.Data.Models.Account
{
    /// <summary>
    /// Represents a postal address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the ID of this address in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key field mapping this address to a user.
        /// </summary>
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user that this address belongs to.
        /// </summary>
        public virtual User User { get; set; }

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

        /// <summary>
        /// Gets or sets whether or not this address is enabled.
        /// </summary>
        public bool Enabled { get; set; }
    }
}