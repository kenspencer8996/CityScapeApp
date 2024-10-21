using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Viewmodels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        private string? _title = string.Empty;
        public string? _description = string.Empty;  
        public bool IsBusy = false;
        public string? Title
        { get { return _title; } 
          set 
            {
                SetProprty(ref _title, value);
            } 
        }
        public string? Description
        {
            get { return _description; }
            set
            {
                SetProprty(ref _description, value);
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  

        }
        public bool  SetProprty<T>(ref T backingStore,T value,
            [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
