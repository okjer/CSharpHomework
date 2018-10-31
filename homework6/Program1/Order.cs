using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    /**
    * Order class : order 
    * to record each goods and its quantity in this ordering
    **/
    [Serializable]
    public class Order
    {

        // uint : orderDetail's id, OrderDetail : OrderDetail obj
        public Dictionary<uint, OrderDetail> orderDetailsDict;
        public List<OrderDetail> orderList; 

        public void UpdateOrderList()
        {
            orderList = orderDetailsDict.Values.ToList();
        }

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order() {
            orderDetailsDict = new Dictionary<uint, OrderDetail>();
            orderList = new List<OrderDetail>();
        }
        public Order(uint orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            orderDetailsDict = new Dictionary<uint, OrderDetail>();
            orderList = new List<OrderDetail>();
        }
        /// <summary>
        /// order id
        /// </summary>
        public uint OrderId { get; set; }
        /// <summary>
        /// the man who orders goods
        /// </summary>
        public Customer Customer { get; set; }

        public uint Money { get; set; }

        /// <summary>
        /// add a new orderDetail to order
        /// </summary>
        /// <param name="orderDetail">the new orderDetail which will be added</param>
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetailsDict.ContainsKey(orderDetail.OrderDetailId))
            {
                throw new Exception($"orderDetails-{orderDetail.OrderDetailId} is already existed!");
            }//"$",占位符，将{}中变量或表达式的值替换
            else
            {
                orderDetailsDict[orderDetail.OrderDetailId] = orderDetail;
                Money += orderDetail.Quantity * (uint)orderDetail.Goods.GoodsValue;
            }
        }

        /// <summary>
        /// remove orderDetail by orderDetailId from order
        /// </summary>
        /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
        public void RemoveOrderDetail(uint orderDetailId)
        {
            if (orderDetailsDict.ContainsKey(orderDetailId))
            {
                Money -= orderDetailsDict[orderDetailId].Quantity * (uint)orderDetailsDict[orderDetailId].Goods.GoodsValue;
                orderDetailsDict.Remove(orderDetailId);
            }
            else
            {
                throw new Exception($"orderDetails-{orderDetailId} is not existed!");
            }
        }

        /// <summary>
        /// get all orderDetails in this order
        /// </summary>
        /// <returns>List<OrderDetail></returns>
        public List<OrderDetail> QueryAllOrderDetails()
        {
            return orderDetailsDict.Values.ToList();
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Order object</returns>
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{OrderId}, customer:({Customer})";
            orderList.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
        //public override bool Equal(object other)
        //{
        //    bool ret = false;
        //    var toComparWith = other as Order;
        //    if (other == null) return ret;
            
        //}
    }
}
