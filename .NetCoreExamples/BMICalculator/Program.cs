using System;

namespace BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            BMIUserInputLib.ConsoleInputReader userInputs = new BMIUserInputLib.ConsoleInputReader();


            BMIValueCalculationLib.CalculateBMI value = new BMIValueCalculationLib.CalculateBMI();
            double BmiValue = value.Calculator(userInputs.GetUserHeight(), userInputs.GetUserWeight());

            BMIValueValidationLib.BmiValueValidation validate = new BMIValueValidationLib.BmiValueValidation();
            string message = validate.CheckBmiValue(BmiValue);

            BMIResultDisplayLib.MessageDisplay result = new BMIResultDisplayLib.MessageDisplay();
            result.Display(message);
            Console.ReadKey();
        }
    }
}
