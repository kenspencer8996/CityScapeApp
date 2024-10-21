using CityScapeApp.Views.Controls.House;
using CityScapeApp.Views.Controls.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class PersonEntity : EntityBase
    {
        IDispatcherTimer _showTimer;
        IDispatcherTimer _payTimer;
        HouseContent _host;
        public event EventHandler<PersonTimerFiredEventArg> ShowPersonTimerFired;
        public PersonEntity()
        {
            _showTimer = Application.Current.Dispatcher.CreateTimer();
            _showTimer.Interval = TimeSpan.FromSeconds(_TimerSeconds);
            _showTimer.Tick += (sender, e) => ShowTimerfired();

            _payTimer = Application.Current.Dispatcher.CreateTimer();
            _payTimer.Interval = TimeSpan.FromSeconds(30);
            _payTimer.Tick += (sender, e) => PaytimerFired();
        }
        private decimal _currentPay;
        private string _currentImage;
        public void StartPay(decimal payRate)
        {
            _currentPay = payRate;
            _payTimer.Start();
        }
        public void LeaveWork()
        {
            _currentPay = 0;
            _payTimer.Stop();
        }
        private void PaytimerFired()
        {
            Funds += _currentPay;
        }

        private void ShowTimerfired()
        {
            _host.IsVisible = true;
            PersonTimerFiredEventArg ev = new PersonTimerFiredEventArg(this);
            ShowPersonTimerFired(this, ev);
        }

        private string _Name = "";
        private bool _IsUser = false;
        private decimal _Funds = 0;
        public Object Host { get; set; }
        public Type HostType { get; set; }
        private PersonEnum _PersonRole = PersonEnum.Individual;
        private int _TimerSeconds = 49;
        private int _currentImageKey = 0;
        private int _personId = 0;

        public string CurrentImage
        {
            get
            {
                return _currentImage;
            }
            set
            {
                _currentImage = value;
            }
        }
        public int PersonId
        {
            get
            {
                return _personId;
            }
            set
            {
                _personId = value;
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

        public decimal Funds
        {
            get
            {
                return _Funds;
            }
            set
            {
                _Funds = value;
                OnPropertyChanged("Funds");
            }
        }
        public int CurrentImageKey
        {
            get
            {
                return _currentImageKey;
            }
            set
            {
                _currentImageKey = value;
            }
        }

        public PersonEnum PersonRole
        {
            get
            {
                return _PersonRole;
            }
            set
            {
                _PersonRole = value;
                OnPropertyChanged("PersonRole");
            }
        }
        public void Add(string name, decimal funds,
            PersonEnum role)
        {
            _Name = name;
            _Funds = funds;
            _PersonRole = role;
        }

        public void StartShowTimer()
        {
            _showTimer.Start();

        }
        public List<PersonEntity> Friends { get; set; }
        public void AddFriend(PersonEntity friend)
        {
            Friends.Add(friend);
        }
        public List<PersonImageEntity> Images { get; set; } = new List<PersonImageEntity>();
        public void AddPersonImage(PersonImageEntity image)
        {

            Images.Add(image);
        }
    }
}
