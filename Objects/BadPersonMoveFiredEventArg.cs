using CityScapeApp.Objects.Entities;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{

    public class BadPersonMoveFiredEventArg
    {
        public bool MoveNext = false;
        public double _x;
        public double _y;
       public BadPersonMoveFiredEventArg(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public Rect GetRectCoordinates()
        {
            Rect locRec = new Rect();
            locRec.X = _x;
            locRec.Y = _y;
            locRec.Height = AbsoluteLayout.AutoSize;
            locRec.Width = AbsoluteLayout.AutoSize;
            return locRec;
        }
    }
}
