using MediaMarkt.Models;
using MediaMarkt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MediaMarkt.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedCategory;
            }
        }

        public ObservableCollection<SubCategory> SubsByCategory { get; set; }

        private int _TotalSubs;
        public int TotalSubs
        {
            set
            {
                _TotalSubs = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalSubs;
            }
        }

        public CategoryViewModel(Category category)
        {
            SelectedCategory = category;
            SubsByCategory = new ObservableCollection<SubCategory>();
            GetSubCategories(category.CategoryID);
        }

        private async void GetSubCategories(int categoryID)
        {
            var data = await new SubCategoryDataService().GetSubsByCategoryAsync(categoryID);
            SubsByCategory.Clear();
            foreach (var item in data)
            {
                SubsByCategory.Add(item);
            }
            TotalSubs = SubsByCategory.Count;
        }
    }
}
