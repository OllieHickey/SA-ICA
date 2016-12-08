using System.Collections.Generic;
using System.Linq;
using System.Net;

using Microsoft.QueryStringDotNET;

using Newtonsoft.Json;

namespace ThreeAmigos.Integrations.DavisonStore
{
    /// <summary>
    /// An implementation of a proxy designed to work with the Davison Store HTTP web service.
    /// </summary>
    internal class DavisonStoreProxy
    {
        private readonly string _baseUrl;

        private readonly WebClient _client;

        /// <summary>
        /// Initializes a new instance of a proxy designed to work with the Davison Store HTTP web service.
        /// </summary>
        /// <param name="baseUrl">The base URL of the web service.</param>
        public DavisonStoreProxy(string baseUrl)
        {
            _baseUrl = baseUrl + (baseUrl.EndsWith("/") ? "" : "/");
            _client = new WebClient();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return SearchProducts();
        }

        public IEnumerable<Product> SearchProducts(
            int? categoryId = null,
            string categoryName = null,
            int? brandId = null,
            decimal? minPrice = null,
            decimal? maxPrice = null)
        {
            var queryString = new QueryString();
            if (categoryId != null)
            {
                queryString.Add("category_id", categoryId.ToString());
            }
            if (categoryName != null)
            {
                queryString.Add("category_name", categoryName);
            }
            if (brandId != null)
            {
                queryString.Add("brand_id", brandId.ToString());
            }
            if (minPrice != null)
            {
                queryString.Add("min_price", minPrice.ToString());
            }
            if (maxPrice != null)
            {
                queryString.Add("max_price", maxPrice.ToString());
            }

            var json = _client.DownloadString(string.Format("{0}api/Product{1}{2}",
                _baseUrl, queryString.Any() ? "?" : "", queryString));

            return JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
        }

        public Product GetProductById(int id)
        {
            var json = _client.DownloadString(string.Format("{0}api/Product/{1}", _baseUrl, id));
            return JsonConvert.DeserializeObject<Product>(json);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var json = _client.DownloadString(string.Format("{0}api/Category", _baseUrl));
            return JsonConvert.DeserializeObject<IEnumerable<Category>>(json);
        }

        public Category GetCategoryById(int id)
        {

            var json = _client.DownloadString(string.Format("{0}api/Category/{1}", _baseUrl, id));
            return JsonConvert.DeserializeObject<Category>(json);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            var json = _client.DownloadString(string.Format("{0}api/Brand", _baseUrl));
            return JsonConvert.DeserializeObject<IEnumerable<Brand>>(json);
        }

        public Brand GetBrandById(int id)
        {
            var json = _client.DownloadString(string.Format("{0}api/Brand/{1}", _baseUrl, id));
            return JsonConvert.DeserializeObject<Brand>(json);
        }

        public Order PlaceOrder(int productId, int quantity, string accountName, string cardNumber)
        {
            using (var postClient = new WebClient())
            {
                postClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = postClient.UploadString(string.Format("{0}api/Order", _baseUrl),
                    JsonConvert.SerializeObject(new Order
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        AccountName = accountName,
                        CardNumber = cardNumber
                    }));
                return JsonConvert.DeserializeObject<Order>(result);
            }
        }
    }
}
