using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myMarkletplace.Data_Models;

namespace myMarkletplace.Data_Accesses
{
    public class DAProducts
    {
        private readonly string connstring = "Data Source = DESKTOP-OC4QH26\\SQLEXPRESS; Initial Catalog  = myMarketplace; Integrated Security = true";

        public DMProducts DMProducts { get; private set; }

        public List<DMProducts> GetProducts()
        {
            var products = new List<DMProducts>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("GetAllProduct", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DMProducts = new DMProducts
                                {
                                    product_id = reader.GetInt32(0),
                                    product_name = reader.GetString(1),
                                    product_price = reader.GetInt32(2),
                                    product_stock = reader.GetInt32(3),
                                    product_description = reader.GetString(4),
                                    product_image = reader["product_image"] as byte[]
                                };

                                products.Add(DMProducts);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }


            return products;
        }

        public DMProducts GetProducts(int product_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("GetProduct", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@product_id", product_id);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                DMProducts = new DMProducts
                                {
                                    product_id = reader.GetInt32(0),
                                    product_name = reader.GetString(1),
                                    product_price = reader.GetInt32(2),
                                    product_stock = reader.GetInt32(3),
                                    product_description = reader.GetString(4),
                                    product_image = reader["product_image"] as byte[]
                                };

                                return DMProducts;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return null;
        }

        //Create Products
        public void CreateProduct(DMProducts product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("InsertProduct", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@product_name", product.product_name);
                        cmd.Parameters.AddWithValue("@product_price", product.product_price);
                        cmd.Parameters.AddWithValue("@product_stock", product.product_stock);
                        cmd.Parameters.AddWithValue("@product_description", product.product_description);
                        cmd.Parameters.AddWithValue("@product_image", product.product_image);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        //Update Products
        public void UpdateProduct(DMProducts product)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("UpdateProduct", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@product_id", product.product_id);
                        cmd.Parameters.AddWithValue("@product_name", product.product_name);
                        cmd.Parameters.AddWithValue("@product_price", product.product_price);
                        cmd.Parameters.AddWithValue("@product_stock", product.product_stock);
                        cmd.Parameters.AddWithValue("@product_description", product.product_description);
                        cmd.Parameters.AddWithValue("@product_image", product.product_image);

                        // Execute the stored procedure
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) updated.");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }

        //Delete Products
        public void DeleteProduct(int product_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("DeleteProduct", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@product_id", product_id);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}
