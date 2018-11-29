using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace homework5
{
    class Program1
    {
        public static void Main()
        {
            try
            {
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

                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.GetOrdersByCustomerName("Customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryOrdersByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                Console.WriteLine("Remove order(id=2) and qurey all");
                os.RemoveOrder("2");
                orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");
                os.GetOrdersByMoney(30);
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());
                Console.WriteLine("");

                //序列化
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                String xmlFileName = "s.xml";
                os.Export(os.OrderList,xmlFileName);
                string s = File.ReadAllText("s.xml");
                Console.WriteLine(s);
                //反序列化
                List<Order> orders1 = os.Import(xmlFileName);//as List<Order>;
                //if (orders1 == null) Console.WriteLine("fuck");
                foreach (Order i in orders1) Console.WriteLine(i);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
