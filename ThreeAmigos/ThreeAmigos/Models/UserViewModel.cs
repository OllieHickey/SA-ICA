using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ThreeAmigos.Models
{
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets the ID of the user in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the roles this user has in the application.
        /// </summary>
        public IEnumerable<RoleViewModel> Roles { get; set; }

        /// <summary>
        /// Gets or sets the user's browsing history.
        /// </summary>
        public IEnumerable<BrowsingHistoryEntryViewModel> BrowsingHistory { get; set; }

        /// <summary>
        /// Gets or sets the user's given name.
        /// </summary>
        [DisplayName("Forename")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the user's family name.
        /// </summary>
        [DisplayName("Surname")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the user's telephone number.
        /// </summary>
        [DisplayName("Phone Number")]
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the user's login username.
        /// </summary>
        [DisplayName("Username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        [DisplayName("E-mail")]
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
        [DisplayName("Registration Date")]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Gets or sets the amount of store credit on the user's account
        /// </summary>
        [DisplayName("Account Credit Amount")]
        public float AccountCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the user's postal address.
        /// </summary>
        [DisplayName("Address")]
        public AddressViewModel Address { get; set; }

        /// <summary>
        /// Gets or sets the user's shopping basket.
        /// </summary>
        //public ShoppingBasket Basket { get; set; }
    }
}