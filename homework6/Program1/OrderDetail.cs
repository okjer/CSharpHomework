using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    /**
     * OrderDetail class : a entry of an order object
     * to record the goods, its quantity and so on.
     **/
    [Serializable]
    public class OrderDetail
    {

        /// <summary>
        /// OrderDetail constructor
        /// </summary>
        /// <param name="orderDetailId">orderDetail's id</param>
        /// <param name="goods">orderDetail's goods</param>
        /// <param name="quantity">goods quantity</param>
        public OrderDetail(uint orderDetailId, Goods goods, uint quantity)
        {
            OrderDetailId = orderDetailId;
            Goods = goods;
            Quantity = quantity;
        }
        public OrderDetail() { }
        /// <summary>
        /// OrderDetail's id
        /// </summary>
        public uint OrderDetailId { get; set; }

        

        /// <summary>
        /// orderDetail's goods
        /// </summary>
        public Goods Goods { get; set; }

        /// <summary>
        /// goods quantity
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the OrderDetail object</returns>
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{OrderDetailId}:  ";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }
    }
}
