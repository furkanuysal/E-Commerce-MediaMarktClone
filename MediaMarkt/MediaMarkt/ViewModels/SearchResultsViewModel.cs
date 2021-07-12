using MediaMarkt.Models;
using MediaMarkt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MediaMarkt.ViewModels
{
    public class SearchResultsViewModel : BaseViewModel
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

        public ObservableCollection<ProductItem> ProductItemsByQuery { get; set; }

        private int _TotalProductItems;
        public int TotalProductItems
        {
            set
            {
                _TotalProductItems = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalProductItems;
            }
        }

        public SearchResultsViewModel(string searchText)
        {
            ProductItemsByQuery = new ObservableCollection<ProductItem>();
            GetProductItemsByQuery(searchText);
            GetProductItemsByGenreQuery(searchText);
        }

        private async void GetProductItemsByQuery(string searchText)
        {
            var data = await new ProductItemService().GetProductsByQueryAsync(searchText);
            ProductItemsByQuery.Clear();
            foreach (var item in data)
            {
                ProductItemsByQuery.Add(item);
            }
            TotalProductItems = ProductItemsByQuery.Count;
        }

        private async void GetProductItemsByGenreQuery(string searchText)
        {
            var data = await new ProductItemService().GetProductsByGenreQueryAsync(searchText);
            ProductItemsByQuery.Clear();
            foreach (var item in data)
            {
                ProductItemsByQuery.Add(item);
            }
            TotalProductItems = ProductItemsByQuery.Count;
        }
    }
}
