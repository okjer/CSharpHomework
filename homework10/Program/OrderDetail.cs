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
        [Key]
        public uint OrderDetailId { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }

        public OrderDetail(uint orderDetailId, Goods goods, uint quantity)
        {
            OrderDetailId = orderDetailId;
            Goods = new Goods(goods.GoodsId, goods.GoodsName, goods.GoodsValue);
            Quantity = quantity;
        }
        public OrderDetail() { }

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
