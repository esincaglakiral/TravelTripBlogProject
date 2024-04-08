using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class Yorumlar
    {
        [Key]
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }
        public int Blogid { get; set; }
        public virtual Blog Blog { get; set; } // Blog tablosundan Blog isimli bir değer oluşturduk ve böyle property olarak dahil etmiş olduk.

        // bir yorum bir blog için geçerli olabilir, ama bir blogda birden fazla farklı yorum  olabilir, burdaki ilişki türü budur. 
    }
}