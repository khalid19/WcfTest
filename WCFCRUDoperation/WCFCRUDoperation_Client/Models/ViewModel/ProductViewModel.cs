using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFCRUDoperation_Client.Models.ViewModel
{
    public class ProductViewModel:Product
    {
        public ProductViewModel()
        {
            Products=new List<Product>();
        }

        public List<Product> Products { get; set; }



        public Product Product { get; set; }



    }
}