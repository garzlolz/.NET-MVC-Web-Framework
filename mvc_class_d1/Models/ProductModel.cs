using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_class_d1.Models
{
    public class ProductModel
    {
        [DisplayName("商品編號")]
        public string product_id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public string spec { get; set; }
        public string description { get; set; }
        public int price { get; set; }

    }
}