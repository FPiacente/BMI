using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBmi.Utils
{
    class BmiInfoTable
    {

        public string GetBmiInfoTable(double BMI)
        {
            if (BMI <= 16.0) { return "Starkes Untergewicht"; }
            if (BMI <= 18.4) { return "Leichtes Untergewicht"; }
            if (BMI <= 25.0) { return "Normalgewicht"; }
            if (BMI <= 39.9) { return "Übergewicht"; }
            if (BMI >= 40) { return "Massives Übergewicht"; }

            return null;
        }

        public static List<BmiDetail> GetBmiDetails()
        {
            return new List<BmiDetail>()
            {
               new BmiDetail("Starkes Untergewicht", "BMI von 0 bis 16", "Das ist viel zu wenig!"),
               new BmiDetail("Leichtes Untergewicht", "BMI von 16 bis 18", "Allzu schlank ist auch ungesund."),
               new BmiDetail("Normalgewicht", "BMI von 19 bis 25", "Du bist top in Form."),
               new BmiDetail("Übergewicht", "BMI von 26 bis 40", "Mal öfter auf Kuchen verzichten."),
               new BmiDetail("Massives Übergewicht", "BMI über 40", "Uh das ist deutlich zuviel!")
            };

        }
    }
}
