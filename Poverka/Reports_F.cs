using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poverka
{
    public partial class Reports_F : Form
    {
        public Reports_F()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports",
                                                                               "ВЗЛЕТ 420Л",
                                                                               "protocol_vnesh.rtf");

            richTextBox1.LoadFile(filePath1);
        }

        private void Reports_F_Load(object sender, EventArgs e)
        {
            var filePath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports",
                                                                               "ВЗЛЕТ 420Л",
                                                                               "protocol_vnesh.rtf");

            richTextBox1.LoadFile(filePath1);
        }
    }
}
