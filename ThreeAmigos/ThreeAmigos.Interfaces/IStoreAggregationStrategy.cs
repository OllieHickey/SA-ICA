using System.Collections.Generic;

using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Implemented by strategies used to aggregate domain models recieved from different store adapters.
    /// </summary>
    public interface IStoreAggregationStrategy
    {
        /// <summary>
        /// Aggregates collection of brands.
        /// </summary>
        /// <param name="brands">The brands to aggregate.</param>
        /// <returns></returns>
        IEnumerable<Brand> ApplyBrandAggregationStrategy(IEnumerable<Brand> brands);

        /// <summary>
        /// Aggregates a collection of categories.
        /// </summary>
        /// <param name="categories">The categories to aggregate.</param>
        /// <returns></returns>
        IEnumerable<Category> ApplyCategoryAggregationStrategy(IEnumerable<Category> categories);

        /// <summary>
        /// Aggregates a collection of products.
        /// </summary>
        /// <param name="products">The products to aggregate.</param>
        /// <returns></returns>
        IEnumerable<Product> ApplyProductAggregationStrategy(IEnumerable<Product> products);
    }
}
