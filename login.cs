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
    public partial class login : UserControl
    {
        public login()
        {
            InitializeComponent();
            signUp1.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            signUp1.Show();
            signUp1.BringToFront();

        }
    }
}
