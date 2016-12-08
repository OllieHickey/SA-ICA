using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Integrations.Aggregator
{
    /// <summary>
    /// A store aggregation strategy that returns unique brands and categories by name and unique products by best
    /// price.
    /// </summary>
    public class BestPriceStoreAggregationStrategy : IStoreAggregationStrategy
    {
        /// <summary>
        /// Normalizes a string identifier by removing spaces and converting to lower case.
        /// </summary>
        /// <param name="str">The string to normalize.</param>
        /// <returns></returns>
        private static string NormalizeIdentifier(string str)
        {
            return str.ToLower().Replace(" ", "");
        }

        /// <summary>
        /// Returns a collection of collections of products with the same international article number (EAN).
        /// </summary>
        /// <param name="products">The starting one-dimensional product collection.</param>
        /// <returns></returns>
        private static IEnumerable<IEnumerable<Product>> SplitProductsByEan(IEnumerable<Product> products)
        {
            var enumerated = products.ToArray();

            var uniqueEanCollection = enumerated.Select(p => p.Ean).Distinct()
                .Select(NormalizeIdentifier);

            return uniqueEanCollection.Select(ean => enumerated.Where(p => NormalizeIdentifier(p.Ean) == ean))
                .ToList();
        }

        public IEnumerable<Brand> ApplyBrandAggregationStrategy(IEnumerable<Brand> brands)
        {
            return brands.DistinctBy(b => NormalizeIdentifier(b.Name));
        }

        public IEnumerable<Category> ApplyCategoryAggregationStrategy(IEnumerable<Category> categories)
        {
            return categories.DistinctBy(c => NormalizeIdentifier(c.Name));
        }

        public IEnumerable<Product> ApplyProductAggregationStrategy(IEnumerable<Product> products)
        {
            // Gest best product prices by EAN.
            var splitProducts = SplitProductsByEan(products);
            var bestPriceProducts = splitProducts
                .Select(group => group.MinBy(p => p.Prices.MinBy(price => price.Quantity).Amount)).ToArray();

            // Get only the distinct categories and brands we need.
            var categories = bestPriceProducts.SelectMany(p => p.Categories)
                .DistinctBy(c => NormalizeIdentifier(c.Name)).ToArray();
            var brands = bestPriceProducts.SelectMany(p => p.Brands)
                .DistinctBy(b => NormalizeIdentifier(b.Name)).ToArray();

            // De-duplicate brands in objects.
            foreach (var product in bestPriceProducts)
            {
                product.Categories = categories
                    .Where(c => product.Categories.Any(pc => NormalizeIdentifier(pc.Name) == NormalizeIdentifier(c.Name)))
                    .ToList();

                product.Brands = brands
                    .Where(b => product.Brands.Any(pb => NormalizeIdentifier(pb.Name) == NormalizeIdentifier(b.Name)))
                    .ToList();
            }

            return bestPriceProducts;
        }
    }
}