﻿using CityScapeApp.Views;

namespace CityScapeApp.Viewmodels
{
    public class AirportViewModel : BaseViewModel
    {
        private string _airportOverview = "airport3d.jpg";
        private string _airportRunwayLanding = "airportrunwaylanding.jpg";
        private string _airportRunwayTaxiing = "airportrunwaylandingtaxiing.jpg";
       public string AirportOverviewImage
        {
            get
            {
                return _airportOverview;
            }
        }
        public string AirportRunwayLandingImage
        {
            get
            {
                return _airportRunwayLanding;
            }
        }
        public string AirportRunwayTaxiingImage
        {
            get
            {
                return _airportRunwayTaxiing;
            }
        }

        public AirportPage ViewModel { get; internal set; }
    }
}
