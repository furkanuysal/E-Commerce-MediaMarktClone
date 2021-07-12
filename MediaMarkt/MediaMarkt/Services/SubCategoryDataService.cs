using Firebase.Database;
using MediaMarkt.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMarkt.Services
{
   public class SubCategoryDataService
    {
        FirebaseClient client;
        public SubCategoryDataService()
        {
            client = new FirebaseClient("https://mediamarktnew-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<SubCategory>> GetSubCategoriesAsync()
        {
            var categories = (await client.Child("SubCategories")
                 .OnceAsync<SubCategory>())
                 .Select(f => new SubCategory
                 {
                     CategoryID = f.Object.CategoryID,
                     Name = f.Object.Name,
                     SubCategoryID = f.Object.SubCategoryID
                 }).ToList();
            return categories;
        }

        public async Task<ObservableCollection<SubCategory>> GetSubsByCategoryAsync(int categoryID)
        {
            var subsByCategory = new ObservableCollection<SubCategory>();
            var items = (await GetSubCategoriesAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                subsByCategory.Add(item);
            }
            return subsByCategory;
        }
    }
}
