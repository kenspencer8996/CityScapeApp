using CommunityToolkit.Mvvm.Messaging;
//using UIKit;

namespace CityScapeApp.Views.Controls.Person;

public partial class BadPersonnContent : ContentView
{
    public event EventHandler<BadPersonMoveFiredEventArg> BadPersonMoveFrmTentEvent;
    public event EventHandler<BadPersonMoveFiredEventArg> BadPersonMoveEvent;
    public event EventHandler<BadPersonDroppedFiredEventArg> BadPersonDroppedEvent;
    private ObjectLocationPathEntity currentPath = new ObjectLocationPathEntity();
    private ObjectLocationPathEntity currentEscapePath = new ObjectLocationPathEntity();
    public BadPersonEntity BadPerson;
    IDispatcherTimer _showTimer;
    PathTypeEnum _pathType;
    IDispatcherTimer _badGuyMoveTimer;
    IDispatcherTimer _badGuyEscapeMoveTimer;
    int _personNumber = 0;
    int _iterationForPaths = 0;
    int _iterationForEscapePaths = 0;
    LocationEnum currentPathLocation = LocationEnum.None;
    bool _TimerFired = false;
    int _timerSeconds = 10;
    int _timerEscapeSeconds = 10;
    LocationEnum _lastMovePath = 0;
    private void ResetCounters()
    {
        _iterationForPaths = 0;
    }
    public BadPersonnContent()
    {
        InitializeComponent();
     
  
    }
    public int PersonNumber
    {
        get
        {
            return _personNumber;
        }
    }
    public string PersonImageSource
    {
        get
        {
            if (BadPerson != null)
                return BadPerson.CurrentImage;
            else
                return "";
        }
    }
    public void DroppeninPoliceStation()
    {
        BadPersonDroppedFiredEventArg args = new BadPersonDroppedFiredEventArg(_personNumber,BadPerson.PersonID);
        if (BadPersonDroppedEvent != null)
            BadPersonDroppedEvent(this, args);
    }
    public void SetPerson(BadPersonEntity badperson, int personNumber)
    {
        try
        {
            BadPerson = badperson;
            _personNumber = personNumber;
            badperson.Host = this;
            PersonImage.Source = badperson.CurrentImage;
            BindingContext = badperson;
            badperson.ShowPersonTimerFired += Person_PersonTimerFired;
            SetupandStartTimers();
            SetupEscapeTimerIntervals();
            _pathType = PathTypeEnum.Normal;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    private void SetupTimerIntervals()
    {
        try
        {
            Random rand = new Random();
            _timerSeconds = rand.Next(20);
            _timerEscapeSeconds = rand.Next(32);
            int pathsCount = Global.PathsList.Count;
            do
            {
                int pathtouse = rand.Next(pathsCount - 1);
                currentPath = Global.PathsList[pathtouse];
                int currentpathcount = currentPath.APath.Count;
                if (currentpathcount > 0)
                    _lastMovePath = currentPath.APath[currentpathcount - 1];

            } while (currentPath.APath.Count == 0);


            if (currentPath == null || currentPath.APath.Count == 0)
                Global.WriteDebugOutput("apath empty");
        }
        catch (Exception ex)
        {
                
            throw;
        }
        //the following for testing
        //_person1Seconds =10;
        ;
    }
    private void SetupEscapeTimerIntervals()
    {
        try
        {
            Random rand = new Random();
            _timerEscapeSeconds = rand.Next(32);

            int pathsEscapeCount = Global.EscapePathsList.Count;
            do
            {
                int pathEscapetouse = rand.Next(pathsEscapeCount - 1);
                currentEscapePath = Global.EscapePathsList[pathEscapetouse];
                int currentEscapepathcount = currentEscapePath.APath.Count;
                if (currentEscapepathcount > 0)
                    _lastMovePath = currentEscapePath.APath[currentEscapepathcount - 1];

            } while (currentEscapePath.APath.Count == 0);
        }
        catch (Exception  ex)
        {

            throw;
        }

    }
    public void Reset()
    {
        StopTimer();
        ResetCounters();
        ResetTimer();
    }
    private void SetupandStartTimers()
    {
        SetupTimerIntervals();
        ResetCounters();
        ResetTimer();
        _badGuyMoveTimer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
        _badGuyMoveTimer.Interval = TimeSpan.FromSeconds(_timerSeconds);
        _badGuyMoveTimer.Tick += (sender, e) => PersonMove_TimerFired();

        _badGuyEscapeMoveTimer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
        _badGuyEscapeMoveTimer.Interval = TimeSpan.FromSeconds(_timerSeconds);
        _badGuyEscapeMoveTimer.Tick += (sender, e) => PersonEsacpeMove_TimerFired();
        ResetTimer();
    }

    private void PersonEsacpeMove_TimerFired()
    {
        _badGuyEscapeMoveTimer?.Stop();
        MoveBadHuyOnEscapePath();
        _iterationForEscapePaths++;
    }

    public void ResetTimer()
    {
        if (_badGuyMoveTimer != null)
        {
            Global.WriteDebugOutput("ResetTimer");
            _badGuyEscapeMoveTimer.Stop();
            if (_showTimer != null && _badGuyMoveTimer != null)
            { 
                _showTimer.Stop();
                _badGuyMoveTimer.Start();
            }
        }
    }
    public void StopTimer()
    {
        if (_badGuyMoveTimer != null) 
            _badGuyMoveTimer.Stop();
        
    }
    public void ResetEscapeTimer()
    {
        if (_badGuyEscapeMoveTimer != null)
        {
            _badGuyEscapeMoveTimer.Start();
        }
    }
    public void StopEscapeTimer()
    {
        if (_badGuyEscapeMoveTimer != null)
            _badGuyEscapeMoveTimer.Stop();

    }
    private void PersonMove_TimerFired()
    {
        _badGuyMoveTimer.Stop();
        if (_TimerFired == false)
        {
            BadPersonMoveFrmTentEvent(this, new BadPersonMoveFiredEventArg(0, 0));
            _TimerFired = true;
        }
    }
    public void MoveBadGuy()
    {
        if (_iterationForPaths >= currentPath.APath.Count)
            _iterationForPaths = 0;

        //debug this
        Global.WriteDebugOutput("_iterationForPaths " + _iterationForPaths);
        currentPathLocation = currentPath.APath[_iterationForPaths];
        _iterationForPaths++;

        switch (currentPathLocation)
        {
            case LocationEnum.ForestCenter:
                SetImage(PersonImageStatusEnum.Normal);
                MoveBadGuyToLocation(LocationEnum.ForestCenter, 0,-10);
                break;
            case LocationEnum.Bush1Center:
                SetImage(PersonImageStatusEnum.ArmsOut);
                MoveBadGuyToLocation(LocationEnum.Bush1Center, -10);
                break;
             case LocationEnum.Bush2Center:
                SetImage(PersonImageStatusEnum.Smirk);
                MoveBadGuyToLocation(LocationEnum.Bush2Center);
                break;
            case LocationEnum.Shed1:
                SetImage(PersonImageStatusEnum.Airguitar);
                MoveBadGuyToLocation(LocationEnum.Shed1, -10);
                break;
            case LocationEnum.Barn1:
                SetImage(PersonImageStatusEnum.ArmsUp);
                MoveBadGuyToLocation(LocationEnum.Barn1);
                break;
            case LocationEnum.Tent:
                SetImage(PersonImageStatusEnum.Smirk);
                MoveBadGuyToLocation(LocationEnum.Tent);
                break;
            case LocationEnum.CampFire:
                SetImage(PersonImageStatusEnum.Smirk);
                MoveBadGuyToLocation(LocationEnum.CampFire);
                break;
            case LocationEnum.BusinessCenter:
                var layoutBoundsNewLoc = GetLocation(LocationEnum.BusinessCenter);

                MoveBadGuyToBusinessLocation(layoutBoundsNewLoc) ;
                break;

            default:
                break;
        }

    }
    private void MoveBadHuyOnEscapePath()
    {
        if (_iterationForEscapePaths >= currentPath.APath.Count)
            _iterationForEscapePaths = 0;
         var thisLoc = currentPath.APath[_iterationForEscapePaths];
        switch (thisLoc)
        {
            case LocationEnum.ForestCenter:
                SetImage(PersonImageStatusEnum.Gun);

                MoveBadGuyToLocation(LocationEnum.ForestCenter);
                break;
            case LocationEnum.Bush1Center:
                SetImage(PersonImageStatusEnum.Gun);
                MoveBadGuyToLocation(LocationEnum.Bush1Center);
                break;
            case LocationEnum.Bush2Center:
                SetImage(PersonImageStatusEnum.CashGun);

                MoveBadGuyToLocation(LocationEnum.Bush2Center);
                break;
            case LocationEnum.Shed1:
                SetImage(PersonImageStatusEnum.Money);
                MoveBadGuyToLocation(LocationEnum.Shed1);
                break;

            case LocationEnum.Barn1:
                SetImage(PersonImageStatusEnum.Drinking);
                MoveBadGuyToLocation(LocationEnum.Barn1);
                break;
            case LocationEnum.CampFire:
                SetImage(PersonImageStatusEnum.Drinking);
                MoveBadGuyToLocation(LocationEnum.CampFire);
                break;
            case LocationEnum.Tent:
                SetImage(PersonImageStatusEnum.Drinking);
                MoveBadGuyToLocation(LocationEnum.Tent);
                break;
            case LocationEnum.BusinessCenter:
                SetImage(PersonImageStatusEnum.CashPiles);
                MoveBadGuyToLocation(LocationEnum.BusinessCenter);
                break;

            default:
                break;
        }

    }
    private LocationXYEntity GetLocation(LocationEnum locationType)
    {
        LocationXYEntity locationXY = new LocationXYEntity();
        switch (locationType)
        {
            case LocationEnum.ForestCenter:
                locationXY.x = Global.cityforest1x;
                locationXY.y = Global.cityforest1yCenter;
                break;
            case LocationEnum.Bush1Center:
                locationXY.x = Global.citybush1xCenter;
                locationXY.y = Global.citybush1yCenter;
                break;
            case LocationEnum.Bush2Center:
                locationXY.x = Global.citybush2xCenter;
                locationXY.y = Global.citybush2yCenter;
                break;
            case LocationEnum.Shed1:
                locationXY.x = Global.cityshed1x;
                locationXY.y = Global.cityshed1y;
                break;
            case LocationEnum.Barn1:
                locationXY.x = Global.citybarn1x;
                locationXY.y = Global.citybarn1y;
                break;
            case LocationEnum.BusinessCenter:
                locationXY = GetBusinessCenterLocation();
                locationXY.x +=20;
                //locationXY.y = locationXY.y ;
                break;
            case LocationEnum.Tent:
                locationXY.x = Global.citytentx;
                locationXY.y += Global.citytenty;
                //locationXY.y = locationXY.y ;
                break;

            default:
                break;
        }

        return locationXY;
    }

    private LocationXYEntity GetBusinessCenterLocation()
    {
        LocationXYEntity locationXY = new LocationXYEntity();
        Random rand = new Random();
              
        var financebus = from f in Global.Businesses
                         where
                         f.BusinesName.Contains("Bank") | f.BusinesName.Contains("Fin.")
                         select f;
        if (financebus.Any())
        { 
            int index;
            index = rand.Next(financebus.Count() - 1);
            BusinessContent bc = financebus.ElementAt(index);
            locationXY.x = bc.Lot.x;
            locationXY.y = bc.Lot.y;
        }
        return locationXY;
    }

    private void Person_PersonTimerFired(object? sender, BadPersonTimerFiredEventArg e)
    {

          
    }
    private async void MoveBadGuyToLocation(LocationEnum location, 
        int xOffset = 0, int yOffset = 0)
    {
        try
        {
            double x = 0;
            double y = 0;
            var layoutBoundsNewLoc = GetLocation(location);
            x = layoutBoundsNewLoc.x + xOffset;
            y = layoutBoundsNewLoc.y + yOffset;
            var layoutBounds = AbsoluteLayout.GetLayoutBounds(this);
            double xnow = layoutBounds.X;
            double ynow = layoutBounds.Y;
            if (x < 100)
            {
                string val = "1";
            }
             uint animationTime = (uint)Global.TravelSpeed * 1000;
            string info = "location" +
                location + " animationTime: " + animationTime + " xnow:" + xnow + " ynow " + ynow + " x " + x + " y " + y;
            Global.WriteDebugOutput(info);
            double xout = 0;
            bool onlyYNeg = true;

            //https://learn.microsoft.com/en-us/dotnet/maui/user-interface/animation/custom?view=net-maui-8.0
            var MoveBadGuyParentAnimation = new Animation();
            Animation MoveXAnimation = new Animation(v => xout = v, xnow, x, null);
            Animation MoveYAnimation = new Animation(v => MoveBadGuyFromAnimation(xout, v, info, onlyYNeg), ynow, y, null);


            MoveBadGuyParentAnimation.Add(0, 1, MoveXAnimation);
            MoveBadGuyParentAnimation.Add(0, 1, MoveYAnimation);
            MoveBadGuyParentAnimation.Commit(this, "MoveAnimations", 16, animationTime, null, (v, c) => AnimationComplete(location));
            //await this.FadeTo(1, 2000);
        }
        catch (Exception ex)
        {

            throw;
        }
      }
    private async void MoveBadGuyToBusinessLocationHalfWay(int currentlocationnumber,
        int xOffset = 0, int yOffset = 0)
    {
        double finalx = 0;
        double finaly = 0;

        LocationXYEntity layoutBoundsNewLoc = GetLocation(LocationEnum.BusinessCenter);
        finalx = layoutBoundsNewLoc.x + xOffset;
        finaly = layoutBoundsNewLoc.y + yOffset;
        var layoutBounds = AbsoluteLayout.GetLayoutBounds(this);
        double xnow = layoutBounds.X;
        double ynow = layoutBounds.Y;
        double halfx = xnow - finalx;
        double halfy = ynow - finaly;
        double x = 0;
        string info = "MoveBadGuyToBusinessLocationHalf currentlocationnumber" +
               currentlocationnumber + " xnow" + xnow +
               "  ynow " + ynow + " halfx " + halfx + " halfy " + halfy;
        bool onlyYNeg = false;

        var MoveBadGuyParentAnimationHalfway = new Animation();
        double xout = 0;
        Animation MoveXAnimationhalf = new Animation(v => xout = v, xnow, halfx, null);
        Animation MoveYAnimationhalf = new Animation(v => MoveBadGuyFromAnimation(xout,v,"",true));
        uint animationTime = (uint)Global.TravelSpeed * 1000;

        MoveBadGuyParentAnimationHalfway.Add(0, 1, MoveXAnimationhalf);
        MoveBadGuyParentAnimationHalfway.Add(0, 1, MoveYAnimationhalf);
        MoveBadGuyParentAnimationHalfway.Commit(this, "MoveAnimationsHalf", 16, animationTime, null, (v, c) => AnimationCompleteMoveBadGuyToBusinessLocationHalfWay(layoutBoundsNewLoc));

    }
    private void AnimationCompleteMoveBadGuyToBusinessLocationHalfWay(LocationXYEntity layoutBoundsNewLoc)
    {
        Global.WriteDebugOutput("anuimation complete next: MoveBadGuyToBusinessLocation;");


        MoveBadGuyToBusinessLocation(layoutBoundsNewLoc);
    }

    private async void MoveBadGuyToBusinessLocation(LocationXYEntity layoutBoundsNewLoc)
    {

        try
        {
            string info = "MoveBadGuyToBusinessLocation layoutBoundsNewLoc x" +
           layoutBoundsNewLoc.x + " y " + layoutBoundsNewLoc.y;
            SetImage(PersonImageStatusEnum.Gun);
            //https://learn.microsoft.com/en-us/dotnet/maui/user-interface/animation/custom?view=net-maui-8.0
            double x = 0;
            var MoveBadGuyParentAnimation = new Animation();
            Animation MoveXAnimation = new Animation(v => x = v,
                layoutBoundsNewLoc.x, layoutBoundsNewLoc.y, null);
            Animation MoveYAnimation = new Animation(v => MoveBadGuyFromAnimation(x, v, info, false));
            uint animationTime = (uint)Global.TravelSpeed * 1000;

            MoveBadGuyParentAnimation.Add(0, 1, MoveXAnimation);
            MoveBadGuyParentAnimation.Add(0, 1, MoveYAnimation);
            MoveBadGuyParentAnimation.Commit(this, "MoveAnimations", 16, animationTime, null, (v, c) =>
                AnimationCompleteBusiness(false));
            await this.FadeTo(1, 2000);
        }
        catch (Exception ex)
        {

            throw;
        }

    }
    private void SendMessageOnArrival()
    {
        WeakReferenceMessenger.Default.Send(new PersonMessage(BadPerson.PersonName));
    }

    private Func<bool> AnimationComplete( LocationEnum location)
    {
        Global.WriteDebugOutput("anuimation complete next: _badGuyMoveTimer.Start(); ");

        _badGuyMoveTimer.Start();
        var res = 1 == 2;
        return () => res;
    }
    private Func<bool> AnimationCompleteBusiness( bool halfway)
    {
        Global.WriteDebugOutput("anuimation complete next: if halfway;");

        if ( halfway == false)
        {
            
             //change image 
             SendMessageOnArrival();

            _pathType = PathTypeEnum.Esape;

            _badGuyEscapeMoveTimer.Start();
        }
        var res = 1 == 2;
        return () => res;
    }
    //private double _moveBadGuyX = 0;
    //private double _moveBadGuyY = 0;
    //private double MoveBadGuyX
    //{
    //    set
    //    {
    //        _moveBadGuyX = value;
    //    }
    //}
    //private double MoveBadGuyY
    //{
    //    set
    //    {
    //        if (_moveBadGuyY < 1)
    //        {
    //            Global.WriteDebutOutput("MoveBadGuyY x "
    //                + _moveBadGuyX + "  y " + _moveBadGuyY);
    //        }
    //        _moveBadGuyY = value;
    //        BadPersonMoveFiredEventArg arg = new BadPersonMoveFiredEventArg(_moveBadGuyX, _moveBadGuyY);
    //        if (BadPersonMoveEvent != null)
    //            BadPersonMoveEvent(this,arg);
    //    }
    //}
    private void MoveBadGuyFromAnimation(double x,double y,string info,bool onlyYNeg)
    {
        try
        {
            bool outputMessage = true;
            info = "x:" + x + "," + "," + y + " -- " + info;
            if (onlyYNeg)
            {
                if (y < -1)
                    outputMessage = true;
                else
                    outputMessage = false;
            }
            if (info != null && info != "" && outputMessage)
            {
                Global.WriteDebugOutput("Info " + info);

            }
            BadPersonMoveFiredEventArg arg = new BadPersonMoveFiredEventArg(x, y);
            if (BadPersonMoveEvent != null)
            {
                BadPersonMoveEvent(this, arg);
            }

        }
        catch (Exception ex)
        {

            throw;
        }    
    }
    private void OnDragStartingMyPerson(object sender, DragStartingEventArgs e)
    {
        
         e.Data.Properties.Add("BadPerson", BadPerson.PersonID);
    }
    private void SetImage(PersonImageStatusEnum status)
    {
        var foundImages = from i in BadPerson.Images
                          where i.PersonImageStatus == status
                          select i;
        if (foundImages?.Any() == true )
        {
            PersonImage.Source = foundImages.First().FilePath;
        }

    }

    internal void StartMainAnimation()
    {
        var found = from d in Global.CampfireSpots
                    where d.RobberName == BadPerson.PersonName
                    select d;
        if (found == null && found.Any())
            found.First().RobberName = "";
        MoveBadGuy();
    }
}