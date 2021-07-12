using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MediaMarkt.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        private string name;
        public string Name
        {
            set { this.name = value; OnPropertyChanged(); }
            get { return this.name; }
        }

        private string surname;
        public string Surname
        {
            set { this.surname = value; OnPropertyChanged(); }
            get { return this.surname; }
        }

        private string phonenumber;
        public string PhoneNumber
        {
            set { this.phonenumber = value; OnPropertyChanged(); }
            get { return this.phonenumber; }
        }

        private string username;
        public string Username
        {
            set { this.username = value; OnPropertyChanged(); }
            get { return this.username; }
        }

        public Command LogoutCommand { get; set; }

        public AccountViewModel()
        {
            LogoutCommand = new Command(() => LogoutCommandAsync());
            var uname = Preferences.Get("Username", String.Empty);
            Username = uname;
        }
        private void LogoutCommandAsync()
        {
            LoginViewModel.logined = "notLogined";
            Application.Current.MainPage = new AppShell();
        }
    }
}
