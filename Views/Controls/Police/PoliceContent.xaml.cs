namespace CityScapeApp.Views.Controls.Person;

public partial class PoliceContent : ContentView
{
    public event EventHandler<BadPersonMoveFiredEventArg> BadPersonMoveEvent;

    BadPersonEntity _person;
    IDispatcherTimer _showTimer;
    IDispatcherTimer _personMove1Timer;
    IDispatcherTimer _personMove2Timer;
    IDispatcherTimer _personMove3Timer;
    IDispatcherTimer _personMove4Timer;
    IDispatcherTimer _personMove5Timer;
    IDispatcherTimer _personMove6Timer;
    int _personNumber = 0;
    int _person1Seconds;
    int _person2Seconds;
    int _person3Seconds;
    int _person4Seconds;
    int _person5Seconds;
    int _person6Seconds;

    int _person1Iteration = 0;
    int _person2Iteration = 0;
    int _person3Iteration = 0;
    int _person4Iteration = 0;
    int _person5Iteration = 0;
    int _person6Iteration = 0;

    public PoliceContent()
    {
        InitializeComponent();

    }

    public void SetPerson(BadPersonEntity badperson, int personNumber)
    {
        _person = badperson;
        _personNumber = personNumber;
        PersonImage.Source = badperson.CurrentImage;
        BindingContext = badperson;
        badperson.ShowPersonTimerFired += Person_PersonTimerFired;
        StartTimers();
    }
    private void SetupTimerIntervals()
    {
        Random rand = new Random();
        //_person1Seconds = rand.Next(20); 
        //_person2Seconds= rand.Next(30);
        //_person3Seconds= rand.Next(25);
        //_person4Seconds= rand.Next(32);
        //_person5Seconds= rand.Next(42);
        //_person6Seconds= rand.Next(22);

        _person1Seconds =10;
        _person2Seconds = 14;
        _person3Seconds =25;
        _person4Seconds =32;
        _person5Seconds =42;
        _person6Seconds =22;
    }
    private void StartTimers()
    {
        SetupTimerIntervals();
        if (_personNumber == 1)
        {
            _personMove1Timer =Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
            _personMove1Timer.Interval = TimeSpan.FromSeconds(_person1Seconds);
            _personMove1Timer.Tick += (sender, e) => PersonMove_1_TimerFired();
        }

        if (_personNumber == 2)
        {
            _personMove2Timer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
            _personMove2Timer.Interval = TimeSpan.FromSeconds(_person2Seconds);
            _personMove2Timer.Tick += (sender, e) => PersonMove_2_TimerFired();
        }
        if (_personNumber == 3)
        {
            _personMove3Timer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
            _personMove3Timer.Interval = TimeSpan.FromSeconds(_person3Seconds);
            _personMove3Timer.Tick += (sender, e) => PersonMove_3_TimerFired();
        }
        if (_personNumber == 4)
        {
            _personMove4Timer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
            _personMove4Timer.Interval = TimeSpan.FromSeconds(_person4Seconds);
            _personMove4Timer.Tick += (sender, e) => PersonMove_4_TimerFired();
        }
        if (_personNumber == 5)
        {
            _personMove5Timer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
            _personMove5Timer.Interval = TimeSpan.FromSeconds(_person5Seconds);
            _personMove5Timer.Tick += (sender, e) => PersonMove_5_TimerFired();
        }
        if (_personNumber == 6)
        {
            _personMove6Timer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
            _personMove6Timer.Interval = TimeSpan.FromSeconds(_person6Seconds);
            _personMove6Timer.Tick += (sender, e) => PersonMove_6_TimerFired();
        }
        //if (_personNumber == 1)
        //    _personMove1Timer.Start();
        //if (_personNumber == 2)
        //    _personMove2Timer.Start();
        //if (_personNumber == 3)
        //    _personMove3Timer.Start();
        //if (_personNumber == 4)
        //    _personMove4Timer.Start();
        //if (_personNumber == 5)
        //    _personMove5Timer.Start();
        //if (_personNumber == 6)
        //    _personMove6Timer.Start();
    }

    private void PersonMove_6_TimerFired()
    {
        _personMove6Timer.Stop();
        switch (_person6Iteration)
        {
            case 0:
                MoveBadGuyToLocation( LocationEnum.Bush1Center,5);
                _personMove6Timer.Start();
                break;
            case 1:
                MoveBadGuyToLocation( LocationEnum.Bush2Center,5);
                _personMove6Timer.Start();
                break;
            case 2:
                MoveBadGuyToLocation( LocationEnum.ForestCenter, 15);
                break;
            default:
                break;

        }

        _person6Iteration++;
    }

    private void PersonMove_5_TimerFired()
    {
        _personMove5Timer.Stop();
        switch (_person5Iteration)
        {
            case 0:
                
                MoveBadGuyToLocation( LocationEnum.Bush2Center);
                _personMove5Timer.Start();
                break;
            case 1:
                MoveBadGuyToLocation( LocationEnum.Bush1Center);
                _personMove5Timer.Start();
                break;
            case 2:
                MoveBadGuyToLocation( LocationEnum.ForestCenter);
                break;
            default:
                break;

        }

        _person4Iteration++;
    }

    private void PersonMove_4_TimerFired()
    {
        _personMove4Timer.Stop();

        switch (_person4Iteration)
        {
            case 0:
                 MoveBadGuyToLocation( LocationEnum.ForestCenter);
                _personMove4Timer.Start();
                break;
            case 1:
                MoveBadGuyToLocation( LocationEnum.Bush1Center);
                _personMove4Timer.Start();
                break;
            case 2:
                MoveBadGuyToLocation( LocationEnum.Bush2Center);
                break;
            default:
                break;

        }

        _person4Iteration++;
    }

    private void PersonMove_3_TimerFired()
    {
        _personMove3Timer.Stop();
        switch (_person3Iteration)
        {
            case 0:
                MoveBadGuyToLocation( LocationEnum.ForestCenter);
                _personMove3Timer.Start();
            break;
        case 1:
            MoveBadGuyToLocation( LocationEnum.Bush1Center);
           _personMove3Timer.Start();
            break;
        case 2:
            MoveBadGuyToLocation( LocationEnum.Bush2Center);
            break;
        default:
            break;

               
        }

        _person3Iteration++;
    }

    private void PersonMove_2_TimerFired()
    {
        _personMove2Timer.Stop();
        switch (_person2Iteration)
        {
            case 0:
                 MoveBadGuyToLocation( LocationEnum.ForestCenter);
                _personMove2Timer.Start();
                break;
            case 1:
                MoveBadGuyToLocation( LocationEnum.Bush2Center);
                _personMove2Timer.Start();
                break;
            case 2:
                
                 MoveBadGuyToLocation( LocationEnum.Bush2Center);
                _personMove2Timer.Start();
                break;
            case 3:
                
                MoveBadGuyToLocation( LocationEnum.ForestCenter);
                _personMove2Timer.Start();
                break;

            case 4:
                MoveBadGuyToLocation( LocationEnum.Bush1Center);
                _personMove2Timer.Start();
                break;
            case 5:
                MoveBadGuyToLocation( LocationEnum.Bush2Center);
                _personMove2Timer.Start();
                break;
            case 6:
                MoveBadGuyToLocation( LocationEnum.Bush1Center);
                  _personMove2Timer.Start();
                break;
            case 7:
                MoveBadGuyToLocation( LocationEnum.BusinessCenter);
                 break;
            default:
                break;
        }

        _person2Iteration++;
    }

    private void PersonMove_1_TimerFired()
    {
        _personMove1Timer.Stop();
        switch (_person1Iteration)
        {
            case 0:         
                MoveBadGuyToLocation( LocationEnum.ForestCenter);
                _personMove1Timer.Start();
                break;
            case 1:
                
                 MoveBadGuyToLocation( LocationEnum.Bush1Center);
                _personMove1Timer.Start();
                break;
            case 2:
                
                MoveBadGuyToLocation( LocationEnum.Bush2Center);
                break;
            default:
                break;
        }

        _person1Iteration++;
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
            case LocationEnum.BusinessCenter:
                locationXY = GetBusinessCenterLocation();
                locationXY.x = locationXY.x + 20;
                locationXY.y = locationXY.y +- 20;
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
        PersonEntity person = new PersonEntity();
        PersonImageEntity personimage = new PersonImageEntity();
        int index;
         index = rand.Next(Global.Businesses.Count());
        BusinessContent bc = Global.Businesses.ElementAt(index);
        locationXY.x = bc.Lot.x;
        locationXY.y = bc.Lot.x;
        return locationXY;
    }

    private void Person_PersonTimerFired(object? sender, BadPersonTimerFiredEventArg e)
    {

          
    }
    private async void MoveBadGuyToLocation(LocationEnum location,
        int xOffset = 0, int yOffset = 0)
    {
        double x = 0;
        double y = 0;
        var layoutBoundsNewLoc = GetLocation(location);
        x = layoutBoundsNewLoc.x + xOffset;
        y = layoutBoundsNewLoc.y + yOffset;
        var layoutBounds = AbsoluteLayout.GetLayoutBounds(this);
        double xnow = layoutBounds.X;
        double ynow = layoutBounds.Y;
        //https://learn.microsoft.com/en-us/dotnet/maui/user-interface/animation/custom?view=net-maui-8.0
        var MoveBadGuyParentAnimation = new Animation();
        Animation MoveXAnimation = new Animation(v => this.MoveBadGuyX = v, xnow, x, null);
        Animation MoveYAnimation = new Animation(v => this.MoveBadGuyY = v, ynow, y, null);
        uint animationTime = (uint)Global.TravelSpeed * 1000;

        MoveBadGuyParentAnimation.Add(0, 1, MoveXAnimation);
        MoveBadGuyParentAnimation.Add(0, 1, MoveYAnimation);
        MoveBadGuyParentAnimation.Commit(this, "MoveAnimations", 16, animationTime, null, (v, c) => DummyFunc(true, false));
       await  this.FadeTo(1, 2000);
        
    }

    private Func<bool> DummyFunc(bool v1, bool v2)
    {
        var res = 1 == 2;
        return () => res;
    }

    private double _moveBadGuyX = 0;
    private double _moveBadGuyY = 0;
    private double MoveBadGuyX
    {
        set
        {
            _moveBadGuyX = value;
        }
    }
    private double MoveBadGuyY
    {
        set
        {
            _moveBadGuyY = value;
            BadPersonMoveFiredEventArg arg = new BadPersonMoveFiredEventArg(_moveBadGuyX, _moveBadGuyY);
            BadPersonMoveEvent(this,arg);
        }
    }
    private void OnDragStartingMyPerson(object sender, DragStartingEventArgs e)
    {
        HouseContent person = sender as HouseContent;
        e.Data.Properties.Add("Person", _person.BadPerson.Name);
    }


}