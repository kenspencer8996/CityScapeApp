
using System;
using System.Runtime.Serialization;

namespace CityScapeApp.Controllers
{
    internal class CarPoliceContentViewController
    {
        private CarPoliceContent _view;
        BusinessContent _business;
        string _robberName;
        private List<StreetNavigationEntity> PathToRobery = new List<StreetNavigationEntity>();
        private LotEntity _robberyLot;
        bool runOne = false;
        bool firstrun = false;
        internal CarPoliceContentViewController(CarPoliceContent view)
        {
            _view = view;
            
        }

       

        internal async void PoliceCarStartMove(BusinessContent business, string robberName)
        {
            _robberyLot = business.Lot;
            _robberName = robberName;
            _movepolicecarx = Global.PoliceStationLot.x;
            //todo:setup switch for steet
            Global.WriteDebugOutput("PoliceCarStartMove robber " + _robberName);
            Global.WriteDebugOutput("PoliceCarStartMove " + "You next" + " x" + Global.YouStStreetloc.x + " y" + Global.YouStStreetloc.y);

            GetStreetPath();

             //double y = Global.YouStStreetloc.y + 100;
            double y = Global.YouStStreetloc.y;
            MoveCarYOnly(Global.PoliceStationLot.y,y, "Police Station",1);
            await _view.FadeTo(1, 500);
        }



        private void GetStreetPath()
        {
            switch (_robberyLot.StreetName)
            {
                case "Yodel Lane":
                    StreetNavigationEntity street = new StreetNavigationEntity();
                    double startx = 0;
                    double starty = 0;
                    double finalx = 0;
                    double finaly = 0;
                    startx = Global.PoliceStationLot.x;
                    starty = Global.YouStStreetloc.y;
                    finalx = Global.YodelLaneStreetLoc.x;
                    finaly = Global.YouStStreetloc.y;
                    street.AddTravelInfo("You St", finalx, finaly, StreetTraverseEnum.Traverse,
                         PositionsEWNSEnum.West, startx, starty,1);
                    PathToRobery.Add(street);

                    street = new StreetNavigationEntity();
                    street.AddTravelInfo("Yodel Lane", _robberyLot.x, _robberyLot.y,
                        StreetTraverseEnum.StopAtLot,
                         PositionsEWNSEnum.South,
                         Global.YodelLaneStreetLoc.x, Global.YouStStreetloc.y,2);
                    street.LotToTravelTo = _robberyLot;
                    PathToRobery.Add(street);
                    break;
                case "Mik Ave":
                    StreetNavigationEntity streetMik = new StreetNavigationEntity();
                    streetMik.AddTravelInfo("You St", Global.YodelLaneStreetLoc.x,
                        Global.YouStStreetloc.y, StreetTraverseEnum.Traverse,
                         PositionsEWNSEnum.West, Global.PoliceStationLot.x, 
                         Global.YouStStreetloc.y,1);
                    PathToRobery.Add(streetMik);
                    streetMik = new StreetNavigationEntity();
                    streetMik.AddTravelInfo("Yodel Lane", Global.YodelLaneStreetLoc.x,
                        Global.YodelLaneStreetLoc.y,
                        StreetTraverseEnum.Traverse, PositionsEWNSEnum.South,
                        Global.YodelLaneStreetLoc.x, Global.YouStStreetloc.y,2);
                    PathToRobery.Add(streetMik);
                    streetMik = new StreetNavigationEntity();
                    streetMik.AddTravelInfo("Mik Ave",
                        _robberyLot.x, _robberyLot.y,
                        StreetTraverseEnum.StopAtLot,
                         PositionsEWNSEnum.East,
                         Global.YodelLaneStreetLoc.x, Global.MikAveStreetLoc.y,3);
                    streetMik.LotToTravelTo = _robberyLot;
                    PathToRobery.Add(streetMik);
                    break;
                default:
                    break;
            }
        }

        private void MoveCarMaster(int index)
        {

            //linq here
             
            var path = from p in PathToRobery where p.Index == index select p;
            StreetNavigationEntity streetNavigationEntity = path.First();
            double x,y;
            double starty;
            double startx;
            x = streetNavigationEntity.StreetLocation.x;
            y = streetNavigationEntity.StreetLocation.y;
            starty = streetNavigationEntity.StartY;
            startx = streetNavigationEntity.StartX;
            string streetname = streetNavigationEntity.StreetName;
            index++;
            if (index > PathToRobery.Count())
                index = 0;
            switch (streetNavigationEntity.TravelDirection)
            {
                case PositionsEWNSEnum.North:
                    _view.ChangeDirection(PositionsEWNSEnum.North);                   _view.ChangeDirection(PositionsEWNSEnum.North);
                    MoveCarYOnly(starty, y, streetname, index);
                    break;
                case PositionsEWNSEnum.South:
                    _view.ChangeDirection(PositionsEWNSEnum.South);
                    MoveCarYOnly(starty, y, streetname, index);
                    break;
                case PositionsEWNSEnum.East:
                    MoveCarXOnly(startx, x,y, streetname, index);
                    _view.ChangeDirection(PositionsEWNSEnum.East);
                    break;
                case PositionsEWNSEnum.West:
                    _view.ChangeDirection(PositionsEWNSEnum.West);
                    MoveCarXOnly(startx, x, y, streetname, index);
                    break;
            }
       

        }
        private void MoveCarXOnly(double startx, double x, double y,
            string streetName, int index)
        {
            _movepolicecary = y;
            _currentStreetName = streetName;
            Animation MoveXAnimation1;
            System.Diagnostics.Debug.WriteLine("MoveCarXOnly "
                + " _movepolicecary street " + streetName + " _movepolicecary "
                + _movepolicecary + " x " + x);

            MoveXAnimation1 = new Animation(v => this.MovePoliceCarX = v,
                startx, x);
            uint animationTime = (uint)Global.PoliceCarSpeed * 1000;

            MoveXAnimation1.Commit(_view, "MoveXAnimations", 10, animationTime, null, (v, c) => MovePoliceCarLocXComplete(startx, x, y, index));

        }

        private void MovePoliceCarLocXComplete(double startx, double x,
            double y,int index)
        {
            Global.WriteDebugOutput("anuimation complete next: if index;");

            if (index > 0)
                MoveCarMaster(index);
        }

        private void MoveCarYOnly(double starty, double y, string streetName, int index)
        {
            //_movepolicecary = y;
            Animation MoveYAnimation1;
            _currentStreetName = streetName;
            //if (streetName.StartsWith("Yodel"))
            //{
            //    y = 500; 
            //    _movepolicecarx = 70;
            //}
            Global.WriteDebugOutput("MoveCarYOnly robber " + _view.RobberName 
                + " _movepolicecary street " + streetName + " starty " + starty
                + " _movepolicecary " + _movepolicecary + " y " + y +
                " _movepolicecarx " + _movepolicecarx + "  Opacity " + _view.Opacity);
            MoveYAnimation1 = new Animation(v => this.MovePoliceCarY = v,
               starty, y);

            //Animation MoveYAnimation2 = new Animation(v => this.MovePoliceCarY = v,
            //    starty, finaly);//, Easing.SpringIn
            uint animationTime = (uint)Global.PoliceCarSpeed * 1000;

            MoveYAnimation1.Commit(_view, "MoveYAnimations",
                10, animationTime, null, (v, c) => MovePoliceCarLocYComplete(index));
        }

        private void MovePoliceCarLocYComplete(int index)
        {
            Global.WriteDebugOutput("anuimation complete next: if movecarmaster;");

            if (index > 0)
                MoveCarMaster(index);
        }


      
        private void AnimationToStartPoliceCarLocComplete(double startx, double x, double y, int index)
        {
            Global.WriteDebugOutput("anuimation complete next: if movecarmaster;");

            //MoveCarXOnly
            MoveCarMaster(index);
        }

        private string StreetName { get; set; }
        private double _movepolicecarx;
        private double MovePoliceCarX
        {
            get
            { return _movepolicecarx; }
            set
            {
                _movepolicecarx = value;
                LocationXYEntity locationXY = new LocationXYEntity();
                locationXY.x = _movepolicecarx;
                locationXY.y = _movepolicecary;

                if (RunThis())
                    _view.FireMoveCarEvent(locationXY);
                firstrun = false;
            }
        }
        private string _currentStreetName = "";
        private double _movepolicecary;
        private double MovePoliceCarY
        {
            get
            { return _movepolicecary; }
            set
            {
                _movepolicecary = value;
                LocationXYEntity locationXY = new LocationXYEntity();
                locationXY.x = _movepolicecarx;
                locationXY.y = _movepolicecary;

                if (RunThis()) 
                    _view.FireMoveCarEvent(locationXY);

            }


        }
        private bool RunThis()
        {
            bool runthis = false;
            if (runOne == false) runthis = true;
            if (runthis == false)
            {
                if (runOne == true &&  firstrun == false)
                    runthis = true;
            }
            return runthis;
        }
    }
}