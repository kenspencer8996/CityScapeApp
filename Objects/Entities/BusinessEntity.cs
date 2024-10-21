using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class BusinessEntity : EntityBase
    {
        private string _Name = "";
        private decimal _EmployeePayHour;
        private string _ImageName;
        private BusinessTypeEnum _BusinessType;
        public int BusinessID { get; set; }
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
        public decimal EmployeePayHour
        {
            get
            {
                return _EmployeePayHour;
            }
            set
            {
                _EmployeePayHour = value;
                OnPropertyChanged("EmployeePayHour");
            }
        }
        internal string ImageName
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
        public BusinessTypeEnum BusinessType
        {
            get
            {
                return _BusinessType;
            }
            set
            {
                _BusinessType = value;
                OnPropertyChanged("BusinessType");
            }
        }


        internal void Add(string name, decimal employeePayHour, string imageName,
            BusinessTypeEnum business)
        {
            Name = name;
            EmployeePayHour = employeePayHour;
            ImageName = imageName;
            BusinessType = business;
        }
    }
}
