using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myMarkletplace
{
    public partial class Sign_up : UserControl
    {
        public Sign_up()
        {
            InitializeComponent();
            SetPlaceholder();
            SetPlaceholder2();
            SetPlaceholder3();
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
            textBox2.Text = "Email or Phone Number";
            textBox2.ForeColor = Color.Gray;

            // Event handler untuk Enter dan Leave
            textBox2.Enter += RemovePlaceholder2;
            textBox2.Leave += SetPlaceholderIfEmpty2;
        }

        private void RemovePlaceholder2(object sender, EventArgs e)
        {
            if (textBox2.ForeColor == Color.Gray)
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderIfEmpty2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox2.Text = "Email or Phone Number";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void SetPlaceholder3()
        {
            textBox3.Text = "Password";
            textBox3.ForeColor = Color.Gray;

            // Event handler untuk Enter dan Leave
            textBox3.Enter += RemovePlaceholder3;
            textBox3.Leave += SetPlaceholderIfEmpty3;
        }

        private void RemovePlaceholder3(object sender, EventArgs e)
        {
            if (textBox3.ForeColor == Color.Gray)
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholderIfEmpty3(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox3.Text = "Password";
                textBox3.ForeColor = Color.Gray;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
