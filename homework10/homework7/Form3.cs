using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace homework7
{
    public partial class Form3 : Form
    {
        private List<OrderDetail> orderDetails = new List<OrderDetail>();
        public uint id;
        struct Pair
        {
            public uint id;
            public double value;
            public Pair(uint x, double y)
            {
                id = x;
                value = y;
            }
        }
        private static Dictionary<string, Pair> goods = new Dictionary<string, Pair>()
        {
            {"java",new Pair(1,10)},
            {"c#",new Pair(2,20) },
            {"c++",new Pair(3,30)},
            {"python",new Pair(4,40) },
            {"javascript",new Pair(5,50) },
            {"html5",new Pair(5,50)}
        };
        public Form3()
        {
            InitializeComponent();
            id = 1;
            bindingSource2.DataSource = orderDetails;
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text.ToString();
            Regex regex = new Regex(@"\d{11}");
            if (!regex.IsMatch(textBox3.Text))
                throw new Exception("电话格式不正确");
            string i = textBox2.Text.ToString();
            long cusid = long.Parse(textBox3.Text.ToString());
            Customer customer = new Customer(cusid, s);
            Order order = new Order(i, customer);
            foreach (OrderDetail item in orderDetails)
            {
                using (var db = new OrderDB())
                {
                    db.OrderDetail.Add(item);
                    db.SaveChanges();
                }
            }
            Form1.os.AddOrder(order);
            Form1.bindingSource1.DataSource = null;
            Form1.bindingSource1.DataSource = Form1.os.GetAllOrders();
            Close();
        }
        /// <summary>
        /// 挑选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            uint num = uint.Parse(textBox4.Text.ToString());
            string s = listBox1.SelectedItem.ToString();
            Goods good = new Goods(goods[s].id, s, goods[s].value);
            OrderDetail orderDetail = new OrderDetail(id++, good, num);
            orderDetails.Add(orderDetail);
            bindingSource2.DataSource = null;
            bindingSource2.DataSource = orderDetails;
        }
    }
}
