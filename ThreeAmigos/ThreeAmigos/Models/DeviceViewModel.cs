using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.Models
{
    public class DeviceViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the device in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the device.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name of the manufacturer of the device.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the model of the device.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the device's operating system.
        /// </summary>
        public string OperatingSystem { get; set; }

        /// <summary>
        /// Gets or sets the version of the device.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets any notes attached to the device containing additional information.
        /// </summary>
        public string Notes { get; set; }
    }
}