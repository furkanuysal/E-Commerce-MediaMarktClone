using Firebase.Database;
using Firebase.Database.Query;
using MediaMarkt.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaMarkt.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;

        public AddCategoryData()
        {
            client = new FirebaseClient("https://mediamarktnew-default-rtdb.europe-west1.firebasedatabase.app/");
            Categories = new List<Category>{
                new Category { CategoryID = 1, Name = "Telefon", Image = "phoneCategory.png" },
                new Category { CategoryID = 2, Name = "Bilgisayar", Image = "computerCategory.png" },
                new Category { CategoryID = 3, Name = "Bilgisayar Bileşenleri", Image = "computerPartsCategory.png" },
                new Category { CategoryID = 4, Name = "Tv ve Görüntü", Image = "tvCategory.png" },
                new Category { CategoryID = 5, Name = "Ses ve Müzik", Image = "musicCategory.png" },
                new Category { CategoryID = 6, Name = "Foto & Kamera", Image = "cameraCategory.png" },
                new Category { CategoryID = 7, Name = "Beyaz Eşya", Image = "applianceCategory.png" },
                new Category { CategoryID = 8, Name = "Ev Aletleri & Yaşam", Image = "homeLifeCategory.png" }
                };
        }

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category() { CategoryID = category.CategoryID, Name = category.Name, Image = category.Image });
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Tamam");
            }
        }
    }
}
