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
        //private Dictionary<uint, OrderDetail> orderDetailsDict;
        public List<OrderDetail> orderDetailList;

        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order()
        {
            orderDetailList = new List<OrderDetail>();
        }
        public Order(string orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = new Customer(customer.CustomerId, customer.CustomerName);
            orderDetailList = new List<OrderDetail>();
        }
        /// <summary>
        /// 年月日加三位流水号
        /// </summary>
        public string OrderId { get; set; }
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
            if (orderDetailList.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.OrderDetailId} is already existed!");
            }//"$",占位符，将{}中变量或表达式的值替换
            else
            {
                orderDetailList.Add(orderDetail);
                Money += orderDetail.Quantity * (uint)orderDetail.Goods.GoodsValue;
            }
        }

        /// <summary>
        /// remove orderDetail by orderDetailId from order
        /// </summary>
        /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
        public void RemoveOrderDetail(uint orderDetailId)
        {
            var findList = from n in orderDetailList where n.OrderDetailId == orderDetailId select n;
            if (findList != null)
            {
                foreach (var n in findList)
                {
                    Money -= n.Quantity * (uint)n.Goods.GoodsValue;
                    orderDetailList.Remove(n);
                }
            }
            else
            {
                throw new Exception($"orderDetails-{orderDetailId} is not existed!");
            }
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Order object</returns>
        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{OrderId}, customer:({Customer})";
            orderDetailList.ForEach(od => result += "\n\t" + od);
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
