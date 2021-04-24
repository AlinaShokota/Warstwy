using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Warstwy.Model
{
    public class Room : INotifyPropertyChanged
    {
        Sensor sensor = new Sensor();

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        } 

        private double actualTemp;
        public double ActualTemp
        {
            get
            {
                return actualTemp;
            }
            set
            {
                actualTemp = value;
                OnPropertyChanged();
            }
        }

        public Room(String name)
        {
            this.Name = name;
        }

        

        public double getRoomTemperature()
        {
            return sensor.getActualTemperature(this.name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
