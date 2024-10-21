using CityScapeApp.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
    public class BadPersonDroppedFiredEventArg
    {
       private int _badpersonnumber;
       private int _badpersonid;

        public BadPersonDroppedFiredEventArg(int badpersonnumber, int badpersonid)
        {
            _badpersonnumber = badpersonnumber;
            _badpersonid = badpersonid;
        }
        public int BadPersonNumber
        { get { return _badpersonnumber; } }
        public int BadPersonId
        { get { return _badpersonid; } }
    }
}
