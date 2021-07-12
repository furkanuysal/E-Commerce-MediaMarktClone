
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaMarkt.Models
{
    public class ProductItem
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryID { get; set; }
    }
}
