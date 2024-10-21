namespace CityScapeApp.Viewmodels
{
    public partial class CityscapeStreetsViewModel:BaseViewModel
    {
        private double _cityRoadWidth  = 100;
        private double _pageWidth;
        private double _pageHeight;
        private double _cityRoadHorizontalLength;
        private double _cityRoadFromEdge = 150;
        private double _highwayWidth  = 150;

        internal double CityRoadWidth 
        { 
            get
            {
                return _cityRoadWidth; 
            }
            set
            {
                 SetProprty(ref _cityRoadWidth, value);;
            }
        }
        internal double PageWidth
        {
            get
            {
                return _pageWidth;
            }
            set
            {
                SetProprty(ref _pageWidth, value);;
            }
        }
        internal double PageHeight
        {
            get
            {
                return _pageHeight;
            }
            set
            {
                 SetProprty(ref _pageHeight, value);;
            }
        }
     
        internal double CityRoadHorizontalLength
        {
            get
            {
                return _cityRoadHorizontalLength;
            }
            set
            {
                SetProprty(ref _cityRoadHorizontalLength, value);;
            }
        }
        internal double CityRoadFromEdge
       {
            get
            {
                return _cityRoadFromEdge;
            }
            set
            {
                SetProprty(ref _cityRoadFromEdge, value);;
           }
        }
        internal double HighwayWidth
       {
            get
            {
                return _highwayWidth;
            }
            set
            {
                SetProprty(ref _highwayWidth, value);;
            }
        }
        internal void HandleSizeChange(double width,double height)
        {
            _highwayWidth = 100;
            _pageWidth = width;
            _pageHeight = height;
            //take 20 off for corners
           // CityRoadHorizontalLength = width - (2 * _cityRoadFromEdge)-20 ;
        }
    }
}
