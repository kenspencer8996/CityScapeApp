using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
     internal class Imagehelper
    {
        internal static Image GetImageOfPerson(string filename, double width, double height)
        {
            Image thisImage = new Image();
            thisImage.Source = filename;
            thisImage.WidthRequest = width;
            thisImage.HeightRequest = height;
            return thisImage;
        }
        internal static Image GetImageOfHouse(string filename, double width, double height)
        {
            Image thisImage = new Image();
            thisImage.Source = filename;
            thisImage.WidthRequest = width;
            thisImage.HeightRequest = height;
            return thisImage;
        }
    }
}
