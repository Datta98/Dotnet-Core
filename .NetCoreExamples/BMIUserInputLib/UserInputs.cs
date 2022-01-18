using System;

namespace BMIUserInputLib
{
    public class ConsoleInputReader
    {
         public double GetUserHeight()
        {            
            double height = Convert.ToDouble(this.ReadFromConsole("Enter your height in Meters:"));
            return height;
        }

        public double GetUserWeight()
        {   
            double weight = Convert.ToDouble(this.ReadFromConsole("Enter your weight in kg:"));
            return weight;

        }
       
         private string ReadFromConsole(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;
        }
    }
}
