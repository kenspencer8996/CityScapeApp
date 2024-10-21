﻿using CityScapeApp.Views.Controls.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Viewmodels
{
    public class KitchenPageViewModel: BaseViewModel
    {
        public HouseContent House { get; set; }
        public string KitchenImage
        {
            get
            {
                return House.ImageKitchenFileName;
            }
        }
    }
}
