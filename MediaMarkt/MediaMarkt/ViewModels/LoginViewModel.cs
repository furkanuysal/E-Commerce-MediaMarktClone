using MediaMarkt.Services;
using MediaMarkt.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MediaMarkt.ViewModels
{
    public class LoginViewModel : BaseViewModel
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

        private string password;
        public string Password
        {
            set { this.password = value; OnPropertyChanged(); }
            get { return this.password; }
        }

        private bool isBusy;
        public bool IsBusy
        {
            set { this.isBusy = value; OnPropertyChanged(); }
            get { return this.isBusy; }
        }

        private bool result;
        public bool Result
        {
            set { this.result = value; OnPropertyChanged(); }
            get { return this.result; }
        }

        public static string logined="notLogined";
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {

            if (IsBusy)
                return;
            try 
            {   IsBusy = true; 
                var userService = new UserService();
                Result = await userService.RegisterUser(Name, Surname, PhoneNumber, Username, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Başarılı", "Kayıt Olundu", "Tamam");
                else
                    await Application.Current.MainPage.DisplayAlert("Hata", "Kullanıcı zaten mevcut.", "Tamam");
            }
            catch(Exception ex)
            { await Application.Current.MainPage.DisplayAlert("Hata", ex.Message, "Tamam");}
            finally { IsBusy = false; }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try 
            { IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    Application.Current.MainPage = new AppShell();
                    logined = "logined";
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Hata", "Kullanıcı adı veya şifre hatalı!", "Tamam");
                    logined = "notLogined";
                }
            }
            catch (Exception ex)
            { await Application.Current.MainPage.DisplayAlert("Hata", ex.Message, "Tamam"); }
            finally { IsBusy = false; }
        }

        public async Task MyAccountNavigatorAsync()
        {
            if (logined=="logined")
            {
                Routing.RegisterRoute(nameof(Account), typeof(Account));
                await Shell.Current.GoToAsync(nameof(Account));

            }
            else if (logined=="notLogined")
            {
                Routing.RegisterRoute(nameof(MyAccountMenu), typeof(MyAccountMenu));
                await Shell.Current.GoToAsync(nameof(MyAccountMenu));
            }
        }

    }
}
