using Firebase.Database;
using MediaMarkt.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MediaMarkt.Services
{
    public class ProductItemService
    {
        FirebaseClient client;
        public ProductItemService()
        {
            client = new FirebaseClient("https://mediamarktnew-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<ProductItem>> GetProductItemsAsync()
        {
            var products = (await client.Child("ProductItems")
                 .OnceAsync<ProductItem>())
                 .Select(f => new ProductItem
                 {
                     SubCategoryID = f.Object.SubCategoryID,
                     Description = f.Object.Description,
                     ImageUrl = f.Object.ImageUrl,
                     Name = f.Object.Name,
                     Price = f.Object.Price,
                     ProductID = f.Object.ProductID,
                     Genre = f.Object.Genre
                 }).ToList();
            return products;
        }

        public async Task<ObservableCollection<ProductItem>> GetProductsBySubCategoryAsync(int subcategoryID)
        {
            var productsByCategory = new ObservableCollection<ProductItem>();
            var items = (await GetProductItemsAsync()).Where(p => p.SubCategoryID == subcategoryID).ToList();
            foreach (var item in items)
            {
                productsByCategory.Add(item);
            }
            return productsByCategory;
        }

        public async Task<ObservableCollection<ProductItem>> GetLatestProductsAsync()
        {
            var latestProducts = new ObservableCollection<ProductItem>();
            var items = (await GetProductItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);
            foreach (var item in items)
            {
                latestProducts.Add(item);
            }
            return latestProducts;
        }

        public async Task<ObservableCollection<ProductItem>> GetProductsByQueryAsync(string searchText)
        {
            var productsByQuery = new ObservableCollection<ProductItem>();
            var items = (await GetProductItemsAsync()).Where(p => p.Name.Contains(searchText)).ToList();
            foreach (var item in items)
            {
                productsByQuery.Add(item);
            }
            return productsByQuery;
        }

        public async Task<ObservableCollection<ProductItem>> GetProductsByGenreQueryAsync(string searchText)
        {
            var productsByQuery = new ObservableCollection<ProductItem>();
            var items = (await GetProductItemsAsync()).Where(p => p.Genre.Contains(searchText)).ToList();
            foreach (var item in items)
            {
                productsByQuery.Add(item);
            }
            return productsByQuery;
        }
    }
}
