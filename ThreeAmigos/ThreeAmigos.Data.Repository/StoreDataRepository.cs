using System.Collections.Generic;
using System.Linq;

using ThreeAmigos.Data.Models.Store;
using ThreeAmigos.Interfaces;

namespace ThreeAmigos.Data.Repository
{
    public class StoreDataRepository : IStoreRepository
    {
        /// <summary>
        /// Data controller object.
        /// </summary>
        private readonly StoreController _controller = new StoreController();

        #region Product

        public void CreateProduct(Product product)
        {
            _controller.CreateProduct(product);
        }

        public IEnumerable<Product> RetrieveAllProducts()
        {
            return _controller.RetrieveAllProducts();
        }

        public Product RetrieveProductById(int id)
        {
            return _controller.RetrieveProduct(id);
        }

        public Product RetrieveProductByEan(string ean)
        {
            return _controller.RetrieveProduct(ean);
        }

        public ICollection<Product> RetrieveProductsByBrandId(int brandId)
        {
            return _controller.RetrieveProductsByBrandId(brandId);
        }

        public ICollection<Product> RetrieveProductsByCategoryId(int categoryId)
        {
            return _controller.RetrieveProductsByCategoryId(categoryId);
        }

        public void UpdateProduct(Product product)
        {
            _controller.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            _controller.DeleteProduct(product);
        }

        public void DeleteProductByEan(string ean)
        {
            _controller.DeleteProductByEan(ean);
        }

        #endregion

        #region Brand

        public void CreateBrand(Brand brand)
        {
            _controller.CreateBrand(brand);
        }

        public ICollection<Brand> RetrieveAllBrands()
        {
            return _controller.RetrieveAllBrands();
        }

        public Brand RetrieveBrandById(int id)
        {
            return _controller.RetrieveBrandById(id);
        }

        public void UpdateBrand(Brand brand)
        {
            _controller.UpdateBrand(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            _controller.DeleteBrand(brand);
        }

        #endregion

        #region Category

        public void CreateCategory(Category category)
        {
            _controller.CreateCategory(category);
        }

        public ICollection<Category> RetrieveAllCategories()
        {
            return _controller.RetrieveAllCategories();
        }

        public Category RetrieveCategoryById(int id)
        {
            return _controller.RetrieveCategory(id);
        }

        public void UpdateCategory(Category category)
        {
            _controller.UpdateCategory(category);
        }

        public void DeleteCategory(Category category)
        {
            _controller.DeleteCategory(category);
        }

        #endregion

        #region Price

        public void CreatePrice(Price price)
        {
            _controller.CreatePrice(price);
        }

        public Price RetrievePriceById(int id)
        {
            return _controller.RetrievePriceById(id);
        }

        public ICollection<Price> RetrievePricesByProductId(int productId)
        {
            return _controller.RetrievePricesByProductId(productId);
        }

        public void UpdatePrice(Price price)
        {
            _controller.UpdatePrice(price);
        }

        public void DeletePrice(Price price)
        {
            _controller.DeletePrice(price);
        }

        #endregion

        #region GiftWrappingType

        public void CreateGiftWrappingType(GiftWrappingType giftWrappingType)
        {
            _controller.CreateGiftWrappingType(giftWrappingType);
        }

        public GiftWrappingType RetrieveGiftWrappingTypeById(int id)
        {
            return _controller.RetrieveGiftWrappingTypeById(id);
        }

        public void UpdateGiftWrappingType(GiftWrappingType giftWrappingType)
        {
            _controller.UpdateGiftWrappingType(giftWrappingType);
        }

        public void DeleteGiftWrappingType(GiftWrappingType giftWrappingType)
        {
            _controller.DeleteGiftWrappingType(giftWrappingType);
        }

        #endregion

        #region GiftWrappingRange

        public void CreateGiftWrappingRange(GiftWrappingRange giftWrappingRange)
        {
            _controller.CreateGiftWrappingRange(giftWrappingRange);
        }

        public GiftWrappingRange RetrieveGiftWrappingRangeById(int id)
        {
            return _controller.RetrieveGiftWrappingRangeById(id);
        }

        public void UpdateGiftWrappingRange(GiftWrappingRange giftWrappingRange)
        {
            _controller.UpdateGiftWrappingRange(giftWrappingRange);
        }

        public void DeleteGiftWrappingRange(GiftWrappingRange giftWrappingRange)
        {
            _controller.DeleteGiftWrappingRange(giftWrappingRange);
        }

        #endregion

        #region GiftWrappingProduct

        public void CreateGiftWrappingProduct(GiftWrappingProduct giftWrappingProduct)
        {
            _controller.CreateGiftWrappingProduct(giftWrappingProduct);
        }

        public GiftWrappingProduct RetrieveGiftWrappingProductById(int id)
        {
            return _controller.RetrieveGiftWrappingProduct(id);
        }

        public void UpdateGiftWrappingProduct(GiftWrappingProduct giftWrappingProduct)
        {
            _controller.UpdateGiftWrappingProduct(giftWrappingProduct);
        }

        public void DeleteGiftWrappingProduct(GiftWrappingProduct giftWrappingProduct)
        {
            _controller.DeleteGiftWrappingProduct(giftWrappingProduct);
        }

        #endregion

        #region Order

        public void CreateOrder(Order order)
        {
            _controller.CreateOrder(order);
        }

        public Order RetrieveOrderById(int id)
        {
            return _controller.RetrieveOrderById(id);
        }

        public ICollection<Order> RetrieveOrdersByUserId(int userId)
        {
            return _controller.RetrieveOrdersByUserId(userId);
        }

        public void UpdateOrder(Order order)
        {
            _controller.UpdateOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            _controller.DeleteOrder(order);
        }

        #endregion

        #region OrderLine

        public void CreateOrderLine(OrderLine orderLine)
        {
            _controller.CreateOrderLine(orderLine);
        }

        public OrderLine RetrieveOrderLineById(int id)
        {
            return _controller.RetrieveOrderLineById(id);
        }

        public ICollection<OrderLine> RetrieveOrderLinesByOrderId(int orderId)
        {
            return _controller.RetrieveOrderLinesByOrderId(orderId);
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            _controller.UpdateOrderLine(orderLine);
        }

        public void DeleteOrderLine(OrderLine orderLine)
        {
            _controller.DeleteOrderLine(orderLine);
        }

        #endregion
    }
}
