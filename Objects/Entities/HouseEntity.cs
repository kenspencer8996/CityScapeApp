using CityScapeApp.Views.Controls.House;
using CityScapeApp.Views.Controls.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class HouseEntity : EntityBase
    {
        IDispatcherTimer _showTimer;
        IDispatcherTimer _payTimer;
        //MainPage _host;
        public HouseEntity()
        {

        }
        public HouseEntity(string Name, string imageFileName,
            string imageLivingFileName, string imageKitchenFileName,
            string imageGarageFileName, string ownerName,
            bool IsUserHouse)
        {
            _Name = Name;
            _IsUserHouse = IsUserHouse;
            _imageFileName = imageFileName.ToLower();
            ImageLivingRoomFileName = imageLivingFileName.ToLower();
            ImageKitchenFileName = imageKitchenFileName.ToLower();
            ImageGarageFileName = imageGarageFileName.ToLower();
            OwnerName = ownerName;
        }
        private bool _isVisible = true;
        private string _Name;
        private bool _IsUserHouse;
        private string _imageFileName;
        private string _imageLivingRoomFileName;
        private string _imageKitchenFileName;
        private string _imageGarageFileName;
        private string _ownerName;

        public HouseContent Host { get; set; }
        public int HouseID { get; set; }
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnPropertyChanged("IsVisible");
            }
        }
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
        public string OwnerName

        {
            get
            {
                return _ownerName;
            }
            set
            {
                _ownerName = value;
                OnPropertyChanged("OwnerName");
            }
        }
        public bool IsUserHouse
        {
            get
            {
                return _IsUserHouse;
            }
            set
            {
                _IsUserHouse = value;
                OnPropertyChanged("IsUserHouse");
            }
        }


        public string NameAsControlName
        {
            get
            {
                return _Name.Replace(" ", "");
            }

        }
        public string ImageFileName
        {
            get
            {
                return _imageFileName;
            }
            set
            {
                _imageFileName = value;
                OnPropertyChanged("ImageFileName");
            }
        }
        public string ImageLivingRoomFileName
        {
            get
            {
                return _imageLivingRoomFileName;
            }
            set
            {
                _imageLivingRoomFileName = value;
                OnPropertyChanged("ImageLivingRoomFileName");
            }
        }


        public string ImageKitchenFileName
        {
            get
            {
                return _imageKitchenFileName;
            }
            set
            {
                _imageKitchenFileName = value;
                OnPropertyChanged("ImageKitchenFileName");
            }
        }
        public string ImageGarageFileName
        {
            get
            {
                return _imageGarageFileName;
            }
            set
            {
                _imageGarageFileName = value;
                OnPropertyChanged("ImageGarageFileName");
            }
        }
    }
}
