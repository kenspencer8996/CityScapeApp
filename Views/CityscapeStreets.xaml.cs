using CityScapeApp.Controllers;
using CityScapeApp.Views.Controls.Police;
using System.Collections.Immutable;

namespace CityScapeApp.Views;

public partial class CityscapeStreets : ContentPage
{
    CityscapeStreetsController _controller;
    int badcount = 0;
    int tentx = 550;
    int tenty = 230;
    Microsoft.Maui.Controls.Image tentImage = new Microsoft.Maui.Controls.Image();
    string  _toolbarsetting = string.Empty;
    public CityscapeStreets()
    {
        InitializeComponent();
        _controller = new CityscapeStreetsController(this);
        string ApplicationPath = Microsoft.Maui.Storage.FileSystem.Current.AppDataDirectory;
        Global.Burglaralarmfile = System.IO.Path.Combine(ApplicationPath, "Resources", "Raw", Global.Burglaralarmfile);
        if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
            Console.WriteLine("The current device is a desktop");
        else if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
            Console.WriteLine("The current device is a phone");
        else if (DeviceInfo.Current.Idiom == DeviceIdiom.Tablet)
            Console.WriteLine("The current device is a Tablet");
        ToolbarSelector.Source = "arrowright.png";
        _toolbarsetting = "normal";
        SetupBadGuyEvents();
        AddTent();
        CalculateBadguyTranslations();
        SetGlobalPositionwFromImages();
    }

    private void SetGlobalPositionwFromImages()
    {
        if (Global.cityforest1x == 0)
        {
            var forest1Bounds = AbsoluteLayout.GetLayoutBounds(Forest1);
            Global.cityforest1x = Convert.ToInt32(forest1Bounds.X);
            Global.cityforest1y = Convert.ToInt32(forest1Bounds.Y);

            var bush1Bounds = AbsoluteLayout.GetLayoutBounds(Bush1);
            Global.citybush1x = Convert.ToInt32(bush1Bounds.X);
            Global.citybush1y = Convert.ToInt32(bush1Bounds.Y);

            var bush2Bounds = AbsoluteLayout.GetLayoutBounds(Bush2);
            Global.citybush2x = Convert.ToInt32(bush2Bounds.X);
            Global.citybush2y = Convert.ToInt32(bush2Bounds.Y);

            var tentBounds = AbsoluteLayout.GetLayoutBounds(tentImage);
            Global.citytentx = Convert.ToInt32(tentBounds.X);
            Global.citytenty = Convert.ToInt32(tentBounds.Y);

            var barnBounds = AbsoluteLayout.GetLayoutBounds(Barn1);
            Global.citybarn1x = Convert.ToInt32(barnBounds.X);
            Global.citybarn1y = Convert.ToInt32(barnBounds.Y);

            var shed1Bounds = AbsoluteLayout.GetLayoutBounds(Shed1);
            Global.cityshed1x = Convert.ToInt32(shed1Bounds.X);
            Global.cityshed1y = Convert.ToInt32(shed1Bounds.Y);

            var campfireBounds = AbsoluteLayout.GetLayoutBounds(CampfireImage);
            Global.CampfireLocation = new LocationXYEntity();
            Global.CampfireLocation.x = campfireBounds.Location.X;
            Global.CampfireLocation.y = campfireBounds.Location.Y;
            SetupCampfireUseLocations();
            var result = Global.GetImageInfo(Forest1);
            Global.cityforestWidth = result.width;
            Global.cityforestHeight = result.height;

            result = Global.GetImageInfo(Bush1);
            Global.citybush1Width = result.width;
            Global.citybush1Height = result.height;

            result = Global.GetImageInfo(Bush2);
            Global.citybush2Width = result.width;
            Global.citybush2Height = result.height;

            result = Global.GetImageInfo(Barn1);
            Global.citybarn1Width = result.width;
            Global.citybarn1Height = result.height;

            result = Global.GetImageInfo(Shed1);
            Global.cityshed1Width = result.width;
            Global.cityshed1Height = result.height;
        }
    }

    private void SetupCampfireUseLocations()
    {
        int distfromcampfire = 20;
        double x1 = Global.CampfireLocation.x + 10; //0
        double y1 = Global.CampfireLocation.y - 10;
        CampfireLocationEntity campfireLocation1 = new CampfireLocationEntity();
        campfireLocation1.Location.x = x1;
        campfireLocation1.Location.y = y1;
        campfireLocation1.Degrees = 0;
        Global.CampFireApproachN.x = x1;
        Global.CampFireApproachN.y = y1 - (distfromcampfire + 10);
        Global.CampfireSpots.Add(campfireLocation1);

        CampfireLocationEntity campfireLocation2 = new CampfireLocationEntity();
        double x2 = Global.CampfireLocation.x + distfromcampfire; //90
        double y2 = Global.CampfireLocation.y;
        campfireLocation2.Degrees = 90;
        campfireLocation2.Location.x = x2;
        campfireLocation2.Location.y = y2;
        Global.CampfireSpots.Add(campfireLocation2);

        Global.CampFireApproachE.x = x2 + 10;
        Global.CampFireApproachE.y = Global.CampfireLocation.y;
        Global.CampFireApproachW.x = Global.CampfireLocation.x - (distfromcampfire);
        Global.CampFireApproachW.y = Global.CampfireLocation.y;

        double x3 = Global.CampfireLocation.x + distfromcampfire; //180
        double y3 = Global.CampfireLocation.y + 60;
        CampfireLocationEntity campfireLocation3 = new CampfireLocationEntity();
        campfireLocation3.Location.x = x3;
        campfireLocation3.Location.y = y3;
        campfireLocation3.Degrees = 180;
        Global.CampFireApproachNE.x = x3 + distfromcampfire;
        Global.CampFireApproachNE.y = y3 - distfromcampfire;

        Global.CampFireApproachSE.x = x3 + distfromcampfire;
        Global.CampFireApproachSE.y = y3 - distfromcampfire;
        Global.CampFireApproachSW.x = x3 - distfromcampfire;
        Global.CampFireApproachSW.y = y3 - distfromcampfire;

        Global.CampFireApproachS.x = Global.CampfireLocation.x;
        Global.CampFireApproachS.y = Global.CampfireLocation.y + 75;

        Global.CampFireApproachN.x = Global.CampfireLocation.x;
        Global.CampFireApproachN.y = Global.CampfireLocation.y - 75;


        Global.CampFireApproachE.x = x3;
        Global.CampFireApproachE.y = y3;

        Global.CampfireSpots.Add(campfireLocation3);

        double x4 = Global.CampfireLocation.x - distfromcampfire; //270
        double y4 = Global.CampfireLocation.y + distfromcampfire;
        CampfireLocationEntity campfireLocation4 = new CampfireLocationEntity();
        campfireLocation4.Location.x = x4;
        campfireLocation4.Location.y = y4;
        campfireLocation4.Degrees = 270;
        Global.CampFireApproachNW.x = x4 - distfromcampfire;
        Global.CampFireApproachNW.y = y4 - distfromcampfire;
        Global.CampfireSpots.Add(campfireLocation1);
        if (Global.OutputDebugging)
        {
            Global.WriteDebugOutput(" CampFireApproachNW x" + Global.CampFireApproachNW.x + " y " + Global.CampFireApproachNW.y);
            Global.WriteDebugOutput(" CampFireApproachNE x" + Global.CampFireApproachNE.x + " y " + Global.CampFireApproachNE.y);
            Global.WriteDebugOutput(" CampFireApproachN x" + Global.CampFireApproachN.x + " y " + Global.CampFireApproachN.y);
            Global.WriteDebugOutput(" CampFireApproachE x" + Global.CampFireApproachE.x + " y " + Global.CampFireApproachE.y);

            Global.WriteDebugOutput(" CampFireApproachSE x" + Global.CampFireApproachSE.x + " y " + Global.CampFireApproachSE.y);
            Global.WriteDebugOutput(" CampFireApproachSW x" + Global.CampFireApproachSW.x + " y " + Global.CampFireApproachSW.y);
            Global.WriteDebugOutput(" CampFireApproachS x" + Global.CampFireApproachS.x + " y " + Global.CampFireApproachS.y);
            Global.WriteDebugOutput(" CampFireApproachW x" + Global.CampFireApproachW.x + " y " + Global.CampFireApproachW.y);

            foreach (var item in Global.CampfireSpots)
            {
                string msg = "Campfirespot x " + item.Location.x + ", " + item.Location.y;
                Global.WriteDebugOutput(msg);
            }
        }
    }

    private void SetupBadGuyEvents()
    {
        BadGuy1.BadPersonMoveEvent += BadGuy1_BadPersonMoveEvent;
        BadGuy2.BadPersonMoveEvent += BadGuy2_BadPersonMoveEvent;
        BadGuy3.BadPersonMoveEvent += BadGuy3_BadPersonMoveEvent;
        BadGuy4.BadPersonMoveEvent += BadGuy4_BadPersonMoveEvent;
        BadGuy5.BadPersonMoveEvent += BadGuy5_BadPersonMoveEvent;
        BadGuy6.BadPersonMoveEvent += BadGuy6_BadPersonMoveEvent;
        BadGuy1.BadPersonMoveFrmTentEvent += BadGuy_MoveFromTentEvent;
        BadGuy2.BadPersonMoveFrmTentEvent += BadGuy_MoveFromTentEvent; ;
        BadGuy3.BadPersonMoveFrmTentEvent += BadGuy_MoveFromTentEvent;
        BadGuy4.BadPersonMoveFrmTentEvent += BadGuy_MoveFromTentEvent;
    }

    private void BadGuy_MoveFromTentEvent(object? sender, BadPersonMoveFiredEventArg e)
    {
        try
        {
            Global.WriteDebugOutput("tent x " + Global.citytentx + " y " + Global.citytenty);
            Global.WriteDebugOutput("campfire x " + Global.CampfireLocation.x + " y " + Global.CampfireLocation.y);
            BadGuy_MoveFromTent(sender, e);

        }
        catch (Exception ex)
        {

            throw;
        }    }

    private void BadGuy_MoveFromTent(object? sender, BadPersonMoveFiredEventArg e)
    {
        BadPersonnContent badguy = (BadPersonnContent)sender;
        Rect current = new Rect();
        try
        {
            badguy.RotateTo(90, 500);
            badguy.TranslateTo(20, 10, 500);
            Thread.Sleep(1000);
            badguy.RotateTo(0, 500);
            Global.WriteDebugOutput("out of tent and standing");
            int GotoCampfire = new Random().Next(13300);
            if (int.IsEvenInteger(GotoCampfire))
            {
                //BadGuy1.TranslateTo(0, 20, 1000);
                var badguyloc = AbsoluteLayout.GetLayoutBounds(badguy);
                BadGuyWithPositionEntity badGuyWithPosition = new BadGuyWithPositionEntity();
                badGuyWithPosition.BadPerson = badguy;
                badGuyWithPosition.CampfireLocation = GetCanmpFireLocation(badguy.BadPerson.PersonName);
                if (badGuyWithPosition.CampfireLocation != null)
                {
                    badGuyWithPosition.CampFirePath = GetbadGuyCampfireList(badGuyWithPosition.CampfireLocation);
                    badGuyWithPosition.lastlocationXY.x = badguyloc.X;
                    badGuyWithPosition.lastlocationXY.y = badguyloc.Y;
                    badGuyWithPosition.BadPerson = badguy;
                    Global.WriteDebugOutput("ready to move to campfire" + " lastx " + badguyloc.X + " lasty " + badguyloc.Y);

                    MoveBadGuyToCampfire(badGuyWithPosition);

                }
                else
                {
                    Global.WriteDebugOutput("Not going to campfire 1");
                    badguy.StartMainAnimation();
                }
            }
            else
            {
                Global.WriteDebugOutput("Not going to campfire 2");

                badguy.StartMainAnimation();
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private List<int> GetbadGuyCampfireList(CampfireLocationEntity campFireLoc)
    {
        List<int> newList = new List<int>();
        switch(campFireLoc.Degrees)
        {
            case 0:
                newList.Add(0);
                break;
            case 90:
                newList.Add(0);
                newList.Add(1);
                break;
            case 180:
                newList.Add(0);
                newList.Add(1);
                newList.Add(2);
                newList.Add(3);

                break;
            case 270:
                newList.Add(0);
                newList.Add(1);
                break;
        }
        return newList;
    }

    private void MoveBadGuyToCampfire(BadGuyWithPositionEntity badGuyWithPosition)
    {
        int travelIndex = -1;
        try
        {
            if (badGuyWithPosition.CampFirePath.Count() > 0)
            {
                travelIndex = badGuyWithPosition.CampFirePath[0];
                if (badGuyWithPosition.CampFirePath.Count() == 1)
                    badGuyWithPosition.CampFirePath = new List<int>();
                else
                    badGuyWithPosition.CampFirePath.RemoveAt(0);
            }
            CampfireLocationEntity campFire = Global.CampfireSpots[travelIndex];
            double x = 0;
            double y = 0;
            Global.WriteDebugOutput(" travelIndex:" + travelIndex);

            switch (travelIndex)
            {
                case 0:
                    x = Global.CampFireApproachN.x;
                    y = Global.CampFireApproachN.y;
                    Global.WriteDebugOutput(" idx 0 x:" + x + " y: " + y);

                    MoveBadGuyToCampfireApproach(badGuyWithPosition,
                         badGuyWithPosition.lastlocationXY.x, badGuyWithPosition.lastlocationXY.y,
                        x, y, campFire.Location.x, campFire.Location.y);
                    break;
                case 1:
                    x = Global.CampFireApproachE.x;
                    y = Global.CampFireApproachE.y;
                    Global.WriteDebugOutput(" idx 1 x:" + x + " y: " + y);

                    MoveBadGuyToCampfireApproach(badGuyWithPosition,
                        badGuyWithPosition.lastlocationXY.x, badGuyWithPosition.lastlocationXY.y,
                        x, y, campFire.Location.x, campFire.Location.y);
                    break;
                case 2:
                    x = Global.CampFireApproachS.x;
                    y = Global.CampFireApproachS.y;
                    Global.WriteDebugOutput(" idx 2 x:" + x + " y: " + y);

                    MoveBadGuyToCampfireApproach(badGuyWithPosition,
                        badGuyWithPosition.lastlocationXY.x, badGuyWithPosition.lastlocationXY.y,
                        x, y, campFire.Location.x, campFire.Location.y);
                    break;
                case 3:
                    x = Global.CampFireApproachW.x;
                    y = Global.CampFireApproachW.y;

                    Global.WriteDebugOutput(" idx 3 x:" + x + " y: " + y);
                    MoveBadGuyToCampfireApproach(badGuyWithPosition,
                        badGuyWithPosition.lastlocationXY.x, badGuyWithPosition.lastlocationXY.y,
                        x, y, campFire.Location.x, campFire.Location.y);
                    break;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    private void MoveCarXOnly(double startx, double x, double y,
            BadPersonnContent badguy, int index)
    {
        try
        {
            Global.WriteDebugOutput(" startx " + startx + " x " + x + " y " + y + " badguyname " + badguy.BadPerson.PersonName);
            Animation MoveXAnimation1;

            MoveXAnimation1 = new Animation(v => MoveBadGuy(badguy, v, y),
                startx, x);
            uint animationTime = (uint)Global.PoliceCarSpeed * 1000;

            MoveXAnimation1.Commit(badguy, "MoveXAnimations", 10, animationTime, null, (v, c) => MoveBadGuyLocXComplete(startx, x, y, index));

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private void MoveBadGuyLocXComplete(double startx, double x,
        double y, int index)
    {
        Global.WriteDebugOutput("anuimation complete");
    }

  

    private void MoveBadGuy(BadPersonnContent badguy,double x, double v)
    {
        Rect rect = new Rect();
        rect.X = x;
        rect.Y = v;
        AbsoluteLayout.SetLayoutBounds(badguy, rect);
    }

  
    public void MoveBadGuyToCampfireApproach(
        BadGuyWithPositionEntity badGuyWithPosition,
        double startx,double starty, double x,double y,
        double campfirex, double campfirey)
    {
        try
        {
            var MoveBadGuy = new Animation();
            double changingx = 0;
            Animation MoveXAnimation1;
            Global.WriteDebugOutput("x " + x + " y " + y);
            MoveXAnimation1 = new Animation(v => changingx = v,
                startx, x);//, Easing.SpringIn

            Animation MoveYAnimation2 = new Animation(v => this.MoveBadGuy(badGuyWithPosition.BadPerson, changingx, v),
                starty, y);//, Easing.SpringIn
            uint animationTime = (uint)Global.CampFire * 1000;

            MoveBadGuy.Add(0, 1, MoveXAnimation1);
            MoveBadGuy.Add(0, 1, MoveYAnimation2);
            MoveBadGuy.Commit(badGuyWithPosition.BadPerson, "MoveAnimations", 16, animationTime, null,
                (v, c) => MoveBadGuyToCampfire(badGuyWithPosition, x, y, campfirex, campfirey));

        }
        catch (Exception ex)
        {

            throw;
        }    
    }
    private void MoveBadGuyToCampfire(BadGuyWithPositionEntity badGuyWithPosition,
        double startx, double starty, double x, double y)
    {
        try
        {
            var MoveBadGuy = new Animation();
            double changingx = 0;
            Animation MoveXAnimation1;
            uint animationTime = (uint)Global.CampFire * 1000;
            Global.WriteDebugOutput("animationTime " + animationTime + " x " + x + " y " + y);
            MoveXAnimation1 = new Animation(v => changingx = v, startx, x);//, Easing.SpringIn

            Animation MoveYAnimation2 = new Animation(v => this.MoveBadGuy(badGuyWithPosition.BadPerson, changingx, v),
                starty, y);//, Easing.SpringIn

            MoveBadGuy.Add(0, 1, MoveXAnimation1);
            MoveBadGuy.Add(0, 1, MoveYAnimation2);
            MoveBadGuy.Commit(badGuyWithPosition.BadPerson, "MoveAnimations", 16, animationTime, null,
                (v, c) =>
                {
                    int sleeptime = Global.CampFireSleepTime;
                    if (sleeptime <= 0) {
                        sleeptime = 5;
                    }
                    sleeptime = sleeptime * 1000;
                    Thread.Sleep(sleeptime);
                    badGuyWithPosition.CampfireLocation.RobberName = "";
                    badGuyWithPosition.BadPerson.StartMainAnimation();
                });
        }
        catch (Exception ex)
        {

            throw;
        }
    }
   

    private CampfireLocationEntity GetCanmpFireLocation(string robber)
    {
        LocationXYEntity locationXY= new LocationXYEntity();
        CampfireLocationEntity foundLoc = null;
        try
        {
            var found = from d in Global.CampfireSpots
                        where d.RobberName == ""
                        select d;
            if (found != null && found.Any())
            {
                int topindex = found.Count();
                int ranloc = new Random().Next(1, topindex);
                int i = 1;
                foreach (var item in found)
                {
                    if (i == ranloc)
                    {
                        item.RobberName = robber;

                        foundLoc = item;
                        break;
                    }
                    i++;
                }


            }
        }
        catch (Exception ex)
        {

            throw;
        }
        return foundLoc;
    }
 

    private void PoliceCar9_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());
    }

    private void PoliceCar8_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());
    }

    private void PoliceCar7_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());
    }

    private void PoliceCar6_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());
    }

    private void PoliceCar5_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());

    }

    private void PoliceCar4_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());

    }

    private void PoliceCar3_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());
    }

    private void PoliceCar2_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        AbsoluteLayout.SetLayoutBounds(car, e.GetRectCoordinates());
    }

    private void PoliceCar_PoliceCarStartMoveEvent(object? sender, PoliceCarMoveFiredEventArg e)
    {
        CarPoliceContent car = (CarPoliceContent)sender;
        Rect bound = e.GetRectCoordinates();
        //Global.WriteDebutOutput("PoliceCar_PoliceCarStartMoveEvent name " + car.RobberName
        //    + " x " + bound.X + " y " + bound.Y);
        AbsoluteLayout.SetLayoutBounds(car, bound);
    }


    private void BadGuy6_BadPersonMoveEvent(object? sender, BadPersonMoveFiredEventArg e)
    {
        AbsoluteLayout.SetLayoutBounds(BadGuy6, e.GetRectCoordinates());
    }

    private void BadGuy5_BadPersonMoveEvent(object? sender, BadPersonMoveFiredEventArg e)
    {
        AbsoluteLayout.SetLayoutBounds(BadGuy5, e.GetRectCoordinates());
    }

    private void BadGuy4_BadPersonMoveEvent(object? sender, BadPersonMoveFiredEventArg e)
    {
        AbsoluteLayout.SetLayoutBounds(BadGuy4, e.GetRectCoordinates());
    }

    private void BadGuy3_BadPersonMoveEvent(object? sender, BadPersonMoveFiredEventArg e)
    {
        AbsoluteLayout.SetLayoutBounds(BadGuy3, e.GetRectCoordinates());
    }

    private void BadGuy2_BadPersonMoveEvent(object? sender, BadPersonMoveFiredEventArg e)
    {
        AbsoluteLayout.SetLayoutBounds(BadGuy2, e.GetRectCoordinates());
    }

    private void BadGuy1_BadPersonMoveEvent(object? sender, BadPersonMoveFiredEventArg e)
    {
        AbsoluteLayout.SetLayoutBounds(BadGuy1, e.GetRectCoordinates());
    }

    internal double CityLayoutWidth
    {
        get
        {
            return CitylayOut.Width;
        }

    }
    internal double CitylayOutHeight
    {
        get
        {
            return CitylayOut.Height;
        }

    }

    private void DropGestureRecognizer_DragOver(object sender, DragEventArgs e)
    {

    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {

    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        switch (e.Direction)
        {
            case SwipeDirection.Left:
                break;
            case SwipeDirection.Right:
                break;
            case SwipeDirection.Up:
                break;
            case SwipeDirection.Down:
                break;
        }
    }
    private void canvasView_PaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
    {
        _controller.DrawMap(e);

    }
    private void GoLivingRoom(HouseContent house)
    {
        var model = ServiceHelper.GetService<LivingRoomPageViewmodel>();
        var page = ServiceHelper.GetService<LivingRoomPage>();
        model.widthofparent = this.Width;
        model.heightofparent = this.Height;
        model.House = house;
        page.ViewModel = model;
        if (house.Persons != null && house.Persons.Count() > 0)
            page.Title += "  pr:" + model.Person.Name + "  img " + house.ImageLivingFileName;
        else
            page.Title = "no person(s) assigned" + "  img " + house.ImageLivingFileName;
        Navigation.PushAsync(page);
    }
    internal void AddBusiness(BusinessContent bc)
    {
        LotEntity lot = GetLot(Global.FinancialStreets, bc.BusinesName);
        if (lot.x > 0 && lot.y > 0)
        {
            bc.WidthRequest = Global.buildingsize;
            bc.HeightRequest = Global.buildingsize;
            lot.ContentName = "BusinessContent " + bc.BusinesName;
            bc.RotateBusinessImage(lot.FrontFaceDegrees);
            bc.Lot = lot;
            CitylayOut.Add(bc);
            AbsoluteLayout.SetLayoutBounds(bc, new Rect(lot.x, lot.y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            Global.WriteDebugOutput("AddBusiness " + bc.BusinesName + " x "
                + lot.x + " y " + lot.y);
        }
    }
    internal void AddPoliceStation(PoliceStationContent ps)
    {
        LotEntity lot = GetLot(Global.PoliceStreets, "PoliceStation");
        Global.PoliceStationLocation = lot;
        ps.WidthRequest = Global.buildingsize;
        ps.HeightRequest = Global.buildingsize;

        lot.ContentName = "PoliceStation";
        ps.Lot = lot;
        Global.PoliceStationLot = lot;
        CitylayOut.Add(ps);
        AbsoluteLayout.SetLayoutBounds(ps, new Rect(lot.x, lot.y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        ps.BadPersonDroppedEvent += Ps_BadPersonDroppedEvent;
    }
    public string GetBadGuyName(Int32 number)
    {
        string name = string.Empty;
        switch (number)
        {
            case 1:
                if (BadGuy1.BadPerson != null)
                    name = BadGuy1.BadPerson.PersonName;
                break;
            case 2:
                if (BadGuy2.BadPerson != null)
                    name = BadGuy2.BadPerson.PersonName;
                break;
            case 3:
                if (BadGuy3.BadPerson != null)
                 name = BadGuy3.BadPerson.PersonName;
                break;
            case 4:
                if (BadGuy4.BadPerson != null)
                name = BadGuy4.BadPerson.PersonName;
                break;
            case 5:
                if (BadGuy5.BadPerson != null)
                    name = BadGuy5.BadPerson.PersonName;
                break;
            case 6:
                if (BadGuy6.BadPerson != null)
                    name = BadGuy6.BadPerson.PersonName;

                break;
        }
        return name;
    }
        private void Ps_BadPersonDroppedEvent(object? sender, BadPersonDroppedFiredEventArg e)
    {
        BadPersonMoveFiredEventArg arg;
        switch (e.BadPersonNumber)
        {
            case 1:
                StopBadGuyandMovetoTent(BadGuy1);
                break;
            case 2:
                StopBadGuyandMovetoTent(BadGuy2);
                break;
            case 3:
                StopBadGuyandMovetoTent(BadGuy3);

                break;
            case 4:
                StopBadGuyandMovetoTent(BadGuy4);
                break;
            case 5:
                StopBadGuyandMovetoTent(BadGuy5);
                break;
            case 6:
                StopBadGuyandMovetoTent(BadGuy6);

                break;

            default:
                break;
        }
    }
    private void StopBadGuyandMovetoTent(BadPersonnContent badguy)
    {
        badguy.IsVisible = true;
        badguy.StopTimer();
        Rect locRec = new Rect();
        locRec.X = tentx;
        locRec.Y = tenty;
        locRec.Height = AbsoluteLayout.AutoSize;
        locRec.Width = AbsoluteLayout.AutoSize;
        AbsoluteLayout.SetLayoutBounds(badguy, locRec);
        badguy.Opacity = 0;

        badguy.IsVisible = true;
        badguy.Reset();
    }

    public LotEntity GetLot(string targetLots, string name)
    {
        LotEntity result = new LotEntity();
        int lotNo = GetLotNumber(targetLots, name);
        if (lotNo > 0)
        {
            var found = from l in Global.Lots
                        where l.LotNumber == lotNo
                        select l;
            if (found != null && found.Any())
            {
                result = found.First();
            }
        }
        //else
        //{
        //    bool keeprunning = true;
        //    int counter = Global.Lots.Count() - 1;
        //    do
        //    {
        //        if (Global.Lots[counter].ContentName == "")
        //        {
        //            result = Global.Lots[counter];
        //            keeprunning = false;
        //        }

        //        if (counter == 0)
        //            keeprunning = false;

        //        counter--;
        //    } while (keeprunning);
        //}

        result.ContentName = name;
        return result;
    }
    private int GetLotNumber(string targetLots, string name)
    {
        int rInt = 0;
        Random random = new Random();
        if (name == "Catories")
        {
            var allowedLots = Global.Lots.Where(u => u.StreetName == "You St"
            && u.ContentName == "" &&
            u.lotPosition == LotPositionEnum.TopSide).ToList();
            if (allowedLots.Any())
                rInt = allowedLots.FirstOrDefault().LotNumber;
            else
            {
                var lots = from l in Global.Lots
                           where
                           l.ContentName == null
                           || l.ContentName == ""
                           select l;
                if (lots.Any())
                    rInt = lots.First().LotNumber;
            }
        }
        else if (name == "123 Bank" || name == "Jones Fin.")
        {
            var allowedLots = Global.Lots.Where(u => u.StreetName == "Mik Ave"
                && u.ContentName == "" &&
                u.lotPosition == LotPositionEnum.LeftSide).ToList();
            if (allowedLots.Any())
                rInt = allowedLots.FirstOrDefault().LotNumber;
            else
            {
                var lots = from l in Global.Lots
                           where
                           l.ContentName == null
                           || l.ContentName == ""
                           select l;
                if (lots.Any())
                    rInt = lots.First().LotNumber;
            }
        }
        else if (name == "PoliceStation")
        {
            var allowedLots = Global.Lots.Where(u => u.StreetName == "You St"
                && u.ContentName == "" &&
                u.lotPosition == LotPositionEnum.TopSide).ToList();
            if (allowedLots.Any())
                rInt = allowedLots.LastOrDefault().LotNumber;
            else
            {
                var lots = from l in Global.Lots
                           where
                           l.ContentName == null
                           || l.ContentName == ""
                           select l;
                if (lots.Any())
                    rInt = lots.First().LotNumber;
            }
        }
        {
            var arr = targetLots.Split(',');
            var allowedLots = Global.Lots.Where(u => arr.Contains(u.StreetName)
                && u.ContentName == "").ToList();

            if (allowedLots.Count > 0)
            {
                rInt = random.Next(0, allowedLots.Count() - 1);
                LotEntity lot = allowedLots[rInt];
                rInt = lot.LotNumber;
            }
        }
        //
        return rInt;
    }

    internal void AddHouse(Views.Controls.House.HouseContent hc)
    {
        LotEntity lot = GetLot(Global.HouseStreets, hc.GetHouseName());

        if (lot != null && lot.x > 0)
        {
            hc.WidthRequest = Global.buildingsize;
            hc.ZIndex = 5;
            hc.HeightRequest = Global.buildingsize;
            lot.ContentName = "HouseContent";
            hc.SetLot(lot);
            hc.RotateHouseImage(lot.FrontFaceDegrees);
            CitylayOut.Add(hc);
            AbsoluteLayout.SetLayoutBounds(hc, new Rect(lot.x, lot.y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            hc.OnBuildingOpenContent += Hc_OnBuildingOpenContent; 
        }
    }

    private void Hc_OnBuildingOpenContent(object? sender, BuildingOpenEventArgs e)
    {
        GoLivingRoom(e.House);

    }

    private void AddTent()
    {
        tentImage.Source = "tentxprnt.png";
        tentImage.HeightRequest = 100;
        tentImage.WidthRequest = 100;
        tentImage.ZIndex = 101;
        CitylayOut.Add(tentImage);
        AbsoluteLayout.SetLayoutBounds(tentImage, new Rect(tentx, tenty, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

    }
    private void CalculateBadguyTranslations()
    {
        //Global.cityforest1x = Global.cityforest1x - tentx;
        //Global.cityforest1y = (tenty -Global.cityforest1y) * -1;

        //Global.citybush1x = Global.citybush1x - tentx;
        //Global.citybush1y = (Global.citybush1y - tenty) * -1;

        //Global.citybush2x = Global.citybush2x - tentx;
        //Global.citybush2y = (Global.citybush2y - tenty) * -1;
    }
    public CarPoliceContent AddPoliceCar(string carName,Int32 number)
    {
        CarPoliceContent car = new CarPoliceContent();
        car.PoliceCarName = carName;
        car.PoliceCarNumber = number;
        car.RobberName = GetBadGuyName(number);
        car.ZIndex = 4;
        LotEntity lot = Global.PoliceStationLocation;

        if (car.RobberName == "")
            car.RobberName = "NoRobber-" + number;

        this.CitylayOut.Children.Add(car);
        double x = lot.x-100;
        CitylayOut.SetLayoutBounds(car, new Rect(x,lot.y,0, 0));
        switch (number)
        {
            case 1:
                car.PoliceCarStartMoveEvent += PoliceCar_PoliceCarStartMoveEvent;
                break;
            case 2:
                car.PoliceCarStartMoveEvent += PoliceCar2_PoliceCarStartMoveEvent;
                break;
            case 3:
                car.PoliceCarStartMoveEvent += PoliceCar3_PoliceCarStartMoveEvent;
                break;
            case 4:
                car.PoliceCarStartMoveEvent += PoliceCar4_PoliceCarStartMoveEvent;
                break;
            case 5:
                car.PoliceCarStartMoveEvent += PoliceCar5_PoliceCarStartMoveEvent;
                break;
            case 6:
                car.PoliceCarStartMoveEvent += PoliceCar6_PoliceCarStartMoveEvent;
                break;
            case 7:
                car.PoliceCarStartMoveEvent += PoliceCar7_PoliceCarStartMoveEvent;
                break;
            case 8:
                car.PoliceCarStartMoveEvent += PoliceCar8_PoliceCarStartMoveEvent;
                break;
            case 9:
                car.PoliceCarStartMoveEvent += PoliceCar9_PoliceCarStartMoveEvent;
                break;
            default:
                break;
        }
        return car;
    }
            
    internal void AddBadguy(BadPersonEntity person)
    {

        switch (badcount)
        {
            case 0:
                BadGuy1.SetPerson(person, 1);
                break;
            case 1:
                BadGuy2.SetPerson(person, 2);
                break;
            case 2:
                BadGuy3.SetPerson(person, 3);
                break;
            case 3:
                BadGuy4.SetPerson(person, 4);
                break;
            case 4:
                BadGuy5.SetPerson(person, 5);
                break;
            case 5:
                BadGuy6.SetPerson(person, 6);
                break;
            default:
                break;
        }
        badcount++;
    }
   
    internal void AddGovernment(BusinessContent bc)
    {
        LotEntity lot = GetLot(Global.GovStreets, "NA");
        bc.WidthRequest = Global.buildingsize;
        bc.HeightRequest = Global.buildingsize;
        lot.ContentName = "GovernmentContent";
        CitylayOut.Add(bc);
        AbsoluteLayout.SetLayoutBounds(bc, new Rect(lot.x, lot.y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
    }
    internal void AddYouStreetLabel(int x, int y)
    {
        Label youst = new Label();
        youst.Text = "You Street";
        youst.HeightRequest = 20;
        youst.ZIndex = 99;
        Global.YouStStreetloc.x = x;
        Global.YouStStreetloc.y = y;
        CitylayOut.Add(youst);
        AbsoluteLayout.SetLayoutBounds(youst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
    }
    internal void AddTeaStreetLabel(int x, int y)
    {
        Label teast = new Label();
        teast.Text = "Tea Street";
        teast.HeightRequest = 20;
        teast.ZIndex = 99;
        teast.RotateTo(90);
        Global.TeaStStreetLoc.x = x;
        Global.TeaStStreetLoc.y = y;
        CitylayOut.Add(teast);
        AbsoluteLayout.SetLayoutBounds(teast, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
    }
    internal void AddMikStreetLabel(int x, int y)
    {
        Label milkst = new Label();
        milkst.Text = "Mik Ave";
        milkst.HeightRequest = 20;
        milkst.ZIndex = 99;
        CitylayOut.Add(milkst);
        Global.MikAveStreetLoc.x = x;
        Global.MikAveStreetLoc.y = y;
        AbsoluteLayout.SetLayoutBounds(milkst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

    }
    internal void AddYodelLaneLabel(int x, int y)
    {
        Label yodelst = new Label();
        yodelst.Text = "Yodel Lane";
        yodelst.HeightRequest = 20;
        yodelst.ZIndex = 99;
        yodelst.RotateTo(90);
        CitylayOut.Add(yodelst);
        Global.YodelLaneStreetLoc.x = x;
        Global.YodelLaneStreetLoc.y = y;
        AbsoluteLayout.SetLayoutBounds(yodelst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

    }
    internal void AddMooDrLaneLabel(int x, int y)
    {
        Label moodr = new Label();
        moodr.Text = "Moo Dr";
        moodr.HeightRequest = 20;
        moodr.ZIndex = 99;
        moodr.RotateTo(90);
        CitylayOut.Add(moodr);
        Global.MooDrStreetLoc.x = x;
        Global.MooDrStreetLoc.y = y;
        AbsoluteLayout.SetLayoutBounds(moodr, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
    }
    private void ResetTimers()
    {
        BadGuy1.ResetTimer();
    }

    private void ToolbarSelector_Clicked(object sender, EventArgs e)
    {
        if (_toolbarsetting == "normal")
        {
            mainMenuLayoutControl.IsVisible = true;
        }
        else
        {
            mainMenuLayoutControl.IsVisible = false;
            Global.UpdateUISettings();

            Global.InsertSetting("campfire", "", Global.CampFire);
            Global.InsertSetting("travelspeed", "", Global.TravelSpeed);
            Global.InsertSetting("badguycount", "", Global.BadguyCount);
            Global.InsertSetting("policecarspeed", "", Global.PoliceCarSpeed);
            Global.InsertSetting("campfiresleeptime", "", Global.CampFireSleepTime);
            ResetTimers();
        }
    }
}