namespace program2
{
    class Order
    {
        public int orderID;
        public string Commodity;
        public string Customer;
        public Order(int t = 0, string s1 = "", string s2 = "")
        {
            orderID = t;
            Commodity = s1;
            Customer = s2;
        }
    }
}
