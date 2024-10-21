using CityScapeApp.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
    public class CityAppMasterEntity
    {
        public List<CityappEntity> CityApp { get; set; } = new List<CityappEntity>();
        public int CurrentCityAppNumber { get; set; } = 0;
        public void AddCityapp(CityappEntity cityapp)
        {
            CurrentCityAppNumber++;
            cityapp.CityAppNumber = CurrentCityAppNumber;
            CityApp.Add(cityapp);
        }

    }
}
