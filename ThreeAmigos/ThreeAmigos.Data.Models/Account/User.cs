using System;
using System.Collections.Generic;

using ThreeAmigos.Data.Models.Store;

namespace ThreeAmigos.Data.Models.Account
{
    /// <summary>
    /// Represents a user with an account on the website.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the ID of the user in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the roles this user has in the application.
        /// </summary>
        public virtual List<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the user's browsing history.
        /// </summary>
        public virtual List<BrowsingHistoryEntry> BrowsingHistory { get; set; }

        /// <summary>
        /// Gets or sets the user's given name.
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the user's family name.
        /// </summary>
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the user's telephone number.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the user's login username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the SHA-256 hash of the user's password.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the salt used to hash the user's password.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Gets or sets the date and time that the user registered.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of store credit on the user's account
        /// </summary>
        public float AccountCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the user's postal address.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets whether or not the user is enabled in the database.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the orders this user has placed.
        /// </summary>
        public virtual List<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the user's shopping basket.
        /// </summary>
        public ShoppingBasket Basket { get; set; }

        /// <summary>
        /// Gets or sets the list of devices this user has used.
        /// </summary>
        public virtual List<Device> Devices { get; set; }


    }
}