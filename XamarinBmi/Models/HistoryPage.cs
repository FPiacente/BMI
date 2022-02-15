using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinBmi.Utils;

namespace XamarinBmi.Models
{
    class HistoryPage:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<BmiData> _datas;

        public ICommand RefreshBmi { get; }
        public ICommand DeleteHistory { get; }

        public ObservableCollection<BmiData> Data
        {
            set
            {
                _datas = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _datas;
            }
        }
        public HistoryPage()
        {
            RefreshBmi = new Command(() => { GetData(); });
            DeleteHistory = new Command(() => { DeleteAllHistory(); });
            GetData();
        }

        public async void GetData()
        {
            List<BmiData> tempData = new List<BmiData>();

            foreach (var data in await App.BmiDB.GetBMIs())
                tempData.Add(data);

            Data = new ObservableCollection<BmiData>(tempData); ;
        }

        public async void DeleteAllHistory()
        {
            string choice = await UserDialogs.Instance.ActionSheetAsync("Wirklich löschen?", "Nein", "Ja", CancellationToken.None, "Wollen Sie den Verlauf wirklich löschen?");

            if (choice != "Nein")
            {
                await App.BmiDB.ClearDB();
                GetData();
            }
        }
    }
}
