using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeAmigos.Models
{
    public class RoleViewModel
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
    }
}