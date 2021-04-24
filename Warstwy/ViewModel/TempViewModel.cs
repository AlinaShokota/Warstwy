﻿using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Warstwy.Model;
using Warstwy.ViewModel.Command;

namespace Warstwy.ViewModel
{
    public class TempViewModel : INotifyPropertyChanged
    {
        public DispatcherTimer _timer;

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


        public TempViewModel()
        {
            
            Room room = new Room("livingroom");
            double temp = room.getRoomTemperature();
            CurrentTemp = Math.Round(temp, 2);
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(5);
            _timer.Tick += (sender, args) =>
            {
                temp = room.getRoomTemperature();
                CurrentTemp = Math.Round(temp, 2);
            };
            _timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
