using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XamarinBmi.Utils;
using System.Collections.ObjectModel;

namespace XamarinBmi.Models
{
    class InfoPageModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<BmiDetail> _bmiInfo;
        private BmiDetail _selectedDetail { get; set; }
        private BmiDetail _oldDetail { get; set; }

        public InfoPageModel()
        {
            BmiInfo = new ObservableCollection<BmiDetail>(BmiInfoTable.GetBmiDetails());
        }

        public ObservableCollection<BmiDetail> BmiInfo
        {
            get { return _bmiInfo; }

            set
            {
                _bmiInfo = value;
                NotifyPropertyChanged();
            }
        }

        public BmiDetail SelectedDetail
        {
            get { return _selectedDetail; }

            set 
            {
                _selectedDetail = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ShowOrHideBmiDetail()
        {
            if(_oldDetail == SelectedDetail)
            {
                SelectedDetail.IsVisible = !SelectedDetail.IsVisible;
                UpdateDetail(SelectedDetail);
            }
            else
            {
                if(_oldDetail != null)
                {
                    _oldDetail.IsVisible = false;
                    UpdateDetail(_oldDetail);
                }

                SelectedDetail.IsVisible = true;
                UpdateDetail(SelectedDetail);
            }

            _oldDetail = SelectedDetail;
        }

        private void UpdateDetail(BmiDetail bmiDetail)
        {
            var index = BmiInfo.IndexOf(bmiDetail);
            BmiInfo.Remove(bmiDetail);
            BmiInfo.Insert(index, bmiDetail);
        }
    }
}
