using CityScapeApp.Objects;
using CityScapeApp.Objects.Entities;
using CityScapeApp.Objects.Graphics;
using CityScapeApp.Objects.ViewModels;
using CityScapeApp.Views.Controls.Business;
using CityScapeApp.Views.Controls.Car;
using CityScapeApp.Views.Controls.House;
using CityScapeApp.Views.Controls.Person;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace CityScapeApp.Controllers
{
    internal class CityLayoutcontrolController
    {
        internal CityLayoutcontrolViewmodel Model = new CityLayoutcontrolViewmodel();
        private CityLayoutcontrol _view;
        public bool instartupFlag = true;
        bool VisualContentLoaded = false;
        MapPositionEntity _mapPosition = new  MapPositionEntity();
        internal CityLayoutcontrolController(CityLayoutcontrol view)
        {
            _view = view;
            _view.BindingContext = Model;
             Global.Images = ResourceHelper.GetImages();
            Startup();

        }
        private void LoadCars()
        {
            CarContent car1 = new CarContent("Sports", "auto_1_spportcarfitst.png", "$4000");
            car1.CarBoughtEvent += Car_CarBoughtEvent;
            CarContent car2 = new CarContent("Truck", "auto_3_truck.png", "$3000");
            car2.CarBoughtEvent += Car_CarBoughtEvent;
            AddCar(car1);
            AddCar(car2);
        }
        private void Car_CarBoughtEvent(object? sender, Objects.careventArg e)
        {

        }
        internal void Startup()
        {
            LotHelper lotHelper = new LotHelper(_view);

     
            LoadDefaultuiItems();
 
            

        }
        private void LoadVisualContent()
        {
            var citiesFromq = from c in Global.CityAppMaster.CityApp
                              where
                c.CityAppNumber == Global.CityAppMaster.CurrentCityAppNumber
                              select c;
     
            foreach (var city in citiesFromq)
            {
                var found = from h in city.Houses
                            where h.Name == "Catories"
                            select h;
                if (found.Any())
                {
                    HouseContent house = new Views.Controls.House.HouseContent(found.First().Name, found.First().ImageName, found.First().ImageLivingRoomFileName, 
                        found.First().ImageKitchenFileName, found.First().ImageGarageFileName, Global.buildingsize);
                    house.StyleId = found.First().NameAsControlName;
                    _view.AddHouse(house);
                    var foundcatori = from p in city.Persons where p.Name.Contains("Catori") select p;
                    if (foundcatori != null && found.Count() > 0) { }
                    {
                        PersonContent personContent = new PersonContent(foundcatori.First());
                        house.SetPerson(personContent);
                    }
                }
                var busfin = from b in city.Busiesses where b.BusinessType == BusinessTypeEnum.Financial select b;
                var busfac = from c in city.Busiesses where c.BusinessType == BusinessTypeEnum.Factory select c;
                int rowcount = 1;
                foreach (var bus in busfin)
                {

                    BusinessContent bc = new BusinessContent(bus);
                    bc.HeightRequest = 80;
                    bc.WidthRequest = 80;
                    _view.AddBusiness(bc);
                    rowcount++;
                }
                rowcount = 1;
                foreach (var bus in busfac)
                {
                    BusinessContent bc = new BusinessContent(bus);
                    bc.HeightRequest = 80;
                    bc.WidthRequest = 80;
                    _view.AddBusiness(bc);
                    rowcount++;
                }
                var badguys = from c in city.BadPersons select c;
                foreach (var bg in badguys)
                {
                    BadPersonnContent bp = new BadPersonnContent(bg);
                    _view.AddBadguy(bp);
                }
                //foreach (var bg in badguys)
                //{
                //    BadPersonnContent bp = new BadPersonnContent(bg);
                //    _view.AddBadguy(bp);
                //}
     
                foreach (HouseEntity hse in city.Houses)
                {
                    if (hse.Name != "Catories")
                    {
                        HouseContent house = new Views.Controls.House.HouseContent(hse.Name, hse.ImageName, hse.ImageLivingRoomFileName,hse.ImageKitchenFileName,hse.ImageGarageFileName,Global.buildingsize);
                        house.StyleId = hse.NameAsControlName;
                        _view.AddHouse(house);
                    }
                }
                //house.SetCar(new CarContent("Sports", "autospportcarfitst.png", "400"));

            }
        }
        private void LoadDefaultuiItems()
        {
            //"Catori", "peoplegirlfirst.png", 100
            var citiesFromq = from c in Global.CityAppMaster.CityApp
                              where
                       c.CityAppNumber == Global.CityAppMaster.CurrentCityAppNumber
                              select c;

            CityappEntity cityappEntity = new CityappEntity();
            if (citiesFromq != null || citiesFromq.Count() > 0)
            {
                cityappEntity = citiesFromq.FirstOrDefault();
            }
            if (cityappEntity == null)
                cityappEntity = new CityappEntity();
            cityappEntity.Persons = new List<PersonEntity>();
            PersonEntity personEntity = new PersonEntity();
            personEntity.Name = "Catori";
            personEntity.IsUser = true;
            personEntity.PersonRole = PersonEnum.Individual;
            PersonImageEntity image1 = new PersonImageEntity();
            image1.Name = "peoplegirlfirst";
            image1.FilePath = "peoplegirlfirst.png";
            image1.PersonImageType = PersonImageTypeEnum.Normal;
            personEntity.ImageNames.Add(image1);
            cityappEntity.Persons.Add(personEntity);

            PersonImageEntity image2 = new PersonImageEntity();
            image2.Name = "peoplegirlfirstworking";
            image2.FilePath = "peoplegirlfirstworking.png";
            image2.PersonImageType = PersonImageTypeEnum.Working;
            personEntity.ImageNames.Add(image2);
            cityappEntity.Persons.Add(personEntity);
            BusiessEntity bus1 = new BusiessEntity();
            bus1.Add("My Bank", 200, "bank1.png", BusinessTypeEnum.Financial);
            BusinessContent busc1 = new BusinessContent(bus1);
            BusiessEntity bus2 = new BusiessEntity();
            bus2.Add("Smith Bank", 200, "bank2.png", BusinessTypeEnum.Financial);
            BusinessContent busc2 = new BusinessContent(bus2);

            BusiessEntity bus3 = new BusiessEntity();
            bus3.Add("Jones Fin.", 200, "bank1.png", BusinessTypeEnum.Financial);
            BusinessContent busc3 = new BusinessContent(bus3);
            BusiessEntity bus4 = new BusiessEntity();
            bus4.Add("Iron Factory", 130, "factory1.png", BusinessTypeEnum.Factory);
            BusinessContent busc4 = new BusinessContent(bus4);
            BusiessEntity bus5 = new BusiessEntity();
            bus5.Add("Auto Factory", 150, "factory1.png", BusinessTypeEnum.Factory);
            BusinessContent busc5 = new BusinessContent(bus5);
            cityappEntity.Busiesses.Add(bus1);
            cityappEntity.Busiesses.Add(bus2);
            cityappEntity.Busiesses.Add(bus3);
            cityappEntity.Busiesses.Add(bus4);
            cityappEntity.Busiesses.Add(bus5);

            HouseEntity house1 = new HouseEntity("Catories", "house3d4.png", "livingroomarmchair.png", "kitchen3.png","garage1.png", true);
            HouseEntity house2 = new HouseEntity("Jeffs", "house3d5.png", "livingroomarmchair.png", "kitchen2.png", "garage2.png", true);
            //HouseEntity house3 = new HouseEntity("Quyens", "house3d6.png", "livingroom3.png", "kitchen3.png", "garage3.png", true);
            //HouseEntity house4 = new HouseEntity("Joe", "house3d7.png", "livingroom1.png", "kitchen2.png", "garage2.png", true);
            //HouseEntity house5 = new HouseEntity("Papa", "house3dtrees2.png", "livingroom2.png", "kitchen3.png", "garage1.png", true);
            //HouseEntity house6 = new HouseEntity("Gaga", "house3dtrees3.png", "livingroom1.png", "kitchen2.png", "garage3.png", true);
            //HouseEntity house7 = new HouseEntity("Sara", "house3dyardfence.png", "livingroom2.png", "kitchen1.png", "garage2.png", true);
            //HouseEntity house8 = new HouseEntity("John", "house3s1.png", "livingroom1.png", "kitchen3.png", "garage1.png", true);
            //HouseEntity house9 = new HouseEntity("Gary", "housedkbrownroofgarage.png", "livingroom3.png", "kitchen2.png", "garage1.png", true);
            //HouseEntity house10 = new HouseEntity("Sue", "housegrayroofgarage.png", "livingroom2.png", "kitchen1.png", "garage2.png", true);
            //HouseEntity house11 = new HouseEntity("Bill", "housegreenroofgarage.png", "livingroom1.png", "kitchen3.png", "garage3.png", true);
            //HouseEntity house12 = new HouseEntity("Jack", "houseredroofgarage.png", "livingroom3.png", "kitchen2.png", "garage2.png", true);
            cityappEntity.Houses.Add(house1);
            cityappEntity.Houses.Add(house2);
            //cityappEntity.Houses.Add(house3);
            //cityappEntity.Houses.Add(house4);
            //cityappEntity.Houses.Add(house5);
            //cityappEntity.Houses.Add(house6);
            //cityappEntity.Houses.Add(house7);
            //cityappEntity.Houses.Add(house8);
            //cityappEntity.Houses.Add(house9);
            //cityappEntity.Houses.Add(house10);
            //cityappEntity.Houses.Add(house11);
            //cityappEntity.Houses.Add(house12);
            //house.SetCar(new CarContent("Sports", "autospportcarfitst.png", "400"));


            LoadDefaultBadGuys(cityappEntity);


            Global.CityAppMaster.CityApp.Add(cityappEntity);
        }

        private void LoadDefaultBadGuys(CityappEntity cityappEntity)
        {
            List<BadPersonImageEntity> bdguyimages = new List<BadPersonImageEntity>();
            BadPersonImageEntity bpi1 = new BadPersonImageEntity();
            bpi1.FilePath = "badguy2coffee.png";
            bpi1.ImageType = "Drinking";
            bdguyimages.Add(bpi1);

            BadPersonImageEntity bpi31a = new BadPersonImageEntity();
            bpi31a.FilePath = "badguy2money.png";
            bpi31a.ImageType = "Money";
            bdguyimages.Add(bpi31a);

            BadPersonImageEntity bpi3 = new BadPersonImageEntity();
            bpi3.FilePath = "badguy2smirk.png";
            bpi3.ImageType = "Smirk";
            bdguyimages.Add(bpi3);

            BadPersonImageEntity bpi3a = new BadPersonImageEntity();
            bpi3a.FilePath = "badguy3.png";
            bpi3a.ImageType = "Drinking";
            bdguyimages.Add(bpi3a);

            BadPersonImageEntity bpi2a = new BadPersonImageEntity();
            bpi2a.FilePath = "badguy4.png";
            bpi2a.ImageType = "Normal";
            bdguyimages.Add(bpi2a);

            BadPersonImageEntity bpi4aa = new BadPersonImageEntity();
            bpi4aa.FilePath = "badguy4armsup.png";
            bpi4aa.ImageType = "Arms Up";
            bdguyimages.Add(bpi4aa);

            List<BadPersonImageEntity> mojoimages = new List<BadPersonImageEntity>();
            BadPersonImageEntity bpi4 = new BadPersonImageEntity();
            bpi4.FilePath = "badguy4mojojojo.png";
            bpi4.ImageType = "Drinking";
            mojoimages.Add(bpi4);


            BadPersonImageEntity bpi5 = new BadPersonImageEntity();
            bpi5.FilePath = "badguy5amsout.png";
            bpi5.ImageType = "Arms Out";
            bdguyimages.Add(bpi5);

            BadPersonImageEntity bpi6 = new BadPersonImageEntity();
            bpi6.FilePath = "badguyarmsdown.png";
            bpi6.ImageType = "Arms Down";
            bdguyimages.Add(bpi6);

            List<BadPersonImageEntity> devilimages = new List<BadPersonImageEntity>();
            BadPersonImageEntity bpi7 = new BadPersonImageEntity();
            bpi7.FilePath = "badguydevil.png";
            bpi7.ImageType = "Devil";
            devilimages.Add(bpi3);

            BadPersonImageEntity bpi8 = new BadPersonImageEntity();
            bpi8.FilePath = "badguylootgun.png";
            bpi8.ImageType = "Loot Gun";
            bdguyimages.Add(bpi8);

            BadPersonImageEntity bpi9 = new BadPersonImageEntity();
            bpi9.FilePath = "badguymad.png";
            bpi9.ImageType = "Mad";
            bdguyimages.Add(bpi9);

            BadPersonImageEntity bpi10 = new BadPersonImageEntity();
            bpi10.FilePath = "badguywcash.png";
            bpi10.ImageType = "Cash";
            bdguyimages.Add(bpi10);

            BadPersonImageEntity bpi11 = new BadPersonImageEntity();
            bpi11.FilePath = "badguywithgun.png";
            bpi11.ImageType = "Gun";
            bdguyimages.Add(bpi11);

            BadPersonImageEntity bpi12 = new BadPersonImageEntity();
            bpi12.FilePath = "badguywloot.png";
            bpi12.ImageType = "Loot";
            bdguyimages.Add(bpi12);

            BadPersonEntity bgnormal = new BadPersonEntity();
            bgnormal.Images = bdguyimages;
            bgnormal.Name = "Joe Skinny";
            BadPersonEntity bgMoJo = new BadPersonEntity();
            bgMoJo.Images = mojoimages;
            bgMoJo.Name = "Mojo";

            BadPersonEntity devil = new BadPersonEntity();
            devil.Images = devilimages;
            devil.Name = "sue Devil";

            BadPersonnContent bpc10 = new BadPersonnContent(bgnormal);
            BadPersonnContent bpc11 = new BadPersonnContent(bgMoJo);

            BadPersonnContent bpc1 = new BadPersonnContent(devil);
            cityappEntity.BadPersons.Add(bgnormal);
            _view.AddBadguy(bpc1);
            _view.AddBadguy(bpc10);
            _view.AddBadguy(bpc11);
        }

        private void MySettingsDropdown_SelectedIndexChanged(object? sender, EventArgs e)
        {
            //var selectedOption = mySettingsDropdown.SelectedItem?.ToString();
            //carshopliststack.IsVisible = false;
            //PeopleStack.IsVisible = false;
            //HouseStack.IsVisible = false;
            //switch (selectedOption)
            //{
            //    case "Cars":
            //        carshopliststack.IsVisible = true;
            //        break;
            //    case "People":
            //        PeopleStack.IsVisible = true;
            //        break;
            //    case "Houses":
            //        HouseStack.IsVisible = true;
            //        break;
            //    default:
            //        break;
            //}
        }

        internal void AddCar(CarContent car)
        {
            //carshopliststack.Add(car);
        }
        internal void MainSizeChanged(double width, double height)
        {
            Model.HandleSizeChange(width, height);
            if (instartupFlag == false)
            {

            }
            //_view.SetCityRoadHorizontalLengthTopLine(Model.CityRoadHorizontalLength, Model.CityRoadFromEdge);
            instartupFlag = false;
        }
        internal void DrawMap(SKPaintSurfaceEventArgs args)
        {
            SkiaMapper skiaMapper = new SkiaMapper(args, _mapPosition,VisualContentLoaded,_view);
            VisualContentLoaded = true;
            skiaMapper.OnLoadVisualContent += SkiaMapper_OnLoadVisualContent; ;
            skiaMapper.Draw();
        }

        private void SkiaMapper_OnLoadVisualContent(object? sender, SkiaMapperEventArgs e)
        {
            LoadVisualContent();
        }

        private void ShowLots(SKCanvas canvas)
        {
            SkiaSharp.SKPaint lotPaint = new SkiaSharp.SKPaint
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = SkiaSharp.SKColors.Red,
                StrokeWidth = 2
            };
            foreach (var lot in Global.Lots)
            {
                SKRect Lotskrect = new SKRect(lot.x,lot.y,lot.x + Global.LotSizeNormal,lot.y + Global.LotSizeNormal);

                canvas.DrawRect(Lotskrect, lotPaint);

            }
       
        }
        internal void Redraw()
        {
            
        }
    }     
}
