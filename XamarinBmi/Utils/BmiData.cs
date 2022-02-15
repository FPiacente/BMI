using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBmi.Utils
{
    public class BmiData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }


        public string Name { get; set; }
        public string Date { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
    }
}
