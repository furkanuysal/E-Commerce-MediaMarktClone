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
    public partial class MyAccountMenu : ContentPage
    {
        public MyAccountMenu()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}