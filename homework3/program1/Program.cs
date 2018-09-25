using System;
using System.Configuration;

namespace program1
{
    abstract class Polygon
    {
        public virtual void display()
        {
        }
    }
    class TrianglePolygon : Polygon
    {
        double a, b, c;
        public TrianglePolygon(double[] nums)
        {
            this.a = nums[0]; this.b = nums[1]; this.c = nums[2];
            Console.WriteLine("创建了三角形，三边长{0},{1},{2}",a,b,c);
        }
        public override void display()
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                double p = (a + b + c) / 2;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("三角形面积为{0}",s);
            }
            else
            {
                Console.WriteLine("不能组成三角形");
            }
        }
    }
    class SquarePolygon : Polygon
    {
        double a;
        public SquarePolygon(double[] nums)
        {
            a = nums[0];
            Console.WriteLine("创建正方形,边长{0}",a);
        }
        public override void display()
        {
            Console.WriteLine("正方形面积{0}",a*a);
        }
    }
    class RectanglePolygon : Polygon
    {
        double a, b;
        public RectanglePolygon(double[] nums)
        {
            a = nums[0]; b = nums[1];
            Console.WriteLine("创建长方形,长{0},宽{1}",a,b);
        }
        public override void display()
        {
            Console.WriteLine("长方形面积{0}",a*b);
        }
    }
    class CirclePolygon : Polygon
    {
        double r;
        public CirclePolygon(double[] nums)
        {
            r = nums[0];
            Console.WriteLine("创建圆形,半径{0}",r);
        }
        public override void display()
        {
            Console.WriteLine("圆形面积{0}",r*r*3.14);
        }
    }
    class PolygonFactory
    {
        public static Polygon getPolygon(string type,string value)
        {
            string[] input = value.Split(',');
            double[] nums = Array.ConvertAll(input, double.Parse);
            Polygon polygon = null;
            if(type.ToLower() == "rectangle")
            {
                polygon = new RectanglePolygon(nums);
                Console.WriteLine("初始化长方形");
            }
            else if (type.ToLower() == "triangle")
            {
                polygon = new TrianglePolygon(nums);
                Console.WriteLine("初始化三角形");
            }
            else if (type.ToLower() == "circle")
            {
                polygon = new CirclePolygon(nums);
                Console.WriteLine("初始化圆形");
            }
            else if (type.ToLower() == "square")
            {
                polygon = new SquarePolygon(nums);
                Console.WriteLine("初始化正方形");
            }
            return polygon;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string key = ConfigurationManager.AppSettings["Polygon"];
            string value = ConfigurationManager.AppSettings[key];
            Polygon polygon;
            polygon = PolygonFactory.getPolygon(key,value);
            polygon.display();
        }
    }
}
