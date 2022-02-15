using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBmi.Utils
{
    static class BmiCalculation
    {
        public static double CalculateBmi(double height, double weight)
        {
            double heightPercent = height / 100;
            return Math.Round(weight / (heightPercent * heightPercent), 2);
        }
    }
}
