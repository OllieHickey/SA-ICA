using System;

using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Domain.Account
{
    /// <summary>
    /// Represents an entry in the user's browsing history.
    /// </summary>
    public class BrowsingHistoryEntry
    {
        /// <summary>
        /// Gets or sets the ID of this browsing history entry in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the device this entry was created on.
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        /// Gets or sets the date and time of this entry.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the product this entry relates to.
        /// </summary>
        public Product Product { get; set; }
    }
}