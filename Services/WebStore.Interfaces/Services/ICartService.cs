using WebStore.Entities.ViewModels;

namespace WebStore.Interfaces.Services
{
    public interface ICartService
    {
        void AddToCart(int id);
        void DecrementFromCart(int id);
        void RemoveFromCart(int id);
        void RemoveAll();

        CartViewModel TransformCart();
    }
}
