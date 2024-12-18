﻿using System;

namespace myMarkletplace.Data_Models
{
    public class DMProducts
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int product_price { get; set; }
        public int product_stock { get; set; }
        public string product_description { get; set; }
        public byte[] product_image { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
