using CityScapeApp.Views.Controls.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
    public class careventArg
    {
        public careventArg(CarContent Car)
        { 
            this.Car = Car;
        }
        public CarContent Car { get; set; }
    }
}
