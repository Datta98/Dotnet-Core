using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorLib.Calculator calculator = new CalculatorLib.Calculator();
            int result=  calculator.Add(5,10);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
