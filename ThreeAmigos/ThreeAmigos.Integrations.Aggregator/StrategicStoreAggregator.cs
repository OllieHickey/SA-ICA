using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Integrations.Aggregator
{
    /// <summary>
    /// An implementation of a store aggregator that applies a strategy to aggregate store data.
    /// </summary>
    public class StrategicStoreAggregator : StoreAggregator
    {
        /// <summary>
        /// Gets the aggregation strategy use on data passed back from this aggregator.
        /// </summary>
        public IStoreAggregationStrategy Strategy { get; private set; }

        public override IEnumerable<Brand> GetAllBrands()
        {
            return Strategy.ApplyBrandAggregationStrategy(base.GetAllBrands());
        }

        public override IEnumerable<Category> GetAllCategories()
        {
            return Strategy.ApplyCategoryAggregationStrategy(base.GetAllCategories());
        }

        public override IEnumerable<Product> GetAllProducts()
        {
            return Strategy.ApplyProductAggregationStrategy(base.GetAllProducts());
        }

        /// <summary>
        /// Initializes a new instance of a store aggregator that applies a strategy to aggregate store data.
        /// </summary>
        /// <param name="strategy">The aggregation strategy use on data passed back from this aggregator.</param>
        /// <param name="stores">The store adapters to aggregate together.</param>
        public StrategicStoreAggregator(IStoreAggregationStrategy strategy, params IStoreAdapter[] stores)
            : base(stores)
        {
            Strategy = strategy;
        }
    }
}
