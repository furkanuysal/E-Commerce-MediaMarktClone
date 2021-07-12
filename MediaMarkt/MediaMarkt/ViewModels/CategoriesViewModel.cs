using MediaMarkt.Models;
using MediaMarkt.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MediaMarkt.ViewModels
{
   public class CategoriesViewModel : BaseViewModel
    {
        public CategoriesViewModel()
        {
            Categories = new ObservableCollection<Category>();
            GetCategories();
        }

        public ObservableCollection<Category> Categories { get; set; }

        private async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }

    }
}
