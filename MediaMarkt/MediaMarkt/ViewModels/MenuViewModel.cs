using MediaMarkt.Models;
using MediaMarkt.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MediaMarkt.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            menus = GetMenus();
        }


        ObservableCollection<MenuModels> menus;

        public ObservableCollection<MenuModels> Menus
        {
            get { return menus; }
            set
            {
                menus = value; OnPropertyChanged();
            }
        }

        private MenuModels selectedMenu;

        public MenuModels SelectedMenu
        {
            get { return selectedMenu; }
            set { selectedMenu = value; OnPropertyChanged(); }
        }

        public ICommand SelectionCommand => new Command(DisplayMenuItemAsync);
        private async void DisplayMenuItemAsync()
        {
            switch (selectedMenu.ID)
            {
                case 1:
                    LoginViewModel login = new LoginViewModel();
                    _ = login.MyAccountNavigatorAsync();
                    break;
                case 3:
                    Routing.RegisterRoute(nameof(OrdersHistory), typeof(OrdersHistory));
                    await Shell.Current.GoToAsync(nameof(OrdersHistory));
                    break;
            }
        }

        private ObservableCollection<MenuModels> GetMenus()
        {
            return new ObservableCollection<MenuModels>
            {
                new MenuModels{ID=1, Name="Hesabım", Image="accountIcon.png", TargetType = typeof(MyAccountMenu)},
                new MenuModels{ID=2,Name="Sipariş Takibi", Image="deliverIcon.png"},
                new MenuModels{ID=3,Name="Siparişlerim", Image="cartIcon.png"},
                new MenuModels{ID=4,Name="Favorilerim", Image="favlistIcon.png"},
                new MenuModels{ID=5,Name="Karşılaştırma Listesi", Image="comparingIcon.png"},
                new MenuModels{ID=6,Name="Mesajlar", Image="letterboxIcon.png"},
                new MenuModels{ID=7,Name="MediaMarkt CLUB", Image="mediamarktclubIcon.png"}
            };
        }
    }
}
