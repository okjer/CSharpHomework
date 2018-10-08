namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            string[] Comname = new string []{ "a", "b", "c", "d", "e", "f" };
            string[] Cusname = new string[] { "A", "B", "C", "D", "E", "F" };
            for (int i = 0; i < 6; i++)
            {
                Order t = new Order(i + 1, Comname[i], Cusname[i]);
                orderService.AddOrder(t);
            }
            orderService.PrintAllOrder();//打印所有订单

            orderService.DeleteAsId(1); 
            orderService.DeleteAsCom("b");
            orderService.DeleteAsCus("C");
            orderService.PrintAllOrder();
            Order r = orderService.FindCus("D");//按客户名查找，也可按订单号，商品名称查找
            Order c = new Order(444,"ddd","DDD");
            orderService.Change(r, c);
            orderService.PrintOrder(r);
        }
    }
}
