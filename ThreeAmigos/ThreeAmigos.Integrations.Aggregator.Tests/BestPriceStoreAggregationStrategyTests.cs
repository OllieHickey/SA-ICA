using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ThreeAmigos.Integrations.Aggregator.Tests
{
    [TestClass]
    public class BestPriceStoreAggregationStrategyTests
    {
        [TestMethod]
        public void ApplyProductAggregationStrategyShouldCombineBrands()
        {
            var fixture = new Fixture();

            // Every brand created will have the same name.
            var brandName = fixture.Create<string>();
            fixture.Customize<Brand>(o => o.With(b => b.Name, brandName));

            // Produce aggregated products.
            var aggregator = new BestPriceStoreAggregationStrategy();
            var rawProducts = fixture.CreateMany<Product>();
            var products = aggregator.ApplyProductAggregationStrategy(rawProducts).ToArray();

            // There should only be one instance of brand across every product.
            var brand = products.First().Brands.First();
            Assert.IsTrue(products.All(p => p.Brands.All(b => b == brand)),
                "More than one brand was returned across aggregated products.");
        }

        [TestMethod]
        public void ApplyProductAggregationStrategyShouldCombineCategories()
        {
            var fixture = new Fixture();

            // Every category created will have the same name.
            var categoryName = fixture.Create<string>();
            fixture.Customize<Category>(o => o.With(c => c.Name, categoryName));

            // Produce aggregated products.
            var aggregator = new BestPriceStoreAggregationStrategy();
            var rawProducts = fixture.CreateMany<Product>();
            var products = aggregator.ApplyProductAggregationStrategy(rawProducts).ToArray();

            // There should only be one instance of category/brand across every product.
            var category = products.First().Categories.First();
            Assert.IsTrue(products.All(p => p.Categories.All(c => c == category)),
                "More than one category was returned across aggregated products.");
        }

        [TestMethod]
        public void ApplyProductAggregationStrategyShouldRemoveProductDuplicates()
        {
            var fixture = new Fixture();

            // Create every product with the same EAN.
            var ean = fixture.Create<string>();
            fixture.Customize<Product>(o => o.With(p => p.Ean, ean));

            // Produce aggregated products.
            var aggregator = new BestPriceStoreAggregationStrategy();
            var rawProducts = fixture.CreateMany<Product>();
            var products = aggregator.ApplyProductAggregationStrategy(rawProducts).ToArray();

            // There should only be one product returned form the aggregator.
            Assert.AreEqual(1, products.Length, "More than one product was returned with the same EAN.");
        }

        [TestMethod]
        public void ApplyBrandAggregationStrategyShouldRemoveBrandDuplicates()
        {
            var fixture = new Fixture();

            // Every brand created will have the same name.
            var brandName = fixture.Create<string>();
            fixture.Customize<Brand>(o => o.With(b => b.Name, brandName));

            // Produce aggregated brands.
            var aggregator = new BestPriceStoreAggregationStrategy();
            var rawBrands = fixture.CreateMany<Brand>();
            var brands = aggregator.ApplyBrandAggregationStrategy(rawBrands).ToArray();

            // There should only be one brand returned form the aggregator.
            Assert.AreEqual(1, brands.Length, "More than one brand was returned from the aggregator.");
        }

        [TestMethod]
        public void ApplyCategoryAggregationStrategyShouldRemoveCategoryDuplicates()
        {
            var fixture = new Fixture();

            // Every category created will have the same name.
            var categoryName = fixture.Create<string>();
            fixture.Customize<Category>(o => o.With(c => c.Name, categoryName));

            // Produce aggregated categories.
            var aggregator = new BestPriceStoreAggregationStrategy();
            var rawCategories = fixture.CreateMany<Category>();
            var categories = aggregator.ApplyCategoryAggregationStrategy(rawCategories).ToArray();

            // There should only be one category returned form the aggregator.
            Assert.AreEqual(1, categories.Length, "More than one category was returned from the aggregator.");
        }
    }
}
