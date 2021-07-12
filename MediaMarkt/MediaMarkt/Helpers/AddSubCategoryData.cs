using Firebase.Database;
using Firebase.Database.Query;
using MediaMarkt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MediaMarkt.Helpers
{
    class AddSubCategoryData
    {
        public List<SubCategory> SubCategories { get; set; }

        FirebaseClient client;

        public AddSubCategoryData()
        {
            client = new FirebaseClient("https://mediamarktnew-default-rtdb.europe-west1.firebasedatabase.app/");
            SubCategories = new List<SubCategory>{
                new SubCategory { CategoryID = 1, Name = "Cep Telefonları", SubCategoryID=1},
                new SubCategory { CategoryID = 1, Name = "Masaüstü Telefon", SubCategoryID=2},
                new SubCategory { CategoryID = 1, Name = "Saatler", SubCategoryID=3},
                new SubCategory { CategoryID = 2, Name = "Taşınabilir Bilgisayarlar", SubCategoryID=4},
                new SubCategory { CategoryID = 2, Name = "Tabletler", SubCategoryID=5},
                new SubCategory { CategoryID = 2, Name = "Masaüstü Bilgisayarlar", SubCategoryID=6},
                new SubCategory { CategoryID = 3, Name = "Bellek (RAM)", SubCategoryID=7},
                new SubCategory { CategoryID = 3, Name = "İşlemci", SubCategoryID=8},
                new SubCategory { CategoryID = 3, Name = "Hard Disk", SubCategoryID=9},
                new SubCategory { CategoryID = 4, Name = "Uydu Sistemleri", SubCategoryID=10},
                new SubCategory { CategoryID = 4, Name = "Projeksiyon", SubCategoryID=11},
                new SubCategory { CategoryID = 4, Name = "Televizyon", SubCategoryID=12},
                new SubCategory { CategoryID = 5, Name = "Oto Ses ve Aksesuarları",SubCategoryID=13},
                new SubCategory { CategoryID = 5, Name = "Ses Sistemleri",SubCategoryID=14},
                new SubCategory { CategoryID = 5, Name = "Kulaklıklar",SubCategoryID=15},
                new SubCategory { CategoryID = 6, Name = "Fotoğraf Makineleri", SubCategoryID=16},
                new SubCategory { CategoryID = 6, Name = "Video Kamera", SubCategoryID=17},
                new SubCategory { CategoryID = 6, Name = "Teleskoplar", SubCategoryID=18},
                new SubCategory { CategoryID = 7, Name = "Ankastre", SubCategoryID=19},
                new SubCategory { CategoryID = 7, Name = "Buzdolabı", SubCategoryID=20},
                new SubCategory { CategoryID = 7, Name = "Çamaşır Makineleri", SubCategoryID=21},
                new SubCategory { CategoryID = 8, Name = "Mutfak Gereçleri", SubCategoryID=22},
                new SubCategory { CategoryID = 8, Name = "Süpürgeler", SubCategoryID=23},
                new SubCategory { CategoryID = 8, Name = "Ütüler", SubCategoryID=24}
                };
        }

        public async Task AddSubCategoriesAsync()
        {
            try
            {
                foreach (var subcategory in SubCategories)
                {
                    await client.Child("SubCategories").PostAsync(new SubCategory() { CategoryID = subcategory.CategoryID, Name = subcategory.Name, SubCategoryID=subcategory.SubCategoryID });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Tamam");
            }
        }
    }
}
