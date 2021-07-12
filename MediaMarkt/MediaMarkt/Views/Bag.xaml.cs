using MediaMarkt.Models;
using MediaMarkt.Services;
using MediaMarkt.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaMarkt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bag : ContentPage
    {
        public Bag()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var item = button.BindingContext as UserCartItem;
            var vm = BindingContext as CartViewModel;
            vm.RemoveItemCommand.Execute(item);
        }
    }
}