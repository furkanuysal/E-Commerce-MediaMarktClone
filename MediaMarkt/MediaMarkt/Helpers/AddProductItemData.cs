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
    public class AddProductItemData
    {
        public List<ProductItem> ProductItems { get; set; }

        FirebaseClient client;

        public AddProductItemData() 
        {
            client = new FirebaseClient("https://mediamarktnew-default-rtdb.europe-west1.firebasedatabase.app/");
            ProductItems = new List<ProductItem>()
            {
                new ProductItem{SubCategoryID=20, ProductID=1, Name="LG GR-C802HLCU.APZPLTK", Genre="Buzdolabı", Description="Tür: Buzdolabı\nEkran: Hayır\nÜretim Yeri: Güney Kore", Price=8199, ImageUrl="LgFridge.png"},
                new ProductItem{SubCategoryID=16, ProductID=2, Name="CANON 850D 18-135 USM", Genre="Kamera", Description="Tür: Kamera\nÇözünürlük: 24.1 MP\nÜretim Yeri: Japonya", Price=11999, ImageUrl="CanonEosCamera.png"},
                new ProductItem{SubCategoryID=9, ProductID=3, Name="ADATA 500G-C Swordfish 500GB", Genre="M.2 Nvme SSD", Description="Tür: M.2 Nvme SSD\nHafıza: 500GB\nÜretim Yeri: Çin", Price=699, ImageUrl="AdataSsd.png"},
                new ProductItem{SubCategoryID=14, ProductID=4, Name="LOGITECH Z407 80W", Genre="Bluetooth Hoparlör", Description="Tür: Bluetooth Hoparlör\nBluetooth: Evet\nÜretim Yeri: Çin", Price=1199, ImageUrl="LogitechBluetoothSpeaker.png"},
                new ProductItem{SubCategoryID=12, ProductID=5, Name="LG 50UN73006 50Inch", Genre="UHD TV", Description="Tür:UHD TV\nGörüntü Kalitesi: UHD 4K\nEkran Boyutu: 50 inç", Price=5999, ImageUrl="LgUhdTv.png"},
                new ProductItem{SubCategoryID=1, ProductID=6, Name="SAMSUNG Galaxy S20+ 128GB", Genre="Akıllı Telefon", Description="Tür: Akıllı Telefon\nİşletim Sistemi: Android 11\nİşlemci: Octa Core Exynos 990", Price=6497, ImageUrl="SamsungGalaxyS20.png"},
                new ProductItem{SubCategoryID=4, ProductID=7, Name="HP 2A9H8E", Genre="Laptop", Description="Tür: Laptop\nİşletim Sistemi: Windows 10 Home\nİşlemci: i5-10210U", Price=7399, ImageUrl="HpLaptop.png"},
                new ProductItem{SubCategoryID=22, ProductID=8, Name="DELONGHI Magnifica Esam4500", Genre="Kahve Makinesi", Description="Tür: Kahve Makinesi\nAğırlık: 10.5 kg\nÜretim Yeri: İtalya", Price=7999, ImageUrl="DelonghiCoffee.png"},
                new ProductItem{SubCategoryID=15, ProductID=9, Name="BEATS MX3X2EE.A STUDIO 3", Genre="Kulaküstü Kulaklık", Description="Tür: Kulaküstü Kulaklık\nBluetooth: Evet\nÜretim Yeri: Çin", Price=1399, ImageUrl="BeatsHeadphone.png"},
                new ProductItem{SubCategoryID=21, ProductID=10, Name="MIELE WWG 660 WCS 1400D", Genre="Çamaşır Makinesi", Description="Tür: Çamaşır Makinesi\nEkran: Evet\nÜretim Yeri: Almanya", Price=15859, ImageUrl="MieleWashMach.png"},
                new ProductItem{SubCategoryID=4, ProductID=11, Name="LENOVO 81Y600NPTX Legion 5", Genre="Gaming Laptop", Description="Tür: Gaming Laptop\nİşletim Sistemi: Windows 10 Pro\nİşlemci: i7-10750H", Price=14699, ImageUrl="LenovoLegion5.png"},
                new ProductItem{SubCategoryID=12, ProductID=12, Name="SONY 65XH8077 65Inch", Genre="LED TV", Description="Tür: LED TV\nGörüntü Kalitesi: UHD 4K\nEkran Boyutu: 65 inç", Price=11999, ImageUrl="SonyLedTv.png"},
                new ProductItem{SubCategoryID=1, ProductID=13, Name="APPLE iPhone 12 Mini 256GB", Genre="Akıllı Telefon", Description="Tür: Akıllı Telefon\nİşletim Sistemi: iOS 14\nİşlemci: A14 Bionic Çip", Price=10899, ImageUrl="iPhone12Mini.png"},
                new ProductItem{SubCategoryID=17, ProductID=14, Name="SONY HDR-CX405 Handycam", Genre="Video Kamera", Description="Tür: Video Kamera\nÇözünürlük: 2.29 MP\nÜretim Yeri: Çin", Price=2299, ImageUrl="SonyVideoCamera.png"},
                new ProductItem{SubCategoryID=23, ProductID=15, Name="DYSON V10 Absolute", Genre="Elektrikli Süpürge", Description="Tür: Elektrikli Süpürge\nAğırlık: 5980 gr\nÜretim Yeri: Malezya", Price=4799, ImageUrl="DysonV10.png"},
                new ProductItem{SubCategoryID=7, ProductID=16, Name="CORSAIR Vengeance 16GB DDR4 3000Mhz Ram", Genre="Ram Bellek", Description="Tür: Ram Bellek\nHafıza: 16GB\nÜretim Yeri: Tayvan", Price=879, ImageUrl="CorsairVengeance.png"}
            };
        }

        public async Task AddProductItemsAsync()
        {
            try
            {
                foreach (var productitems in ProductItems)
                {
                    await client.Child("ProductItems").PostAsync(new ProductItem() { Description=productitems.Description, Genre=productitems.Genre, ImageUrl=productitems.ImageUrl, Name=productitems.Name, Price=productitems.Price, ProductID=productitems.ProductID, SubCategoryID=productitems.SubCategoryID});
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Tamam");
            }
        }
    }
}
