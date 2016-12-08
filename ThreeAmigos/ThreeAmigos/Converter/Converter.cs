using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeAmigos.Domain.Account;
using ThreeAmigos.Domain.Store;
using ThreeAmigos.Models;

namespace ThreeAmigos.Converters
{
    public class Converter
    {

        #region Products

        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                ProviderId = product.ProviderId,
                Ean = product.Ean,
                Prices = product.Prices.Select(ToPriceViewModel),
                Name = product.Name,
                Description = product.Description,
                Enabled = product.Enabled,
                SupplierCode = (SupplierCodeViewModel)product.SupplierCode
            };
        }

        public static PriceViewModel ToPriceViewModel(Price price)
        {
            return new PriceViewModel
            {
                Id = price.Id,
                Amount = price.Amount,
                Quantity = price.Quantity
            };
        }

        #endregion Products

        #region Brands

        public static BrandViewModel ToBrandViewModel(Brand brand)
        {
            IEnumerable<ProductViewModel> products = new List<ProductViewModel>();
            return (ToBrandViewModel(brand, products.AsEnumerable()));
        }

        public static BrandViewModel ToBrandViewModel(Brand brand, IEnumerable<ProductViewModel> products)
        {
            return new BrandViewModel
            {
                Id = brand.Id,
                Name = brand.Name,
                ProviderId = brand.ProviderId,
                Enabled = brand.Enabled,
                Products = products
            };
        }

        #endregion Brands

        #region Categories

        public static CategoryViewModel ToCategoryViewModel(Category category)
        {
            IEnumerable<ProductViewModel> products = new List<ProductViewModel>();
            return (ToCategoryViewModel(category, products.AsEnumerable()));
        }

        public static CategoryViewModel ToCategoryViewModel(Category category, IEnumerable<ProductViewModel> products)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Enabled = category.Enabled,
                ProviderId = category.ProviderId,
                Products = products
            };
        }

        #endregion Categories

        #region Account

        public static DeviceViewModel ToDeviceViewModel(Device device)
        {
            return new DeviceViewModel
            {
                Id = device.Id,
                DisplayName = device.DisplayName,
                Manufacturer = device.Manufacturer,
                Model = device.Model,
                Notes = device.Notes,
                OperatingSystem = device.OperatingSystem,
                Version = device.Version
            };
        }

        public static BrowsingHistoryEntryViewModel ToBrowsingHistoryEntryViewModel(BrowsingHistoryEntry browsingHistoryEntry)
        {
            return new BrowsingHistoryEntryViewModel
            {
                Id = browsingHistoryEntry.Id,
                Product = ToProductViewModel(browsingHistoryEntry.Product),
                Device = ToDeviceViewModel(browsingHistoryEntry.Device),
                Timestamp = browsingHistoryEntry.Timestamp
            };
        }

        public static AddressViewModel ToAddressViewModel(Address address)
        {
            return new AddressViewModel
            {
                Id = address.Id,
                FirstLine = address.FirstLine,
                HouseName = address.HouseName,
                HouseNumber = address.HouseNumber,
                Postcode = address.Postcode,
                SecondLine = address.SecondLine,
                ThirdLine = address.ThirdLine,
                Town = address.Town
            };
        }

        public static RoleViewModel ToRoleViewModel(Role role)
        {
            return new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                AccessLevel = role.AccessLevel
            };
        }

        public static UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                BrowsingHistory = user.BrowsingHistory.Select(ToBrowsingHistoryEntryViewModel),
                Address = ToAddressViewModel(user.Address),
                AccountCreditAmount = user.AccountCreditAmount,
                Email = user.Email,
                FamilyName = user.FamilyName,
                GivenName = user.GivenName,
                PasswordHash = user.PasswordHash,
                RegistrationDate = user.RegistrationDate,
                Roles = user.Roles.Select(ToRoleViewModel),
                Salt = user.Salt,
                Telephone = user.Telephone,
                Username = user.Username
            };
        }

        #endregion Account

    }
}