using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBmi
{

    public partial class NavigationTab : Xamarin.Forms.Shell
    {
        public NavigationTab()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.CalculatePage), typeof(Views.CalculatePage));
            Routing.RegisterRoute(nameof(Views.InfoPage), typeof(Views.InfoPage));
            Routing.RegisterRoute(nameof(Views.HistoryPage), typeof(Views.HistoryPage));
        }
    }
}