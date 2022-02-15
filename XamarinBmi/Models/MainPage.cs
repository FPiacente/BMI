using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinBmi.Models
{
    class MainPage
    {
        public ICommand StartXamarinBmiApplication { get; }

        public MainPage()
        {
            StartXamarinBmiApplication = new Command(() => { Application.Current.MainPage = new NavigationTab(); });
        }
    }
}
