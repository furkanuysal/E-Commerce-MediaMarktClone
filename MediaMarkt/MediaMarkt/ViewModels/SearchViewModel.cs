using MediaMarkt.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaMarkt.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private string _SearchText;
        public string SearchText
        {
            set
            {
                _SearchText = value;
                OnPropertyChanged();
            }
            get
            {
                return _SearchText;
            }
        }

        public Command SearchViewCommand { get; set; }

        public SearchViewModel()
        {
            SearchViewCommand = new Command(async () => await SearchViewAsync());
        }

        private async Task SearchViewAsync()
        {
            await Shell.Current.Navigation.PushAsync(new SearchResults(SearchText));
        }

    }
}
