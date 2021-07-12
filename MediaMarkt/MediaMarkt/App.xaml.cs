using MediaMarkt.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaMarkt
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            //MainPage = new NavigationPage(new AddSettingsPage());
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
