using CityScapeApp.Controllers;
using CityScapeApp.Objects;
using CityScapeApp.Objects.Entities;
using CityScapeApp.Views.Controls.Person;
using SkiaSharp.Views.Maui;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CityScapeApp.Views.Controls.Business
{
    public partial class CityLayoutcontrol : ContentView
    {
        CityLayoutcontrolController _controller;
        int badcount = 0;
        int tentx = 550;
        int tenty = 250;
        Microsoft.Maui.Controls.Image tentImage = new Microsoft.Maui.Controls.Image();
        public event EventHandler<BuildingOpenEventArgs> OnBuildingOpenContent;

        public CityLayoutcontrol()
        {
            InitializeComponent();
            _controller = new CityLayoutcontrolController(this);

            //  System.Diagnostics.Debug.WriteLine("width " + MidColumn.)

            if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
                Console.WriteLine("The current device is a desktop");
            else if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
                Console.WriteLine("The current device is a phone");
            else if (DeviceInfo.Current.Idiom == DeviceIdiom.Tablet)
                Console.WriteLine("The current device is a Tablet");
            AddTent();
        }

        

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            _controller.DrawMap(args);
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

        internal void MainSizeChanged(double width, double height)
        {
            CitylayOut.WidthRequest = width ;
            // CitylayOut.HeightRequest = height * 2;
            CitylayOut.HeightRequest = height;
            //double rightstackwidth = 100;

            //double rightstackx = width - rightstackwidth;
            //System.Diagnostics.Debug.WriteLine("rightx " + rightstackx + "  width " + width);
            //AbsoluteLayout.SetLayoutBounds(TopStack, new Rect(0, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            //AbsoluteLayout.SetLayoutBounds(RightStack, new Rect(rightstackx, 0, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            //AbsoluteLayout.SetLayoutBounds(LeftStack, new Rect(0,Global.streetouteroffset, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            //AbsoluteLayout.SetLayoutBounds(BottomStack, new Rect(0,height- Global.streetouteroffset, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


            _controller.MainSizeChanged(width, height);

        }
        internal void AddBusiness(BusinessContent bc)
        {
            LotEntity lot = GetLot(Global.FinancialStreets,"NA");
            bc.WidthRequest = Global.buildingsize;
            bc.HeightRequest = Global.buildingsize;
            lot.ContentName = "BusinessContent";
            bc.RotateBusinessImage(lot.FrontFaceDegrees);
            CitylayOut.Add(bc);
            AbsoluteLayout.SetLayoutBounds(bc, new Rect(lot.x,lot.y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        private LotEntity GetLot(string targetLots,string housename)
        {
            LotEntity result= new LotEntity();
            int lotNo = GetLotNumber(targetLots,housename);
            if (lotNo > 0 )
            {
                var found = from l in Global.Lots 
                            where l.LotNumber ==lotNo select l;
                if (found != null && found.Any()) 
                {
                    result = found.First();
                }
            }
            else
            {
                    bool keeprunning = true;
                    int counter = Global.Lots.Count()-1;
                    do
                    {
                        if ( Global.Lots[counter].ContentName == "")
                        {
                            result = Global.Lots[counter];
                            keeprunning=false;
                        }
                 
                        if (counter == 0)
                        keeprunning=false ;

                        counter--;
                    } while (keeprunning);
                }
                
            
            return result;
        }
        private int GetLotNumber(string targetLots,string housename)
        {
            int rInt = 0;
            Random random = new Random();
            if (housename == "Catories")
            {
                var allowedLots = Global.Lots.Where(u => u.StreetName== "Moo Dr" && u.ContentName == "").ToList();
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
            else
            {
                var arr = targetLots.Split(',');
                var allowedLots = Global.Lots.Where(u => arr.Contains(u.StreetName)).ToList();

                if (allowedLots.Count > 0)
                    rInt = random.Next(0, allowedLots.Count() - 1);
            }
            return rInt;
        }

        internal void AddHouse(Views.Controls.House.HouseContent hc)
        {
            LotEntity lot = GetLot(Global.HouseStreets,hc.GetHouseName());
            hc.WidthRequest = Global.buildingsize;
            hc.HeightRequest = Global.buildingsize;
            lot.ContentName = "HouseContent";
            hc.SetLot(lot);
            hc.RotateHouseImage(lot.FrontFaceDegrees);
            CitylayOut.Add(hc);
            AbsoluteLayout.SetLayoutBounds(hc, new Rect(lot.x, lot.y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            hc.OnBuildingOpenContent += Hc_OnBuildingOpenContent;
        }

        private void Hc_OnBuildingOpenContent(object? sender, BuildingOpenEventArgs e)
        {
            if (OnBuildingOpenContent != null)
            {
              OnBuildingOpenContent(this, e);
            }
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
        internal void AddBadguy(BadPersonnContent bpc)
        {
            badcount++;
            double x = tentx - (badcount * bpc.Width);
            double y = tenty + (bpc.Height * badcount);
            System.Diagnostics.Debug.WriteLine("Count " + badcount + " x " + x + " y" + y);
            bpc.StartShowTimer(badcount * 10);
            bpc.IsVisible = false;
            CitylayOut.Add(bpc);
            AbsoluteLayout.SetLayoutBounds(bpc, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            //MainOverlay.Add(bpc);
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
        internal void AddYouStreetLabel(int x,int y)
        {
            Label youst = new Label();
            youst.Text = "You Street";
            youst.HeightRequest = 20;
            youst.ZIndex = 99;
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
            CitylayOut.Add(teast);
            AbsoluteLayout.SetLayoutBounds(teast, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
        }
        internal void AddMikStreetLabel(int x, int y)
        {
            Label milkst = new Label();
            milkst.Text = "Mik Avenue";
            milkst.HeightRequest = 20;
            milkst.ZIndex = 99;
            CitylayOut.Add(milkst);
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
            AbsoluteLayout.SetLayoutBounds(yodelst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

        }
        internal void AddMooDrLaneLabel(int x, int y)
        {
            Label yodelst = new Label();
            yodelst.Text = "Moo Dr";
            yodelst.HeightRequest = 20;
            yodelst.ZIndex = 99;
            yodelst.RotateTo(90);
            CitylayOut.Add(yodelst);
            AbsoluteLayout.SetLayoutBounds(yodelst, new Rect(x, y, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

        }

        private void ContentView_Loaded(object sender, EventArgs e)
        {
            //_controller.testrect1y =Convert.ToInt32(test1Entry.Text);
            //_controller.testrect2y = Convert.ToInt32(test2Entry.Text);
            //_controller.testrect3y = Convert.ToInt32(test4Entry.Text);
        }
    
    }
}
