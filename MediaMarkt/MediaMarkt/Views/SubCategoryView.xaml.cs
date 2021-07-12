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
    public partial class SubCategoryView : ContentPage
    {
        CategoryViewModel cvm;
        public SubCategoryView(Category category)
        {
            InitializeComponent();
            cvm = new CategoryViewModel(category);
            this.BindingContext = cvm;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var subcategory = e.CurrentSelection.FirstOrDefault() as SubCategory;
            if (subcategory == null)
                return;

            await Shell.Current.Navigation.PushAsync(new ProductListView(subcategory));


            ((CollectionView)sender).SelectedItem = null;
        }
    }
}