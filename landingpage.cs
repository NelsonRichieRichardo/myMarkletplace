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
    public partial class landingpage : Form
    {
        public landingpage()
        {
            InitializeComponent();

            SetPlaceholder();
        }
        private void SetPlaceholder()
        {
           
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            
        }

        private void SetPlaceholderIfEmpty(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void landingpage_Load(object sender, EventArgs e)
        {
            home1.Show();
            contact1.Hide();
            about1.Hide();
            sign_up1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                panel1.VerticalScroll.Value = e.NewValue;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void home1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            sign_up1.Hide();
            contact1.Hide();
            about1.Hide();
            home1.Show();   
            home1.BringToFront();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            sign_up1.Hide();
            about1.Hide();
            home1.Hide();
            contact1.Show();
            contact1.BringToFront();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            sign_up1.Hide();
            home1.Hide();
            contact1.Hide();
            about1.Show();
            about1.BringToFront();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            home1.Hide();
            contact1.Hide();
            about1.Hide();
            sign_up1.Show();
            sign_up1.BringToFront();
        }

        private void contact1_Load(object sender, EventArgs e)
        {

        }
    }
}
