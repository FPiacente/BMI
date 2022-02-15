
using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinBmi.Utils;

namespace XamarinBmi.Models
{
    public class CalculatePage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly BmiInfoTable BmiInfoTable = new BmiInfoTable();

        public ICommand CalculateBmi { get; }
        public ICommand SaveBmi { get; }

        private double _height;
        private double _weight;
        private double _calculatedBmi;
        private string _bmiInfo = "-";

        public double Height
        {
            set
            {
                _height = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _height;
            }
        }

        public double Weight
        {
            set
            {
                _weight = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _weight;
            }
        }

        public double CalculatedBMI
        {
            set
            {
                _calculatedBmi = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _calculatedBmi;
            }
        }

        public string BmiInfo
        {
            set
            {
                _bmiInfo = value;
                NotifyPropertyChanged();
            }
            get
            {
                return _bmiInfo;
            }
        }

        public CalculatePage()
        {
            CalculateBmi = new Command(() => {

                if (Height == 0)
                {
                    UserDialogs.Instance.Alert("Ungültige Grösse!");
                    return;
                }

                if (Weight == 0)
                {
                    UserDialogs.Instance.Alert("Ungültiges Gewicht!");
                    return;
                }

                CalculatedBMI = BmiCalculation.CalculateBmi(Height, Weight); BmiInfo = BmiInfoTable.GetBmiInfoTable(CalculatedBMI);
            });

            SaveBmi = new Command(() => { SaveResult(); });
        }

        private async void SaveResult()
        {
            if (CalculatedBMI == 0 || CalculatedBMI == double.NaN || double.IsInfinity(CalculatedBMI) || BmiInfo == null)
            {
                UserDialogs.Instance.Alert("Erst muss ein BMI berechnet werden!", "Speichern nicht möglich!");
                return;
            }

            string choice = await UserDialogs.Instance.ActionSheetAsync("Speichern?", "Nein", "Ja");

            if (choice != "Nein")
            {
                await App.BmiDB.SaveNewRecord(new Utils.BmiData() {Date= System.DateTime.Now.ToString("dd.MM.yyyy HH:mm"), Name = "User", Height = Height, Weight = Weight, BMI = CalculatedBMI });
                UserDialogs.Instance.Alert("BMI erfolgreich gespeichert!");
            }
        }
    }
}