using MediaMarkt.Models;
using MediaMarkt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaMarkt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListView : ContentPage
    {
        ProductListViewModel pvm;
        public ProductListView(SubCategory subCategory)
        {
            InitializeComponent();
            pvm = new ProductListViewModel(subCategory);
            this.BindingContext = pvm;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as ProductItem;
            if (selectedProduct == null)
                return;
            await Shell.Current.Navigation.PushAsync(new ProductDetailsPage(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}