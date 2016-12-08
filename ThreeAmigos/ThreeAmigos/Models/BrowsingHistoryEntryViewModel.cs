using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.Models
{
    public class BrowsingHistoryEntryViewModel
    {
        /// <summary>
        /// Gets or sets the ID of this browsing history entry in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the device this entry was created on.
        /// </summary>
        public DeviceViewModel Device { get; set; }

        /// <summary>
        /// Gets or sets the date and time of this entry.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the product this entry relates to.
        /// </summary>
        public ProductViewModel Product { get; set; }
    }
}