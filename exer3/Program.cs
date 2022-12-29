using System;


namespace exer3
{

    public class Currency
    {
        public static double USDcoef;
        public static double EURcoef;
        public virtual double Value { get; set; }
    }

    public class CurrencyUSD : Currency
    {
        public override double Value { get; set; }
        public CurrencyUSD() { Value = 0; }
        public CurrencyUSD(CurrencyUSD ur)
        {
            Value = ur.Value;
        }

        public static implicit operator CurrencyUSD(CurrencyRUB val)
        {
            return new CurrencyUSD { Value = val.Value / USDcoef };
        }

        public static implicit operator CurrencyUSD(CurrencyEUR val)
        {
            return new CurrencyUSD { Value = val.Value * EURcoef / USDcoef };
        }
    }

    public class CurrencyEUR : Currency
    {
        public override double Value { get; set; }
        public CurrencyEUR() { Value = 0; }
        public CurrencyEUR(CurrencyEUR er)
        {
            Value = er.Value;
        }

        public static implicit operator CurrencyEUR(CurrencyUSD val)
        {
            return new CurrencyEUR { Value = val.Value * USDcoef / EURcoef };
        }

        public static implicit operator CurrencyEUR(CurrencyRUB val)
        {
            return new CurrencyEUR { Value = val.Value / EURcoef };
        }
    }

    public class CurrencyRUB : Currency
    {
        public override double Value { get; set; }
        public CurrencyRUB() { Value = 0; }
        public CurrencyRUB(CurrencyRUB rb)
        {
            Value = rb.Value;
        }

        public static implicit operator CurrencyRUB(CurrencyEUR val)
        {
            return new CurrencyRUB { Value = EURcoef * val.Value };
        }

        public static implicit operator CurrencyRUB(CurrencyUSD val)
        {
            return new CurrencyRUB { Value = USDcoef * val.Value };
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter USD to RUB:");
            Currency.USDcoef = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter EUR to RUB:");
            Currency.EURcoef = Convert.ToDouble(Console.ReadLine());

            CurrencyUSD us;
            CurrencyEUR er;
            CurrencyRUB rb = new CurrencyRUB();

            rb.Value = 100;
            us = rb;
            er = rb;
            

            Console.WriteLine($"RUB:{rb.Value}\tEUR:{er.Value}\tUSD:{us.Value}");

            us.Value = 100;
            rb = us;
            er = rb;

            Console.WriteLine($"RUB:{rb.Value}\tEUR:{er.Value}\tUSD:{us.Value}");


            us.Value = 1000;
            rb = us;
            er = us;

            Console.WriteLine($"RUB:{rb.Value}\tEUR:{er.Value}\tUSD:{us.Value}");
        }
    }
}
