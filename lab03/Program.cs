using System;
using System.Collections.Generic;

namespace exer1
{
    public class Vector
    {
        private double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double Length 
        { 
            get { return Math.Sqrt(x * x + y * y + z * z); } 
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            return new Vector(v2.x + v1.x, v2.y + v1.y, v2.z + v1.z);
        }

        public static Vector operator * (Vector v, double n)
        {
            return new Vector(v.x * n, v.y * n, v.z * n);
        }

        public static Vector operator * (double n, Vector v)
        {
            return v * n;
        }

        public static double operator * (Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        public static bool operator < (Vector v1, Vector v2)
        {
            return v1.Length < v2.Length;
        }

        public static bool operator > (Vector v1, Vector v2)
        {
            return v1.Length > v2.Length;
        }

        public static bool operator == (Vector v1, Vector v2)
        {
            return v1.Length == v2.Length;
        }

        public static bool operator != (Vector v1, Vector v2)
        {
            return v1.Length != v2.Length;
        }

        public static bool operator <= (Vector v1, Vector v2)
        {
            return v1.Length <= v2.Length;
        }

        public static bool operator >= (Vector v1, Vector v2)
        {
            return v1.Length >= v2.Length;
        }
    }

    public class Car : IEquatable<Car>
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int MaxSpeed { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object c)
        {
            return this == c as Car;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ MaxSpeed.GetHashCode() ^ Engine.GetHashCode();
        }

        public bool Equals(Car c)
        {
            return Name == c.Name && Engine == c.Engine && MaxSpeed == c.MaxSpeed;
        }
    }

    public class CarsCatalog
    {
        private List<Car> cars;

        public CarsCatalog(List<Car> args)
        {
            cars = args;
        }

        public string this[int index]
        {
            get
            {   
                return $"{cars[index].Name} {cars[index].Engine}";
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 3, 4);
            Vector v2 = new Vector(1, 3, 4);

            if (v1 == v2)
                Console.WriteLine("v1 == v2");

            double v = v2 * v1;
            Console.WriteLine(v);
        }
    }
}
