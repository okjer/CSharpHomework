using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace homework5
{
    /**
    * Order class : order 
    * to record each goods and its quantity in this ordering
    **/
    [Serializable]
    public class Order
    {
        [Key]
        public string OrderId { get; set; }
        public uint Money { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> orderDetailList;

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
