using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace homework5.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddOrderTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            order1.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            //正确结果
            Dictionary<uint, Order> result = new Dictionary<uint, Order>
            {
                [1] = order1
            };
            CollectionAssert.AreEqual(os.orderDict, result);
        }
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void AddOrderTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            order1.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order1);
        }

        [TestMethod]
        public void RemoveOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            order1.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.RemoveOrder(order1.OrderId);
            Dictionary<uint, Order> result = new Dictionary<uint, Order>();
            CollectionAssert.AreEqual(os.orderDict, result);
        }

        [TestMethod()]
        public void QueryOrderByIdTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            order1.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> order = os.QueryOrderById(order1.OrderId);
            //正确结果
            CollectionAssert.AreEqual(os.QueryAllOrders(), order);
        }

        [TestMethod]
        public void GetOrdersByGoodsNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            order1.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> order = os.QueryOrdersByGoodsName("cpp");
            List<Order> result = new List<Order>
            {
                order1
            };
            CollectionAssert.AreEqual(result, order);
        }


        [TestMethod]
        public void GetOrdersByCustomerNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            order1.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order> order = os.GetOrdersByCustomerName("Customer1");
            List<Order> result = new List<Order>
            {
                order1
            };
            CollectionAssert.AreEqual(result, order);
        }

        [TestMethod]
        public void UpdateOrderCustomerTest1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(1, "Customer2");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(1, customer2);
            order1.AddOrderDetail(orderDetails1);
            order2.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            OrderService result = new OrderService();
            os.AddOrder(order1);
            result.AddOrder(order1);
            os.UpdateOrderCustomer(order1.OrderId, customer2);
            CollectionAssert.AreEqual(os.orderDict.Values.ToList(), result.orderDict.Values.ToList());
            CollectionAssert.AreEqual(os.orderDict.Keys.ToList(), result.orderDict.Keys.ToList());
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void UpdateOrderCustomerTest2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(1, "Customer2");
            Goods cpp = new Goods(1, "cpp", 3);
            OrderDetail orderDetails1 = new OrderDetail(1, cpp, 20);
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(1, customer2);
            order1.AddOrderDetail(orderDetails1);
            order2.AddOrderDetail(orderDetails1);
            OrderService os = new OrderService();
            OrderService result = new OrderService();
            os.AddOrder(order1);
            result.AddOrder(order1);
            os.UpdateOrderCustomer(100000, customer2);
            CollectionAssert.AreEqual(os.orderDict.Values.ToList(), result.orderDict.Values.ToList());
            CollectionAssert.AreEqual(os.orderDict.Keys.ToList(), result.orderDict.Keys.ToList());
        }
    }
}
