using MediaMarkt.Models;
using MediaMarkt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MediaMarkt.ViewModels
{
   public class HomePageViewModel : BaseViewModel
    {
        public ObservableCollection<ProductItem> LatestProducts { get; set; }
        public HomePageViewModel()
        {
            LatestProducts = new ObservableCollection<ProductItem>();
            GetLatestProducts();
        }


        private async void GetLatestProducts()
        {
            var data = await new ProductItemService().GetLatestProductsAsync();
            LatestProducts.Clear();
            foreach (var item in data)
            {
                LatestProducts.Add(item);
            }
        }

    }
}
