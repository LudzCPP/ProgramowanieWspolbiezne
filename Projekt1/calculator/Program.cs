using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Program
    {
        
    static void Main(string[] args)
        {
        double a = 5;
        double b = 2;

        Console.WriteLine($"Dodawanie: {a} + {b} = {dodaj(a, b)}");
        Console.WriteLine($"Odejmowanie: {a} - {b} = {odejmi(a, b)}");
        Console.WriteLine($"Mnozenie: {a} * {b} = {pomnoz(a, b)}");
        Console.WriteLine($"Dzielenie: {a} * {b} = {podziel(a, b)}");

        Console.ReadKey();
    }
        public static double dodaj(double a, double b)
        {
            return a + b;
        }

        public static double odejmi(double a, double b)
        {
            return a - b;
        }

        public static double pomnoz(double a, double b)
        {
            return a * b;
        }

        public static double podziel(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Divider cannot be zero");
            }
            return a / b;
        }
    }

}

