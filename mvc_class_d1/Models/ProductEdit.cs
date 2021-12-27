using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace mvc_class_d1.Models
{
    public class ProductEdit
    {
        [DisplayName("商品編號")]
        public string product_id { get; set; }
        [DisplayName("商品名稱")]
        public string name { get; set; }
        [DisplayName("商品單位")]
        public string unit { get; set; }
        [DisplayName("商品規格")]
        public string spec { get; set; }
        [DisplayName("商品描述")]
        public string description { get; set; }
        [DisplayName("商品價格")]
        public int price { get; set; }
    }
}