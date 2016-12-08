using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeAmigos.Domain.Account;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Implemented by services exposing account functionality for the application.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Gets a user by their ID (primary key).
        /// </summary>
        /// <param name="id">The ID of the user to get.</param>
        /// <returns></returns>
        User GetUserById(int id);

        /// <summary>
        /// Gets a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to get.</param>
        /// <returns></returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Gets a user by their email address.
        /// </summary>
        /// <param name="emailAddress">The email address of the user to get.</param>
        /// <returns></returns>
        User GetUserByEmailAddress(string emailAddress);

        /// <summary>
        /// Gets a user by their username or email address.
        /// </summary>
        /// <param name="usernameOrEmailAddress">The username or email address of the usert to get.</param>
        /// <returns></returns>
        User GetUserByUsernameOrEmailAddress(string usernameOrEmailAddress);
    }
}
