using System.Collections.Generic;

using ThreeAmigos.Data.Models.Store;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Interface for the Store Data Repository
    /// </summary>
    public interface IStoreRepository
    {
        #region Product

        void CreateProduct(Product product);

        IEnumerable<Product> RetrieveAllProducts();

        Product RetrieveProductById(int id);

        Product RetrieveProductByEan(string ean);

        ICollection<Product> RetrieveProductsByBrandId(int brandId);

        ICollection<Product> RetrieveProductsByCategoryId(int categoryId);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        void DeleteProductByEan(string ean);

        #endregion

        #region Brand

        void CreateBrand(Brand brand);

        ICollection<Brand> RetrieveAllBrands();

        Brand RetrieveBrandById(int id);

        void UpdateBrand(Brand brand);

        void DeleteBrand(Brand brand);

        #endregion

        #region Category

        void CreateCategory(Category category);

        ICollection<Category> RetrieveAllCategories();

        Category RetrieveCategoryById(int id);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);

        #endregion

        #region Price

        void CreatePrice(Price price);

        Price RetrievePriceById(int id);

        ICollection<Price> RetrievePricesByProductId(int productId);

        void UpdatePrice(Price price);

        void DeletePrice(Price price);

        #endregion

        #region GiftWrappingType

        void CreateGiftWrappingType(GiftWrappingType giftWrappingType);

        GiftWrappingType RetrieveGiftWrappingTypeById(int id);

        void UpdateGiftWrappingType(GiftWrappingType giftWrappingType);

        void DeleteGiftWrappingType(GiftWrappingType giftWrappingType);

        #endregion

        #region GiftWrappingRange

        void CreateGiftWrappingRange(GiftWrappingRange giftWrappingRange);

        GiftWrappingRange RetrieveGiftWrappingRangeById(int id);

        void UpdateGiftWrappingRange(GiftWrappingRange giftWrappingRange);

        void DeleteGiftWrappingRange(GiftWrappingRange giftWrappingRange);

        #endregion

        #region GiftWrappingProduct

        void CreateGiftWrappingProduct(GiftWrappingProduct giftWrappingProduct);

        GiftWrappingProduct RetrieveGiftWrappingProductById(int id);

        void UpdateGiftWrappingProduct(GiftWrappingProduct giftWrappingProduct);

        void DeleteGiftWrappingProduct(GiftWrappingProduct giftWrappingProduct);

        #endregion

        #region Order

        void CreateOrder(Order order);

        Order RetrieveOrderById(int id);

        ICollection<Order> RetrieveOrdersByUserId(int userId);

        void UpdateOrder(Order order);

        void DeleteOrder(Order order);

        #endregion

        #region OrderLine

        void CreateOrderLine(OrderLine orderLine);

        OrderLine RetrieveOrderLineById(int id);

        ICollection<OrderLine> RetrieveOrderLinesByOrderId(int orderId);

        void UpdateOrderLine(OrderLine orderLine);

        void DeleteOrderLine(OrderLine orderLine);

        #endregion
    }
}
