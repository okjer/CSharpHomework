using System;
using System.Collections.Generic;
using System.Linq;

namespace program2
{

    class OrderService
    {
        List<Order> list = new List<Order>();
        public void AddOrder(Order r)
        {
            list.Add(r);
        }
        public Order FindID(int t)
        {
            return list.Find(c => c.orderID == t);
        }
        public Order FindCom(string t)
        {
            return list.Find(c => c.Commodity.Equals(t));
        }
        public Order FindCus(string t)
        {
            return list.Find(c => c.Customer.Equals(t));
        }
        public void DeleteAsId(int t)
        {
            try
            {
                list.Remove(list.Where(p => p.orderID == t).FirstOrDefault());
            }
            catch (Exception e)
            {
                Console.WriteLine("error when delete as orderID");
            }
        }
        public void DeleteAsCus(string t)
        {
            try
            {
                list.Remove(list.Where(p => p.Customer.Equals(t)).FirstOrDefault());
            }
            catch (Exception e)
            {
                Console.WriteLine("error when delete as customer name");
            }
        }
        public void DeleteAsCom(string t)
        {
            try
            {
                list.Remove(list.Where(p => p.Commodity.Equals(t)).FirstOrDefault());
            }
            catch (Exception e)
            {
                Console.WriteLine("error when delete as commodity name");
            }
        }
        public void Change(Order a,Order b)
        {
            Order c = list.Find(p => p == a);
            c.orderID = b.orderID;
            c.Commodity = b.Commodity;
            c.Customer = b.Customer;
        }
        public void PrintAllOrder()
        {
            foreach(Order r in list){
                Console.WriteLine("OrderID = {0},Commodity Name = {1},Customer Name = {2}", r.orderID, r.Commodity, r.Customer);
            }
            Console.WriteLine();
        }
        public void PrintOrder(Order r)
        {
            try {
                Console.WriteLine("OrderID = {0},Commodity Name = {1},Customer Name = {2}\n", r.orderID, r.Commodity, r.Customer);
            }
            catch(Exception e)
            {
                Console.WriteLine("要打印的对象为空");
            }
        }
    }
}
