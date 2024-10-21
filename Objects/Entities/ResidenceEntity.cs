using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class ResidenceEntity:EntityBase
    {
        private string _Name;
        private bool _IsHome;
        private string _ImageName;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public bool IsHome
        {
            get
            {
                return _IsHome;
            }
            set
            {
                _IsHome = value;
                OnPropertyChanged("IsHome");
            }
        }
        public string ImageName 
        {
            get
            {
                return _ImageName;
            }
            set
            {
                _ImageName = value;
                OnPropertyChanged("ImageName");
            }
        }
    }
}
