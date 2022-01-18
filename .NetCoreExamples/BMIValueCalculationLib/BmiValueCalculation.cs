using System;


namespace BMIValueCalculationLib
{
    public class CalculateBMI
    {
         public double Calculator(double height, double weight)
        {
           double  bmivalue = weight / height;
            return bmivalue;
        }
    }
}
