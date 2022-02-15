using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinBmi.Utils
{
    class BmiDetail
    {
        public string Title { get; set; }
        public string Range { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public BmiDetail(string title, string range, string description)
        {
            Title = title;
            Range = range;
            Description = description;
            IsVisible = false;
        }
    }
}
