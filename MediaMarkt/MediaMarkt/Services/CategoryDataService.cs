using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using MediaMarkt.Models;
using System.Linq;

namespace MediaMarkt.Services
{
    public class CategoryDataService
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient("https://mediamarktnew-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryID = c.Object.CategoryID,
                    Image = c.Object.Image,
                    Name = c.Object.Name
                }).ToList();
            return categories;
        }
    }
}
