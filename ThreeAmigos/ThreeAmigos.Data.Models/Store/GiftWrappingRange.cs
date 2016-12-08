namespace ThreeAmigos.Data.Models.Store
{
    /// <summary>
    /// Represents a gift-wrapping range.
    /// </summary>
    public class GiftWrappingRange
    {
        /// <summary>
        /// Gets or sets the database ID for this gift-wrapping range.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of this gift-wrapping range as held by the provider.
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the name of this gift-wrapping range.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the text-based description of this gift-wrapping range.
        /// </summary>
        public string Description { get; set; }
    }
}
