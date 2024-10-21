using CityScapeApp.Views.Controls.House;
using CityScapeApp.Views.Controls.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class BadPersonEntity:EntityBase
    {
       public event EventHandler<BadPersonTimerFiredEventArg> ShowPersonTimerFired;
        public BadPersonEntity() 
        {
        }
        public PersonEntity BadPerson {  get; private set; }
        private decimal _StolenMoneyOnHand;
        public BadPersonnContent Host { get; set; }
        private int _TimerSeconds = 49;
        private int _currentImage = 0;
     
        public int PersonID
        {
            get
            {
                return BadPerson.PersonId;
            }
        }
        public string PersonName
        {
            get
            {
                return BadPerson.Name;
            }
        }
        public decimal StolenMoneyOnHand
        {
            get
            {
                return _StolenMoneyOnHand;
            }
            set
            {
                _StolenMoneyOnHand = value;
                OnPropertyChanged("Funds");
            }
        }
        public string CurrentImage
        {
            get
            {
                if (BadPerson.Images.Count() > 0)
                    return BadPerson.Images[_currentImage].FilePath;
                else
                    return "imagenofoundmessage.png";
            }
           
        }
        public List<PersonImageEntity> Images
        {
            get
            {
                if (BadPerson.Images.Count() > 0)
                    return BadPerson.Images;
                else
                    return new List<PersonImageEntity> ();
            }
        }
        public void Add(decimal 
            StolenFunds, PersonEntity person)
        {
            BadPerson = person;
            _StolenMoneyOnHand = StolenFunds;
        }

       
    }
}
