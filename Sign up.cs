using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myMarkletplace.Data_Accesses;
using myMarkletplace.Data_Models;

namespace myMarkletplace
{
    public partial class SignUp : UserControl
    {

        private readonly DAUsers _DAUsers;

        public SignUp()
        {
            _DAUsers = new DAUsers();

            InitializeComponent();
            SetPlaceholder();
            SetPlaceholder2();
            SetPlaceholder3();
            SetPlaceholder4();
            login1.Hide();
        }
        private void SetPlaceholder()
        {
            textBox1.Text = "Name";
            textBox1.ForeColor = Color.Gray;

            // Event handler untuk Enter dan Leave
            textBox1.Enter += RemovePlaceholder;
            textBox1.Leave += SetPlaceholderIfEmpty;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (textBox1.ForeColor == Color.Gray)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderIfEmpty(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void SetPlaceholder2()
        {
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;

            // Event handler untuk Enter dan Leave
            txtPassword.Enter += RemovePlaceholder2;
            txtPassword.Leave += SetPlaceholderIfEmpty2;
        }

        private void RemovePlaceholder2(object sender, EventArgs e)
        {
            if (txtPassword.ForeColor == Color.Gray)
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderIfEmpty2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void SetPlaceholder3()
        {
            txtEmail.Text = "Email";
            txtEmail.ForeColor = Color.Gray;

            // Event handler untuk Enter dan Leave
            txtEmail.Enter += RemovePlaceholder3;
            txtEmail.Leave += SetPlaceholderIfEmpty3;
        }

        private void RemovePlaceholder3(object sender, EventArgs e)
        {
            if (txtEmail.ForeColor == Color.Gray)
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderIfEmpty3(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void SetPlaceholder4()
        {
            txtPhoneNumber.Text = "Phone Number";
            txtPhoneNumber.ForeColor = Color.Gray;

            // Event handler untuk Enter dan Leave
            txtPhoneNumber.Enter += RemovePlaceholder4;
            txtPhoneNumber.Leave += SetPlaceholderIfEmpty4;
        }

        private void RemovePlaceholder4(object sender, EventArgs e)
        {
            if (txtPhoneNumber.ForeColor == Color.Gray)
            {
                txtPhoneNumber.Text = "";
                txtPhoneNumber.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderIfEmpty4(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                txtPhoneNumber.Text = "Phone Number";
                txtPhoneNumber.ForeColor = Color.Gray;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearFields()
        {
            textBox1.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPhoneNumber.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DMUsers user = new DMUsers()
                {
                    user_name = textBox1.Text,
                    user_phone = txtPhoneNumber.Text,
                    user_email = txtEmail.Text,
                    user_password = txtPassword.Text
                };

                _DAUsers.CreateUser(user);
                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            login1.Show();
            login1.BringToFront();

        }
    }
}
