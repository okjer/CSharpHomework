using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form5 : Form
    {
        private string id;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(string i)
        {
            InitializeComponent();
            id = i;
            bindingSource3.DataSource = null;
            bindingSource3.DataSource = Form1.os.GetOrderById(id).orderDetailList;
        }
    }
}
