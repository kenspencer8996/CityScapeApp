using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
   public class VehicleEntity :  EntityBase
    {
        private string _Name;
        private bool _IsSelected;
        private bool _IsUser;
        private decimal _Cost;
        private string _ImageName;
        private VechicleTypeEnum _VechicleType;

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

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public bool IsUser
        {
            get
            {
                return _IsUser;
            }
            set
            {
                _IsUser = value;
                OnPropertyChanged("IsUser");
            }
        }
        public decimal Cost
        {
            get
            {
                return _Cost;
            }
            set
            {
                _Cost = value;
                OnPropertyChanged("Cost");
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
        public VechicleTypeEnum VechicleType
        {
            get
            {
                return _VechicleType;
            }
            set
            {
                _VechicleType = value;
                OnPropertyChanged("Name");
            }
        }

    }
}
