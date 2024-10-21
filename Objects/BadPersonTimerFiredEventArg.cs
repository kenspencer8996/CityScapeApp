using CityScapeApp.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
    public class BadPersonTimerFiredEventArg
    {
        public BadPersonEntity Person { get; set; }
        public BadPersonTimerFiredEventArg(BadPersonEntity person)
        {
            Person = person;
        }

    }
}
