using MediaMarkt.Models;
using MediaMarkt.Services;
using MediaMarkt.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MediaMarkt.ViewModels
{
   public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<UserCartItem> CartItems { get; set; }

        private decimal _TotalCost;
        public decimal TotalCost
        {
            set
            {
                _TotalCost = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalCost;
            }
        }
        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
               
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        public Command GotoPaymentCommand { get; set; }
        public Command ContinueCommand { get; set; }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    TotalCost = 0;
                    LoadItems();
                    IsRefreshing = false;
                });
            }
        }
        public Command RemoveItemCommand
        {
            get
            { return new Command<UserCartItem>((product) => CartItems.Remove(product)); }
        }
        public CartViewModel()
        {
            CartItems = new ObservableCollection<UserCartItem>();
            LoadItems();
            GotoPaymentCommand = new Command(async () => await PaymentPageAsync());
            ContinueCommand = new Command(() => ContinueCommandAsync());
        }



        private async Task PaymentPageAsync()
        {
            await Shell.Current.Navigation.PushAsync(new PaymentPage());
        }

        private void LoadItems()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<CartItem>().ToList();
            CartItems.Clear();
            foreach (var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId = item.CartItemID,
                    ProductId = item.ProductID,
                    ProductName = item.ProductName,
                    ImageUrl = item.ProductImageUrl,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Cost = item.Price * item.Quantity
                });
                TotalCost += (item.Price * item.Quantity);
            }
        }

        private void ContinueCommandAsync()
        {
            Application.Current.MainPage = new AppShell();
        }
    }
}
