using System;

namespace ThreeAmigos.Data.Models.Account
{
    /// <summary>
    /// Represents an authentication token dispensed to a user who is logged in.
    /// </summary>
    public class AuthToken
    {
        /// <summary>
        /// Gets or sets the ID of this authentication token in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the user that this authentication token belongs to.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the string representation of this authentication token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time for this authentication token.
        /// </summary>
        /// <remarks>A null value represents an authentication token that never expires.</remarks>
        public DateTime? Expires { get; set; }
    }
}
