using System;

namespace ThreeAmigos.Interfaces
{
    /// <summary>
    /// Implemented by classes representing an error that occurred while querying a supplier.
    /// </summary>
    public interface ISupplierError
    {
        /// <summary>
        /// Gets the underlying exception that was raised.
        /// </summary>
        Exception Exception { get; }

        /// <summary>
        /// Gets the supplier code for the integration that threw the error.
        /// </summary>
        Domain.Store.SupplierCode SupplierCode { get; }

        /// <summary>
        /// Gets any additional information about the error.
        /// </summary>
        string AdditionalInformation { get; }
    }
}
