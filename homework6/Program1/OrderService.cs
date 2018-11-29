using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace homework5
{
    /**
     * OrderService:provide service for users about ordering,
     * like add order, remove order, query order and so on
     * 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
     * */
    public class OrderService
    {

        // uint : orderId, Order : Order obj
        public List<Order> OrderList { get; }
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService()
        {
            OrderList = new List<Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order)
        {
            string s = @"^\d{11}$";
            if (!Regex.IsMatch(order.OrderId, s)) throw new Exception("date is not matching");
            if (OrderList.Contains(order))
                throw new Exception($"order-{order.OrderId} is already existed!");
            else OrderList.Add(order);
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(string orderId)
        {
            //OrderList.RemoveAll(x => x.OrderId.Equals(orderId));
            foreach (Order order in OrderList)
            {
                if (order.OrderId == orderId)
                {
                    OrderList.Remove(order);
                    break;
                }
            }
            return;
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders()
        {
            return OrderList;
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public Order QueryOrderById(string orderId)
        {
            var x = from n in OrderList where n.OrderId == orderId select n;
            return x.ToList().First();
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryOrdersByGoodsName(string goodsName)
        {
            //foreach (Order order in orderDict.Values.ToList())
            //{
            //    List<OrderDetail> orderDetailsList = order.QueryAllOrderDetails();
            //    foreach (OrderDetail od in orderDetailsList)
            //    {
            //        if (od.Goods.GoodsName == goodsName)
            //        {
            //            result.Add(order);
            //            break;
            //        }
            //    }
            //}
            //var ret = orderDict.Where(a => a.Value.QueryAllOrderDetails().Exists( c => c.Goods.GoodsName == goodsName)).Select<>
            var ret = from item in OrderList where item.orderDetailList.Exists(c => c.Goods.GoodsName == goodsName) select item;
            return ret.ToList();
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> GetOrdersByCustomerName(string customerName)
        {
            var ret = from item in OrderList where item.Customer.CustomerName == customerName select item;
            return ret.ToList();
        }

        public List<Order> GetOrdersByMoney(uint n)
        {
            var ret = from item in OrderList where item.Money >= n select item;
            return ret.ToList();
        }

        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateOrderCustomer(string orderId, Customer newCustomer)
        {
            Order order = OrderList.Find(n => n.OrderId.Equals(orderId));
            if (order != null)
            {
                order.Customer = new Customer(newCustomer.CustomerId, newCustomer.CustomerName);
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        /*other update function will write in the future.*/
        /// <summary>
        /// xml序列化
        /// </summary>
        public void Export(object obj, string fileName)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                ser.Serialize(fs, obj);
            }

        }
        public List<Order> Import(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                object obj2 = ser.Deserialize(fs);
                return obj2 as List<Order>;
            }
        }
        public void XsltTransform()
        {
            Export(OrderList, @"..\..\a.xml");
            XmlDocument xml = new XmlDocument();
            xml.Load(@"..\..\a.xml");//加载xml文档

            XPathNavigator nav = xml.CreateNavigator();
            nav.MoveToRoot();//游标移动到根节点

            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(@"..\..\a.xslt");

            FileStream outFileStream = File.OpenWrite(@"..\..\a.html");
            XmlTextWriter writer =
                new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
            xt.Transform(nav, null, writer);
        }
    }
}
