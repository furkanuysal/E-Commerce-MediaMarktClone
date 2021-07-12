using MediaMarkt.Services;
using MediaMarkt.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaMarkt.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        public Command PlaceOrdersCommand { get; set; }

        public PaymentViewModel()
        {
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersAsync());
        }

        private async Task PlaceOrdersAsync()
        {
            var id = await new OrderService().PlaceOrderAsync() as string;
            RemoveItemsFromCart();
           await Shell.Current.Navigation.PushAsync(new OrdersView(id));
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
        }
    }
}
