using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba5
{
    public partial class Form2 : Form
    {
        Form1 _form1 { set; get; }
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form1.CheckNull(this);
            Close();
        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
