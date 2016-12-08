using System.Collections.Generic;

namespace ThreeAmigos.Data.Models.Account
{
    /// <summary>
    /// Represents a role that a user can have in the system.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// The ID of the role in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The access level that this role grants.
        /// </summary>
        public int AccessLevel { get; set; } // TODO: Discuss this.

        /// <summary>
        /// Whether or not this role is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the list of users who are a member of this role.
        /// </summary>
        public virtual List<User> Users { get; set; }
    }
}
