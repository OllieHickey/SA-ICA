using System.Collections.Generic;
using System.Linq;
using ThreeAmigos.Data.Models.Account;
using ThreeAmigos.Interfaces;

namespace ThreeAmigos.Data.Repository
{
    public class AccountDataRepository : IAccountRepository
    {
        /// <summary>
        /// Data controller object.
        /// </summary>
        private readonly AccountController _controller = new AccountController();

        public void CreateAddress(Address address)
        {
            _controller.CreateAddress(address);
        }

        public void CreateAuthToken(AuthToken at)
        {
            _controller.CreateAuthToken(at);
        }

        public void CreateBrowsingHistoryEntry(BrowsingHistoryEntry bhe)
        {
            _controller.CreateBrowsingHistoryEntry(bhe);
        }

        public void CreateDevice(Device device)
        {
            _controller.CreateDevice(device);
        }

        public void CreateNewUser(User user)
        {
            _controller.CreateNewUser(user);
        }

        public void CreateRole(Role role)
        {
            _controller.CreateRole(role);
        }

        public void DeleteAddress(Address address)
        {
            _controller.DeleteAddress(address);
        }

        public void DeleteAuthToken(AuthToken at)
        {
            _controller.DeleteAuthToken(at);
        }

        public void DeleteBrowsingHistoryEntry(BrowsingHistoryEntry bhe)
        {
            _controller.DeleteBrowsingHistoryEntry(bhe);
        }

        public void DeleteDevice(Device device)
        {
            _controller.DeleteDevice(device);
        }

        public void DeleteRole(Role role)
        {
            _controller.DeleteRole(role);
        }

        public void DeleteUser(User user)
        {
            _controller.DeleteUser(user);
        }

        public Address RetrieveAddress(int id)
        {
            return _controller.RetrieveAddress(id);
        }

        public ICollection<Address> RetrieveAddressesForUser(int id)
        {
            return _controller.RetrieveAddressesForUser(id).ToList();
        }

        public AuthToken RetrieveAuthToken(string token)
        {
            return _controller.RetrieveAuthToken(token);
        }

        public BrowsingHistoryEntry RetrieveBrowsingHistoryEntry(int id)
        {
            return _controller.RetrieveBrowsingHistoryEntry(id);
        }

        public Device RetrieveDevice(int id)
        {
            return _controller.RetrieveDevice(id);
        }

        public ICollection<Device> RetrieveDevicesForUser(int id)
        {
            return _controller.RetrieveDevicesForUser(id);
        }

        public Role RetrieveRole(int id)
        {
            return _controller.RetrieveRole(id);
        }

        public User RetrieveUser(int id)
        {
            return _controller.RetrieveUser(id);
        }

        public User RetrieveUserByUsername(string username)
        {
            return _controller.RetrieveUserByUsername(username);
        }

        public User RetrieveUserByEmailAddress(string emailAddress)
        {
            return _controller.RetrieveUserByEmailAddress(emailAddress);
        }

        public void UpdateAddress(Address address)
        {
            _controller.UpdateAddress(address);
        }

        public void UpdateAuthToken(AuthToken at)
        {
            _controller.UpdateAuthToken(at);
        }

        public void UpdateBrowsingHistoryEntry(BrowsingHistoryEntry bhe)
        {
            _controller.UpdateBrowsingHistoryEntry(bhe);
        }

        public void UpdateDevice(Device device)
        {
            _controller.UpdateDevice(device);
        }

        public void UpdateRole(Role role)
        {
            _controller.UpdateRole(role);
        }

        public void UpdateUser(User user)
        {
            _controller.UpdateUser(user);
        }
    }
}