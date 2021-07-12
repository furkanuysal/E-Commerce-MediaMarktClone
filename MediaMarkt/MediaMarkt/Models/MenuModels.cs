using System;
using System.Collections.Generic;
using System.Text;

namespace MediaMarkt.Models
{
   public class MenuModels
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Type TargetType { get; set; }
    }
}
