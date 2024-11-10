using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myMarkletplace.Data_Models;

namespace myMarkletplace.Data_Accesses
{
    public class DAUsers
    {
        private readonly string connstring = "Data Source = LAPTOP-14TD8G87\\SQLEXPRESS; Initial Catalog  = myMarketplace; Integrated Security = true";

        public void CreateUser(DMUsers user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connstring))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("InsertUser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Add parameters for the stored procedure
                        cmd.Parameters.AddWithValue("@user_name", user.user_name);
                        cmd.Parameters.AddWithValue("@user_phone", user.user_phone);
                        cmd.Parameters.AddWithValue("@user_email", user.user_email);
                        cmd.Parameters.AddWithValue("@user_password", user.user_password);

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
