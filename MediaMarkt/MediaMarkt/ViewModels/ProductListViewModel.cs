using MediaMarkt.Models;
using MediaMarkt.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MediaMarkt.ViewModels
{
    public class ProductListViewModel : BaseViewModel
    {
        private SubCategory _SelectedCategory;
        public SubCategory SelectedCategory
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

        public ObservableCollection<ProductItem> ProductsBySubCategory { get; set; }

        private int _TotalProducts;
        public int TotalProducts
        {
            set
            {
                _TotalProducts = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalProducts;
            }
        }

        public ProductListViewModel(SubCategory subcategory)
        {
            SelectedCategory = subcategory;
            ProductsBySubCategory = new ObservableCollection<ProductItem>();
            GetProducts(subcategory.SubCategoryID);
        }

        private async void GetProducts(int subcategoryID)
        {
            var data = await new ProductItemService().GetProductsBySubCategoryAsync(subcategoryID);
            ProductsBySubCategory.Clear();
            foreach (var item in data)
            {
                ProductsBySubCategory.Add(item);
            }
            TotalProducts = ProductsBySubCategory.Count;
        }
    }
}
