using System;
using Xamarin.Forms;
using MediaMarkt.Helpers;

namespace MediaMarkt.Views
{
    public partial class AddSettingsPage : ContentPage
    {
        public AddSettingsPage()
        {
            InitializeComponent();
        }

        private async void CategoriesButton_Clicked(object sender, EventArgs e)
        {
            var acd = new AddCategoryData();
            await acd.AddCategoriesAsync();
        }

        private async void SubCategoriesButton_Clicked(object sender, EventArgs e)
        {
            var ascd = new AddSubCategoryData();
            await ascd.AddSubCategoriesAsync();
        }

        private async void ProductsButton_Clicked(object sender, EventArgs e)
        {
            var apd = new AddProductItemData();
            await apd.AddProductItemsAsync();
        }

        private void CartButton_Clicked(object sender, EventArgs e)
        {
            var cct = new CreateCartTable();
            if (cct.CreateTable())
                DisplayAlert("Başarılı", "Sepet tablosu yaratıldı.", "Tamam");
            else
                DisplayAlert("Hata", "Tabloyu yaratırken hata oluştu.", "Tamam");
        }
    }
}