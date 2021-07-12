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
    public partial class ProductDetailsPage : ContentPage
    {
        ProductDetailsViewModel pdvm;
        public ProductDetailsPage(ProductItem productItem)
        {
            InitializeComponent();
            pdvm = new ProductDetailsViewModel(productItem);
            this.BindingContext = pdvm;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}