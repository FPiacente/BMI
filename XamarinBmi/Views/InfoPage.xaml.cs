
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBmi.Models;

namespace XamarinBmi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void DetailItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            var vm = BindingContext as InfoPageModel;
            vm.ShowOrHideBmiDetail();
        }


    }
}