﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFCRUDoperation_Client.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}