using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

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
        public Dictionary<uint, Order> orderDict { get; }
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.OrderId))
                throw new Exception($"order-{order.OrderId} is already existed!");
            orderDict[order.OrderId] = order;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict.Remove(orderId);
            }
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public List<Order> QueryOrderById(uint orderId)
        {
            List<Order> result = new List<Order>();
            if (orderDict.ContainsKey(orderId))
            {
                result.Add(orderDict[orderId]);
            }
            return result;
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
            var ret = from item in orderDict where item.Value.QueryAllOrderDetails().Exists(c => c.Goods.GoodsName == goodsName) select item.Value;
            return ret.ToList();
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order>  GetOrdersByCustomerName(string customerName)
        {
            var ret = from item in orderDict where item.Value.Customer.CustomerName == customerName select item.Value;
            return ret.ToList();
        }

        public List<Order> GetOrdersByMoney(uint n)
        {
            var ret = from item in orderDict where item.Value.Money >= n select item.Value;
            return ret.ToList();
        }

        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateOrderCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
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
        public void Export(XmlSerializer ser, string FileName, List<Order> orders)
        { 
            foreach (Order i in orders)
            {
                i.UpdateOrderList();
            }
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                ser.Serialize(fs, orders);
            }
        }
        public List<Order> Import(XmlSerializer ser, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                List<Order> obj = (List<Order>)ser.Deserialize(fs);
                return obj;
            }                     
        }
    }
}
