using System;

namespace DividingPolynoms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Polynom 1: ");
            //string pl1 = Console.ReadLine();
            //Polynom a = new Polynom(pl1);

            //Console.WriteLine("Polynom 2: ");
            //string pl2 = Console.ReadLine();
            //Polynom b = new Polynom(pl2);

            Polynom a = new Polynom("x15");
            Polynom b = new Polynom("x5+x4+x2+1");

            //111111011110001

            Console.WriteLine("\n");
            Console.WriteLine(String.Format("| {0}", a));
            Console.WriteLine(String.Format("| ------------------"));
            Console.WriteLine(String.Format("| {0}", b));
            Console.WriteLine("\n");

            Polynom[] c = a.divideBy(b);

            Console.WriteLine(c[1].infoCalculations);
            Console.WriteLine(String.Format("Remainder: {0}", c[1]));
            Console.WriteLine(String.Format("Result: {0}", c[0]));
        }
    }
}
