using System;
using myMarkletplace.Data_Accesses;
using myMarkletplace.Data_Models;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace myMarkletplace.Business_Logic
{
    public class BLProducts
    {
        private readonly DAProducts _daProducts;

        public BLProducts()
        {
            _daProducts = new DAProducts();
        }

        public List<DMProducts> GetAllProducts()
        {
            return _daProducts.GetProducts();
        }

        public DMProducts GetProductById(int productId)
        {
            if (productId <= 0)
                throw new ArgumentException("Product ID must be greater than zero.");

            return _daProducts.GetProducts(productId);
        }

        public void CreateProduct(string name, string price, string stock, string description, Image image)
        {
            // Validasi input
            ValidateProductInput(name, price, stock, description, image);

            var product = new DMProducts
            {
                product_name = name,
                product_price = int.Parse(price),
                product_stock = int.Parse(stock),
                product_description = description,
                product_image = ConvertImageToByteArray(image)
            };

            _daProducts.CreateProduct(product);
        }

        public void UpdateProduct(int productId, string name, string price, string stock, string description, Image image)
        {
            // Validasi input
            if (productId <= 0)
                throw new ArgumentException("Product ID must be greater than zero.");

            ValidateProductInput(name, price, stock, description, image);

            var product = new DMProducts
            {
                product_id = productId,
                product_name = name,
                product_price = int.Parse(price),
                product_stock = int.Parse(stock),
                product_description = description,
                product_image = ConvertImageToByteArray(image)
            };

            _daProducts.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            if (productId <= 0)
                throw new ArgumentException("Product ID must be greater than zero.");

            _daProducts.DeleteProduct(productId);
        }

        private void ValidateProductInput(string name, string price, string stock, string description, Image image)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.");

            if (string.IsNullOrWhiteSpace(price) || !int.TryParse(price, out int priceValue) || priceValue <= 0)
                throw new ArgumentException("Valid product price is required.");

            if (string.IsNullOrWhiteSpace(stock) || !int.TryParse(stock, out int stockValue) || stockValue < 0)
                throw new ArgumentException("Valid product stock is required.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Product description is required.");

            if (image == null)
                throw new ArgumentException("Product image is required.");
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return stream.ToArray();
            }
        }

        public string FormatUtcTimestamp(DateTime utcTimestamp)
        {
            return utcTimestamp.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }

        public string ConvertUtcToLocal(DateTime utcTimestamp)
        {
            return utcTimestamp.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        public decimal GetTotalInventoryValue()
        {
            return _daProducts.GetTotalInventoryValue();
        }
    }
}