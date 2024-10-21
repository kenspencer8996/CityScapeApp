using CityScapeApp.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
    public class PersonTimerFiredEventArg
    {
        public PersonEntity Person { get; set; }
        public PersonTimerFiredEventArg(PersonEntity person)
        {
            Person = person;
        }
    }
}
