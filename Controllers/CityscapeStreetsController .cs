using CityScapeApp.Views.Controls.Police;

namespace CityScapeApp.Controllers
{
    internal class CityscapeStreetsController
    {
        internal CityscapeStreetsViewModel Model = new CityscapeStreetsViewModel();
        private CityscapeStreets _view;
        public bool instartupFlag = true;
        bool VisualContentLoaded = false;
        MapPositionEntity _mapPosition = new MapPositionEntity();
        internal CityscapeStreetsController(CityscapeStreets view)
        {
            _view = view;
            _view.BindingContext = Model;
            AdoNetHelper adoNetHelper = new AdoNetHelper();

            Global.Addbadguypaths();
            Global.AddbadguyEscapepaths();
            Global.PersonRepository = new PersonRepository();
            Global.ImageRepository = new PersonImageImageRepository();
            Global.BusinessRepository = new BusinessRepository();
            Global.HouseRepository = new HouseRepository();
            Global.SettingsRepository = new SettingsRepository(adoNetHelper.GetConnection());
            Global.PersonImageRepository = new PersonImageImageRepository();
            Global.LoadSettings();
            SampleData.CreateSampleUsers();
            
            ResourceHelper.GetImages();
            StartupAsync();


        }
        private void LoadPoliceCars()
        {
            LotEntity lot = _view.GetLot(Global.PoliceStreets, "PoliceStation");
            
            CarPoliceContent car1 = _view.AddPoliceCar("Car1", 1);
            AbsoluteLayout.SetLayoutBounds(car1, new Rect(lot.x, lot.y + 5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            CarPoliceContent car2 = _view.AddPoliceCar("Car2", 2);
            AbsoluteLayout.SetLayoutBounds(car2, new Rect(lot.x, lot.y + 5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            CarPoliceContent car3 = _view.AddPoliceCar("Car3", 3);
            AbsoluteLayout.SetLayoutBounds(car3, new Rect(lot.x, lot.y + 5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            CarPoliceContent car4 = _view.AddPoliceCar("Car4", 6);
            AbsoluteLayout.SetLayoutBounds(car4, new Rect(lot.x, lot.y + 5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            CarPoliceContent car5 = _view.AddPoliceCar("Car5", 6);
            AbsoluteLayout.SetLayoutBounds(car5, new Rect(lot.x, lot.y + 5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            CarPoliceContent car6 = _view.AddPoliceCar("Car6", 7);
            AbsoluteLayout.SetLayoutBounds(car6, new Rect(lot.x, lot.y + 5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));


        }
        private void LoadCars()
        {
            CarContent car1 = new CarContent("Sports", "auto_1_spportcarfitst.jpg", "$4000");
            car1.CarBoughtEvent += Car_CarBoughtEvent;
            CarContent car2 = new CarContent("Truck", "auto_3_truck.jpg", "$3000");
            car2.CarBoughtEvent += Car_CarBoughtEvent;
            AddCar(car1);
            AddCar(car2);
        }
        private void Car_CarBoughtEvent(object? sender, Objects.careventArg e)
        {

        }
        internal async Task StartupAsync()
        {
            LotHelper lotHelper = new LotHelper(_view);

           // List<PersonEntity> persons = await Global.PersonRepository.GetPersonsAsync();
            // Global.CityAppMaster.CityApp[0].Persons = persons;

            LoadDefaultuiItemsAsync();
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
                            where h.OwnerName == "Catories"
                            select h;
                if (found.Any())
                {
                    HouseContent house = new Views.Controls.House.HouseContent(found.First().Name, found.First().ImageFileName, found.First().ImageLivingRoomFileName,
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
                int i = 0;
                foreach (HouseEntity hse in city.Houses)
                {
                    if (hse.Name != "Catories")
                    {
                        HouseContent house = new Views.Controls.House.HouseContent(hse.Name, hse.ImageFileName, hse.ImageLivingRoomFileName, hse.ImageKitchenFileName, hse.ImageGarageFileName, Global.buildingsize);
                        house.StyleId = hse.NameAsControlName;
                        var foundperson = from p in city.Persons where p.Name.Contains("Catori") == false select p;

                        _view.AddHouse(house);
                    } 
                    if (i == 6)
                    {

                        PoliceStationContent ps = new PoliceStationContent();
                        ps.ZIndex = 4;
                        _view.AddPoliceStation(ps);
                        LoadPoliceCars();
                    }

                    i++;
                }

                var busfin = from b in city.Businesses where b.BusinessType == BusinessTypeEnum.Financial select b;
                var busfac = from c in city.Businesses where c.BusinessType == BusinessTypeEnum.Factory select c;
                int rowcount = 1;
                foreach (var bus in busfin)
                {

                    BusinessContent bc = new BusinessContent(bus);
                    bc.HeightRequest = 80;
                    bc.WidthRequest = 80;
                    bc.ZIndex = 4;
                    _view.AddBusiness(bc);
                    Global.Businesses.Add(bc);
                    rowcount++;
                }
                rowcount = 1;
                foreach (var bus in busfac)
                {
                    if (rowcount <= 2)
                    {
                        BusinessContent bc = new BusinessContent(bus);
                        bc.HeightRequest = 80;
                        bc.WidthRequest = 80;
                        bc.ZIndex = 4;
                        _view.AddBusiness(bc);
                        Global.Businesses.Add(bc);
                    }
                    rowcount++;
                }
 
                //house.SetCar(new CarContent("Sports", "autospportcarfitst.jpg", "400"));
            }
        }
        
        private void AddHouseToList(string name, string imageName = "")
        {
            if (imageName == "")
            {
                //dddd
            }
            //       HouseContent house = new Views.Controls.House.HouseContent(found.First().Name, found.First().ImageName, found.First().ImageLivingRoomFileName,
            //found.First().ImageKitchenFileName, found.First().ImageGarageFileName, Global.buildingsize);
            //       house.StyleId = found.First().NameAsControlName;
            //       _view.AddHouse(house);

        }
        private async Task LoadDefaultuiItemsAsync()
        {
            //"Catori", "peoplegirlfirst.jpg", 100
            var citiesFromq = from c in Global.CityAppMaster.CityApp
                              where
                       c.CityAppNumber == Global.CityAppMaster.CurrentCityAppNumber
                              select c;

            CityappEntity cityapp = new CityappEntity();
            if (citiesFromq != null || citiesFromq.Count() > 0)
            {
                cityapp = citiesFromq.FirstOrDefault();
            }
            if (cityapp == null)
                cityapp = new CityappEntity();
            try
            {
                cityapp.Businesses = await Global.BusinessRepository.GetBusinesssAsync();
                cityapp.Persons = await Global.PersonRepository.GetPersonsAsync();
                cityapp.Houses = await Global.HouseRepository.GetHousesAsync();
                cityapp.PersonImages = await Global.PersonImageRepository.GetPersonImagesAsync();
                foreach (var item in cityapp.Persons)
                {
                    var images = from i in cityapp.PersonImages
                                 where i.FKPersonId == item.PersonId
                                 select i;
                    if (images != null && images.Any())
                        item.Images = images.ToList();
                }
                Global.WriteDebugOutput("Businesses loaded " + cityapp.Businesses.Count); ;
                Global.WriteDebugOutput("Persons loaded " + cityapp.Persons.Count); ;
                Global.WriteDebugOutput("Houses loaded " + cityapp.Houses.Count); ;
                Global.WriteDebugOutput("PersonImages loaded " + cityapp.PersonImages.Count); ;

            }
            catch (Exception ex)
            {
                Global.WriteDebugOutput(ex.Message); 
            }//cityapp.Businesses = await Global.BusinessRepository.GetBusinesssAsync();
            foreach (var per in cityapp.Persons) 
            {
                var found = from i in cityapp.PersonImages where i.FKPersonId == per.PersonId select i;
                if (found.Any())
                {
                    foreach (var item in found)
                    {
                        per.Images.Add(item);
                    }
                }
            }
            Global.Loading = false;


            //foreach (var person  in cityapp.Persons)
            //{

            //    List<PersonImageEntity> images = GetFileParts(person.CurrentImage, cityapp);
            //    if (images.Any())
            //    {
            //        try
            //        {

            //          foreach (var image in images)
            //            {
            //                person.AddPersonImage(image);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            throw;
            //        }
            //    }

            //}


            LoadDefaultBadGuys(cityapp);

            Global.CityAppMaster.CityApp.Add(cityapp);
        }
        private List<PersonImageEntity> GetFileParts(string currentImage, 
            CityappEntity cityapp)
        {
            List<PersonImageEntity> results = new List<PersonImageEntity>();
            string nameonly = System.IO.Path.GetFileNameWithoutExtension(currentImage);
            var foundpics = from p in cityapp.PersonImages
                            where p.Name.StartsWith(nameonly)
                            select p;

            if (foundpics.Any())
            {
                foreach (var image in foundpics)
                {
                    results.Add(image);
                } 
            }
            return results;
        }
        private Imagenamepartsentity GetFileNameParts(string fileName)
        {
            Imagenamepartsentity result = new Imagenamepartsentity();
            string[] thisImagePartsArray = fileName.Split('_');
            if (thisImagePartsArray.Length > 2)
            {
                result.Name = thisImagePartsArray[0];
                result.Number = Convert.ToInt32(thisImagePartsArray[1]);
                if (thisImagePartsArray.Length > 2)
                    result.Suffix = thisImagePartsArray[2];
            }
            return result;
        }
        //private BusiessEntity CreateBusinessEntity(string name, BusinessTypeEnum businessType ,int payrate)
        //{
        //    BusiessEntity busiess = new BusiessEntity();
        //    ImageTypeEntity imageType = new ImageTypeEntity();
        //    Random rand = new Random();
        //    int index;
        //    switch (businessType)
        //    {
        //        case BusinessTypeEnum.Government:

        //            string image1 = "";
        //            //var foundbadguys = from b in cityapp.BadPersons where b.StartsWith("badguy") select b;
        //            //index = rand.Next(foundbadguys.Count());
        //            //image1 = foundbadguys.ElementAt(index);
        //            break;
        //        case BusinessTypeEnum.Retail:
        //            var foundret = from b in Global.re where b.StartsWith("badguy") select b;
        //            index = rand.Next(foundbadguys.Count());
        //            image1 = foundbadguys.ElementAt(index);
        //            break;
        //        case BusinessTypeEnum.Financial:
        //            break;
        //        case BusinessTypeEnum.Airport:
        //            break;
        //        case BusinessTypeEnum.Medical:
        //            break;
        //        case BusinessTypeEnum.Factory:
        //            break;
        //        case BusinessTypeEnum.Carlot:
        //            break;
        //        default:
        //            break;
        //    }
        //    bus2.Add("Smith Bank", 200, "bank_2.jpg", BusinessTypeEnum.Financial);

        //    return busiess;
        //}
        private void LoadDefaultBadGuys(CityappEntity cityapp)
        {

            try
            {
                var badguys = from b in cityapp.Persons where b.PersonRole == PersonEnum.BadGuy select b;
                foreach (var guy in badguys)
                {
                    BadPersonEntity badperson = new BadPersonEntity();
                    badperson.Add(200, guy);
                    _view.AddBadguy(badperson);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

          
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
            SkiaMapper skiaMapper = new SkiaMapper(args, _mapPosition, VisualContentLoaded, _view);
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
                float xskia = (float)lot.x;
                float yskia = (float)lot.y;
                SKRect Lotskrect = new SKRect( xskia, yskia, xskia + Global.LotSizeNormal, yskia + Global.LotSizeNormal);

                canvas.DrawRect(Lotskrect, lotPaint);

            }

        }
        internal void Redraw()
        {

        }
    }
}
