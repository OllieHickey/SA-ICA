using ThreeAmigos.Domain.Store;

namespace ThreeAmigos.Interfaces
{
    public interface IDispatcher
    {
        DispatchResult Dispatch(
            string productEan,
            int quantity,
            string customerName,
            string customerCardNumber);
    }
}
