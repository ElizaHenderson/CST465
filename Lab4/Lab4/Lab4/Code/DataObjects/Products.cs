using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code.DataObjects
{
    public class Products
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}