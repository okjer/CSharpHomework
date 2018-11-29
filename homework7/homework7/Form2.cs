using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework5;

namespace homework7
{
    public partial class Form2 : Form
    {
        private string id;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string id)
        {
            InitializeComponent();
            this.id = id;
        }
        /// <summary>
        /// 修改订单确认键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text.ToString();
            long i = long.Parse(textBox2.Text.ToString());
            Order order = Form1.os.QueryOrderById(id);
            order.Customer.CustomerId = i;
            order.Customer.CustomerName = s;
            Form1.bindingSource1.DataSource = Form1.os.OrderList;
            Close();
        }
    }
}
