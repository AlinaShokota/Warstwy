using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Warstwy.Model;
using Warstwy.ViewModel.Command;

namespace Warstwy.ViewModel
{
    public class TempViewModel : INotifyPropertyChanged
    {
        public DispatcherTimer _timer;
        public ICommand SubmitButtonCommand { get; set; }

        private string _comoselectedValue="";
        public string ComoSelectedValue
        {
            get { return _comoselectedValue; }
            set { _comoselectedValue = value; CheckAndEnableButton(); }
        }

        private double currentTemp;
        public double CurrentTemp
        {
            get
            {
                return this.currentTemp;
            }
            set
            {
                
                currentTemp = value;
                OnPropertyChanged();
            }
        }

        Room room = new Room("");
        public TempViewModel()
        {
            
            
            //RoomName = room.Name;
            double temp = room.getRoomTemperature();
            CurrentTemp = Math.Round(temp, 2);
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += (sender, args) =>
            {
                temp = room.getRoomTemperature();
                CurrentTemp = Math.Round(temp, 2);
                //Console.WriteLine(CurrentTemp);
            };
            _timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void CheckAndEnableButton()
        {

            SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => { MessageBox.Show(ComoSelectedValue); });
            room.Name = ComoSelectedValue;
            OnPropertyChanged("SubmitButtonCommand");

        }
    }
}



/*public TempViewModel()
{
    Sensor sensor = new Sensor();
    _timer = new DispatcherTimer(DispatcherPriority.Render);
    _timer.Interval = TimeSpan.FromSeconds(3);
    _timer.Tick += (sender, args) =>
    {
        double temp = sensor.getActualTemperature("bedroom");
        CurrentTemp = Math.Round(temp, 2);
        Console.WriteLine(CurrentTemp);
    };
    _timer.Start();
}*/


/*public DispatcherTimer _timer;
ActualTemperature temp = new ActualTemperature();

public TempViewModel()
{
    _timer = new DispatcherTimer(DispatcherPriority.Render);
    _timer.Interval = TimeSpan.FromSeconds(3);
    _timer.Tick += (sender, args) =>
    {
        temp.updateTemp();
        Console.WriteLine(temp.Value);
    };
    _timer.Start();
}*/
