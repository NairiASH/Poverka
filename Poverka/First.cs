using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poverka
{
    public partial class First : Form
    {
        public First()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            Second secondForm = new Second();
            secondForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}