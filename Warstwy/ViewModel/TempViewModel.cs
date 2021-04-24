
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
            set {
                _comoselectedValue = value;
                ChangeRoomName(); }
        }

        private double goalTemp;
        public double GoalTemp
        {
            get
            {
                return goalTemp;
            }
            set
            {

                goalTemp = value;
                ChangeRoomName();
                CheckAndEnableButton();
                OnPropertyChanged();
            }
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
            
            double temp = room.getRoomTemperature(GoalTemp);
            CurrentTemp = Math.Round(temp, 2);
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += (sender, args) =>
            {
                temp = room.getRoomTemperature(GoalTemp);
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

        public void ChangeRoomName()
        {
            room.Name = ComoSelectedValue;
        }

        public void CheckAndEnableButton()
        {
            string result = string.Empty;
            if (room.Name.Equals("")){
                result = string.Format("Choose the room!");
                SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                    MessageBox.Show(result);
                });
            }
            else
            {
                if (GoalTemp >= 17 && GoalTemp <= 28)
                {
                    result = string.Format("Goal temperature is set: \n{0}", GoalTemp);
                    SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                        MessageBox.Show(result);
                        room.GoalTemp = GoalTemp;
                    });
                }
                else if (GoalTemp > 28)
                {
                    result = result = string.Format("Goal temperature \n{0} is too high. Enter lower temperature", GoalTemp);
                    SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                        MessageBox.Show(result);
                    });
                }
                else
                {
                    result = result = string.Format("Goal temperature \n{0} is too low. Enter higher temperature", GoalTemp);
                    SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                        MessageBox.Show(result);
                    });
                }
            }
            

            

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
