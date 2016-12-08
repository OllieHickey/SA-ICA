using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.Integrations.Aggregator
{
    /// <summary>
    /// Represents an error that occurred while querying a supplier.
    /// </summary>
    public class SupplierError : ISupplierError
    {
        public Exception Exception { get; private set; }

        public SupplierCode SupplierCode { get; private set; }

        public string AdditionalInformation { get; private set; }

        /// <summary>
        /// Initializes a new instance of an error that occured while querying a supplier.
        /// </summary>
        /// <param name="exception">The underlying exception that was raised.</param>
        /// <param name="supplierCode">The supplier code for the integration that threw the error.</param>
        /// <param name="additionalInformation">Gets any additional information about the error.</param>
        public SupplierError(Exception exception, SupplierCode supplierCode, string additionalInformation = null)
        {
            Exception = exception;
            SupplierCode = supplierCode;
            AdditionalInformation = additionalInformation;
        }
    }
}
