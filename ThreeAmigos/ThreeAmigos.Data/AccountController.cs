using System.Collections.Generic;
using System.Linq;
using ThreeAmigos.Data.Models.Account;

namespace ThreeAmigos.Data
{
    public class AccountController
    {
        private readonly AccountDbModel model = new AccountDbModel();

        public void CreateAddress(Address address)
        {
            model.Addresses.Add((address));
            model.SaveChanges();
        }

        public void CreateAuthToken(AuthToken at)
        {
            model.AuthTokens.Add(at);
            model.SaveChanges();
        }

        public void CreateBrowsingHistoryEntry(BrowsingHistoryEntry bhe)
        {
            model.BrowsingHistoryEntries.Add(bhe);
            model.SaveChanges();
        }

        public void CreateDevice(Device device)
        {
            model.Devices.Add(device);
            model.SaveChanges();
        }

        public void CreateNewUser(User user)
        {
            model.Users.Add(user);
            model.SaveChanges();
        }

        public void CreateRole(Role role)
        {
            model.Roles.Add(role);
            model.SaveChanges();
        }

        public void DeleteAddress(Address address)
        {
            model.Addresses.Remove(address);
            model.SaveChanges();
        }

        public void DeleteAuthToken(AuthToken at)
        {
            model.AuthTokens.Remove(at);
            model.SaveChanges();
        }

        public void DeleteBrowsingHistoryEntry(BrowsingHistoryEntry bhe)
        {
            model.BrowsingHistoryEntries.Remove(bhe);
            model.SaveChanges();
        }

        public void DeleteDevice(Device device)
        {
            model.Devices.Remove(device);
            model.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            model.Roles.Remove(role);
            model.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            model.Users.Remove(user);
            model.SaveChanges();
        }

        public Address RetrieveAddress(int id)
        {
            return model.Addresses.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Address> RetrieveAddressesForUser(int id)
        {
            return model.Addresses.Where(a => a.User.Id == id).ToList();
        }

        public AuthToken RetrieveAuthToken(string token)
        {
            return model.AuthTokens.FirstOrDefault(at => at.Token == token);
        }

        public BrowsingHistoryEntry RetrieveBrowsingHistoryEntry(int id)
        {
            return model.BrowsingHistoryEntries.FirstOrDefault(bhe => bhe.Id == id);
        }

        public Device RetrieveDevice(int id)
        {
            return model.Devices.FirstOrDefault(d => d.Id == id);
        }

        public ICollection<Device> RetrieveDevicesForUser(int id)
        {
            return model.Devices.Where(d => d.User.Id == id).ToList();
        }

        public Role RetrieveRole(int id)
        {
            return model.Roles.FirstOrDefault(r => r.Id == id);
        }

        public User RetrieveUser(int id)
        {
            return model.Users.FirstOrDefault(u => u.Id == id);
        }

        public User RetrieveUserByUsername(string username)
        {
            return model.Users.FirstOrDefault(u => u.Username == username);
        }

        public User RetrieveUserByEmailAddress(string emailAddress)
        {
            return model.Users.FirstOrDefault(u => u.Email == emailAddress);
        }

        public void UpdateAddress(Address address)
        {
            if (address == null) return;
            var toUpdate = model.Addresses.FirstOrDefault(a => a.Id == address.Id);
            toUpdate = address;
            model.SaveChanges();
        }

        public void UpdateAuthToken(AuthToken at)
        {
            if (at == null) return;
            var toUpdate = model.AuthTokens.FirstOrDefault(auth => at.Id == auth.Id);
            toUpdate = at;
            model.SaveChanges();
        }

        public void UpdateBrowsingHistoryEntry(BrowsingHistoryEntry bhe)
        {
            if (bhe == null) return;
            var toUpdate = model.BrowsingHistoryEntries.FirstOrDefault(hist => bhe.Id == hist.Id);
            toUpdate = bhe;
            model.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
            if (device == null) return;
            var toUpdate = model.Devices.FirstOrDefault(dev => dev.Id == device.Id);
            toUpdate = device;
            model.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            if (role == null) return;
            var toUpdate = model.Roles.FirstOrDefault(r => r.Id == role.Id);
            toUpdate = role;
            model.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            if (user == null) return;
            var toUpdate = model.Users.FirstOrDefault(u => u.Id == user.Id);
            toUpdate = user;
            model.SaveChanges();
        }
    }
}