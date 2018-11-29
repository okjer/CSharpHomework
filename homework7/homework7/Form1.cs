using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using homework5;

namespace homework7
{
    public partial class Form1 : Form
    {
        public static OrderService os;
        public Form1()
        {
            InitializeComponent();
            Customer customer1 = new Customer(11111111111, "Customer1");
            Customer customer2 = new Customer(22222222222, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order("20000317123", customer1);
            Order order2 = new Order("20000317124", customer2);
            Order order3 = new Order("20000317125", customer2);
            order1.AddOrderDetail(orderDetails1);
            order1.AddOrderDetail(orderDetails2);
            order1.AddOrderDetail(orderDetails3);
            //order1.AddOrderDetails(orderDetails3);
            order2.AddOrderDetail(orderDetails2);
            order2.AddOrderDetail(orderDetails3);
            order3.AddOrderDetail(orderDetails3);

            os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            bindingSource1.DataSource = os.OrderList;
        }
       
        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, System.EventArgs e)
        {
            string i = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            new Form2(i).ShowDialog();
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            new Form3().ShowDialog();
        }
        /// <summary>
        /// 按订单号查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, System.EventArgs e)
        {
            string i = textBox1.Text;
            Order order = os.QueryOrderById(i);
            bindingSource1.DataSource = order;
        }
        /// <summary>
        /// 订单明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, System.EventArgs e)
        {
            string i = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            new Form5(i).ShowDialog();
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            string s = textBox2.Text;
            List<Order> order = os.GetOrdersByCustomerName(s);
            bindingSource1.DataSource = order;
        }
        /// <summary>
        /// 按商品名查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, System.EventArgs e)
        {
            string s = textBox3.Text;
            List<Order> order = os.QueryOrdersByGoodsName(s);
            bindingSource1.DataSource = order;
        }

        /// <summary>
        /// 生成html文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click_1(object sender, System.EventArgs e)
        {
            os.XsltTransform();
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                string s = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (s == "") return;
                os.RemoveOrder(s);
                bindingSource1.DataSource = null;
                bindingSource1.DataSource = os.OrderList;
            }catch(Exception exc)
            {
                string x = exc.ToString();
            }
        }
    }
}
