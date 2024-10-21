using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class EntityBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        

        public void OnPropertyChanged(string propertyName)
        {
            if (Global.Loading == false)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
