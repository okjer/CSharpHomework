using homework5;
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
        private uint id;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(uint i)
        {
            InitializeComponent();
            id = i;
            bindingSource3.DataSource = null;
            bindingSource3.DataSource = Form1.os.orderDict[i].orderDetailsDict.Values.ToList();
        }
    }
}
