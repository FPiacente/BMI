using System;
using System.IO;
using Xamarin.Forms;
using XamarinBmi.Utils;

namespace XamarinBmi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        static BmiDatabase bmiDB;

        public static BmiDatabase BmiDB
        {
            get
            {
                if (bmiDB == null)
                {
                    bmiDB = new BmiDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BMIs.db3"));
                }
                return bmiDB;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
