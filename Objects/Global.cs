using CityScapeApp.Objects.database;
using CityScapeApp.Objects.Entities;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using System.Xml;

namespace CityScapeApp.Objects
{
 
    public static class Global
    {
        private static int _travelSpeed = -1;
        private static int _campfire = -1;
        private static int _campfireSleepTime = -1;
        private static int _policecarspeed = -1;
        private static int _badguycount = -1;
        private static int _alarmtime = -1;

        public static int TravelSpeed
        {
            set
            {
                _travelSpeed = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_travelSpeed == -1)
                {
                    ret = GetSettingByName("travelspeed");
                }
                return ret.IntSetting;
            }
        }
        public static int CampFire
        {
            set
            {
                _campfire = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_campfire == -1)
                {
                    ret = GetSettingByName("campfire");
                }
                return ret.IntSetting;
            }
        }
        public static int CampFireSleepTime
        {
            set
            {
                _campfireSleepTime = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_campfireSleepTime == -1)
                {
                    ret = GetSettingByName("campfiresleeptime");
                }
                return ret.IntSetting;
            }
        }
        public static int BadguyCount
        {
            set
            {
                _badguycount = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_badguycount == -1)
                {
                    ret = GetSettingByName("badguycount");
                }
                return ret.IntSetting;
            }
        }
        public static int PoliceCarSpeed
        {
            set
            {
                _policecarspeed = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_policecarspeed == -1)
                {
                    ret = GetSettingByName("policecarspeed");
                }
                return ret.IntSetting;
            }
        }
        public static int AlarmTime
        {
            set
            {
                _alarmtime = value;
            }
            get
            {
                SettingEntity ret = new SettingEntity();
                if (_alarmtime == -1)
                {
                    ret = GetSettingByName("aninationTime");
                }
                return ret.IntSetting;
            }
        }
        internal static SettingEntity GetSettingByName(string name)
        {
            SettingEntity setting = new SettingEntity();
            var found = from s in Settings where s.Name == name select s;
            if (found != null && found.Any())
            {
                setting = found.First();
            }
            if (setting.IntSetting == 0)
                setting.IntSetting = 1;

            return setting;
        }
       // public static uint AninationTime = 10000;
       

        public static PersonRepository PersonRepository;
        public static PersonImageImageRepository ImageRepository;
        public static BusinessRepository BusinessRepository;
        public static HouseRepository HouseRepository;
        public static PersonImageImageRepository PersonImageRepository;
        public static SettingsRepository SettingsRepository;
        public static bool ShowLotOutlines = true;
        private static string mainDir = FileSystem.Current.AppDataDirectory;
        private static string fileName = "cityappconfig.json";
        private static string configpath = System.IO.Path.Combine(mainDir, fileName);
        public static bool ShowAllBordersIfAvailable = true;
        public static string HouseStreets = "You St";
        public static string FinancialStreets = "Yodel Lane";
        public static string FactoryStreets = "Tea St";
        public static string GovStreets = "Mik Ave";
        public static string PoliceStreets = "You St";
        public static bool Loading = true;
        public static string Burglaralarmfile = "";
        public static LotEntity PoliceStationLocation {  get; set; }
        public static LocationXYEntity YouStStreetloc =new LocationXYEntity();
        public static LocationXYEntity MooDrStreetLoc = new LocationXYEntity();
        public static LocationXYEntity YodelLaneStreetLoc = new LocationXYEntity();
        public static LocationXYEntity TeaStStreetLoc = new LocationXYEntity();
        public static LocationXYEntity MikAveStreetLoc= new LocationXYEntity();
        public static LotEntity PoliceStationLot;

        public static CityAppMasterEntity CityAppMaster { get; set; } = new CityAppMasterEntity();
        private static CityappEntity cityapp = new CityappEntity();
        public static double screensizewidth;
        public static double screensizeheight;
        public static int buildingsize = 80;
        public static int BuildingLocationBuffer = 2;
        public static List<ObjectLocationPathEntity> PathsList = new List<ObjectLocationPathEntity>();
        public static List<ObjectLocationPathEntity> EscapePathsList = new List<ObjectLocationPathEntity>();
        public static int citybarn1x = 0;
        public static int citybarn1y = 0;
        public static int cityshed1x = 0;
        public static int cityshed1y = 0;
        public static int cityforest1x = 0;
        public static int cityforest1y = 0;
        public static int citybush1x = 0;
        public static int citybush1y = 0;
        public static int citybush2x = 0;
        public static int citybush2y = 0;
        public static int citytentx = 0;
        public static int citytenty = 0;

        public static int citybarn1Width;
        public static int citybarn1Height;
        public static int cityshed1Width;
        public static int cityshed1Height;
        public static int cityforestWidth ;
        public static int cityforestHeight ;
        public static int citybush1Width ;
        public static int citybush1Height ;
        public static int citybush2Width ;
        public static int citybush2Height ;
        public static bool OutputDebugging { get; set; } = true;
        public static void WriteDebugOutput(string message, [CallerMemberName] string callerMemberName = null)
        {
            if (OutputDebugging)
                System.Diagnostics.Debug.WriteLine(callerMemberName + ": " + message);

        }      
        //note on center calcs.
        //add 1/2 to x, subtrct 1/2 to y
        public static int cityforest1xCenter
        {
            get
            {
                int halfwidth = cityforestWidth / 2;
                return (cityforest1x + halfwidth + 150);            }
        }
        public static int cityforest1yCenter
        {
            get
            {
                int halfHeight = cityforestHeight / 2;
                int center = cityforest1y + halfHeight;
                center = center - 30;
                return (center);
            }
        }
        public static int citybarn1xCenter
        {
            get
            {
                int halfwidth = citybarn1Width / 2;
                return (citybarn1x + halfwidth);
            }
        }
        public static int citybarn1yCenter
        {
            get
            {
                int halfHeight = citybarn1Height;
                    int center = citybarn1y + halfHeight;
                center = center - 30;
                return (center);
            }
        }
        public static int cityshed1xCenter
        {
            get
            {
                int halfwidth = cityshed1Width / 2;
                return (cityshed1x + halfwidth);
            }
        }
        public static int cityshed1yCenter
        {
            get
            {
                int halfHeight = cityshed1Height;
                int center = cityshed1y + halfHeight;
                center = center - 30;
                return (center);
            }
        }
        public static int citybush1xCenter
        {
            get
            {
                int halfwidth = citybush1Width / 2;
                return (citybush1x + halfwidth);
            }
        }
        public static int citybush1yCenter
        {
            get
            {
                int halfHeight = citybush1Height / 2;
                return (citybush1y); //+ halfHeight);
            }

        }
        public static int citybush2xCenter
        {
            get
            { 
                int halfwidth = citybush2Width / 2;
                int center = citybush2x + halfwidth;
                center = center - 15;
                return (center);
            }
        }
        public static int citybush2yCenter
        {
            get
            {
                int halfHeight = citybush2Height / 2;
                int center = citybush2y + halfHeight;
                center = center - 35;
                return (center);
            }

        }
        internal static ObjectLocationSizeInfoEntity GetImageInfo(Image img)
        {
            ObjectLocationSizeInfoEntity info = new ObjectLocationSizeInfoEntity();
            int imgwidth = 0;
            if (img.Width > 0)
                imgwidth = Convert.ToInt32(img.Width);
            else
                imgwidth = Convert.ToInt32(img.WidthRequest);
            int imgheight = 0;
            if (img.Height > 0)
                imgheight = Convert.ToInt32(img.Height);
            else
                imgheight = Convert.ToInt32(img.HeightRequest);
            info.width = imgwidth; 
            info.height = imgheight;
            info.width = imgwidth;
            info.height = imgheight;

            return info;
        }
        internal static List<LotEntity> Lots { get; set; } = new List<LotEntity>();
        public static int StreetWidth = 30;
        public static int StreetTopOffset = 125;
        public static int StreetOuterOffset = 120;
        public static int LotSizeNormal = 100;
        public static DeviceIdiom CurrentDeviceIdiom;
        public static List<CampfireLocationEntity> CampfireSpots { get; set; } = new List<CampfireLocationEntity>();
        public static LocationXYEntity CampFireApproachN = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachNW = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachW = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachSW = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachS = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachSE = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachE = new LocationXYEntity();
        public static LocationXYEntity CampFireApproachNE = new LocationXYEntity();
        public static LocationXYEntity CampfireLocation { get; set; } = new LocationXYEntity();
        public static List<SettingEntity> Settings { get; set; } = new List<SettingEntity>();
        internal static List<ImageTypeEntity> HouseImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> VehicleSalesImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> RetailImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> FinancialImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> RoomImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> BadguyImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> PersonImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> VechileImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> CarlotImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> ClassroomImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> FactoryImageList { get; set; } = new List<ImageTypeEntity>();
        internal static List<ImageTypeEntity> GarageImageList { get; set; } = new List<ImageTypeEntity>();
        public static bool LogRuntimes { get; set; } = false;
        public static Logger Log;
        public static List<BusinessContent> Businesses = new List<BusinessContent>();
        public static SettingEntity GettingSetting(string settingName)
        {
            SettingEntity result = new SettingEntity();
            var settingfound = from s in Settings where s.Name == settingName select s;
            if (settingfound != null && settingfound.Any())
            {
                result = settingfound.FirstOrDefault();
            }
            return result;
        }
        private static void Addbusinessntity(
          string name, int payrate, BusinessTypeEnum businessType)
        {
            Random rand = new Random();
            BusinessEntity busiess = new BusinessEntity();
            ImageTypeEntity imageType = new ImageTypeEntity();
            int index;
            switch (businessType)
            {
                case BusinessTypeEnum.Government:
                    //int index = rand.Next(bus.Count);
                    //questions[index];
                    break;
                case BusinessTypeEnum.Retail:
                    index = rand.Next(Global.RetailImageList.Count);
                    if (index > -1 && Global.RetailImageList.Any())
                        imageType = Global.RetailImageList[index];
                    break;
                case BusinessTypeEnum.Financial:
                    index = rand.Next(Global.FinancialImageList.Count);
                    if (index > -1 && Global.FinancialImageList.Any())
                        imageType = Global.FinancialImageList[index];
                    break;
                case BusinessTypeEnum.Airport:
                    //index = rand.Next(RetailImages.Count);
                    //imageType = RetailImages[index];
                    break;
                case BusinessTypeEnum.Medical:
                    //index = rand.Next(RetailImages.Count);
                    //imageType = RetailImages[index];
                    break;
                case BusinessTypeEnum.Factory:
                    index = rand.Next(Global.FactoryImageList.Count);
                    if (index > -1 && Global.FactoryImageList.Any())
                        imageType = Global.FactoryImageList[index];
                    break;
                case BusinessTypeEnum.Carlot:
                    index = rand.Next(CarlotImageList.Count);
                    if (index > -1 && Global.CarlotImageList.Any())
                        imageType = Global.CarlotImageList[index];
                    break;
                default:
                    break;
            }
            busiess.Add(name, payrate, imageType.Name, businessType);
            cityapp.Businesses.Add(busiess);

        }
        private static void AddPersonEntity(string name, bool girl, PersonImageTypeEnum personImageType)
        {
            Random rand = new Random();
            PersonEntity person = new PersonEntity();
            PersonImageEntity personimage = new PersonImageEntity();
            int index;
            ImageTypeEntity image1 = new ImageTypeEntity();
            if (girl)
            {
                var foundGirls = from g in PersonImageList where g.Imagetype == ImageContentEnum.girl select g;
                index = rand.Next(foundGirls.Count());
                image1 = foundGirls.ElementAt(index);
            }
            else
            {
                if (personImageType != PersonImageTypeEnum.BadGuy)
                {
                }
                else
                {
                    var foundguys = from b in PersonImageList
                                    where b.Imagetype == ImageContentEnum.man
                                    select b;
                    index = 0;
                    index = rand.Next(foundguys.Count());
                    image1 = foundguys.ElementAt(index);
                }
            }
            personimage.Name = image1.Name.Replace(" ", "");
            personimage.FilePath = image1.Name;
            List<PersonImageEntity> personimages = new List<PersonImageEntity>();
            person.Add(name, 0, PersonEnum.Individual);
            cityapp.Persons.Add(person);
        }
        private static void AddBadPersonEntity(string name)
        {
            Random rand = new Random();
            BadPersonEntity person = new BadPersonEntity();
            // BadPersonImageEntity personimage = new BadPersonImageEntity();
            int index;
            ImageTypeEntity image1 = new ImageTypeEntity();
            var foundbadguys = from b in PersonImageList
                               where b.Imagetype == ImageContentEnum.badguy
                               select b;
            index = rand.Next(foundbadguys.Count());
            image1 = foundbadguys.ElementAt(index);
            //var foundbadguys = from b in cityapp.BadPersons where b.StartsWith("badguy") select b;
            //index = rand.Next(foundbadguys.Count());
            //image1 = foundbadguys.ElementAt(index);

        }


        public static int GetBuildingControlSize
        {
            get
            {
                int returnval = 120;
                if (CurrentDeviceIdiom == DeviceIdiom.Desktop)
                    returnval = 120;
                if (CurrentDeviceIdiom == DeviceIdiom.Tablet)
                    returnval = 100;
                if (CurrentDeviceIdiom == DeviceIdiom.Phone)
                    returnval = 80;


                return returnval;
            }
        }
        internal static void LoadCityApp()
        {
            if (System.IO.File.Exists(configpath))
            {
                string filecontents = System.IO.File.ReadAllText(configpath);
                CityAppMaster = JsonSerializerHelper.DeSerialize<CityAppMasterEntity>(filecontents);
            }
            else
            {
                CreateDefaultCityApp();
            }
        }

        internal static void SaveCityApp()
        {
            string filecontents = JsonSerializerHelper.Serialize<CityAppMasterEntity>(CityAppMaster);
            System.IO.File.WriteAllText(configpath, filecontents);
        }

        private static void CreateDefaultCityApp()
        {
            try
            {
                CityAppMaster = new CityAppMasterEntity();
                BusinessEntity busiess = new BusinessEntity();
                Addbusinessntity("4th 1st bank", 200, BusinessTypeEnum.Financial);
                Addbusinessntity("A bank", 210, BusinessTypeEnum.Financial);
                Addbusinessntity("My CU", 220, BusinessTypeEnum.Financial);

                Addbusinessntity("Iron W", 140, BusinessTypeEnum.Factory);
                Addbusinessntity("Smelter", 170, BusinessTypeEnum.Factory);
                Addbusinessntity("Hot Cars", 120, BusinessTypeEnum.Carlot);

                AddPersonEntity("Catori", true, PersonImageTypeEnum.Normal);
                AddPersonEntity("Frank", false, PersonImageTypeEnum.Normal);
                AddPersonEntity("Jim", false, PersonImageTypeEnum.Normal);
                AddPersonEntity("Bob", false, PersonImageTypeEnum.Normal);

                ReloadBadGuys();
               


                CityAppMaster.AddCityapp(cityapp);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void ReloadBadGuys()
        {
            //AddBadPersonEntity("Joesmo");
            //if (badguycount >= 2)
            //    AddBadPersonEntity("SamSlick");
            //if (badguycount >= 3)
            //    AddBadPersonEntity("Bobbad");
            //if (badguycount >= 4)
            //    AddBadPersonEntity("SlickJim");
        }
        public static void UpdateUISettings()
        {
            Global.InsertSetting("travelspeed", "", TravelSpeed);
            Global.InsertSetting("campfire", "", CampFire);
            Global.InsertSetting("badguycount", "", BadguyCount);
            Global.InsertSetting("policecarspeed", "", PoliceCarSpeed);
        }
        public static void LoadSettings()
        {
            Global.Settings = Global.SettingsRepository.GetSetting();
        }
        public static void InsertHouse(string name, string imagenme, string living, string kitchen, string garage, bool isUserHouse, string OwnerName)
        {
            HouseEntity house1 = new HouseEntity(name, imagenme, living, kitchen, garage, OwnerName, isUserHouse);
            HouseRepository.UpsertHouse(house1);

        }
        public static void InsertSetting(string name, string stringSetting, int intSetting)
        {
            SettingEntity setting = new SettingEntity(name, stringSetting, intSetting);
            SettingsRepository.UpsertSetting(setting);
        }
        public static void InsertBusiness(string name, decimal payrate,
            string imagenme, BusinessTypeEnum businessType)
        {
            BusinessEntity bus1 = new BusinessEntity();
            bus1.Add(name, payrate, imagenme, businessType);
            BusinessRepository.UpsertBusiness(bus1);

        }
        public static async Task<PersonEntity> InsertPersonAsync(string name,
            bool isUser, PersonEnum personRole,string currentImage)
        {
            PersonEntity personEntity = new PersonEntity();
            personEntity.Name = name;
            personEntity.IsUser = false;
            personEntity.PersonRole = personRole;
            personEntity.CurrentImage = currentImage;
            PersonEntity newpersonEntity = await PersonRepository.UpsertPerson(personEntity);

            return newpersonEntity;
        }
        public static void InsertPersonImage(string Name, PersonImageTypeEnum personImageType, PersonImageStatusEnum PersonImageStatus,
         string FilePath, string ImageType,
         int fkpersonId)
        {
            PersonImageEntity image1 = new PersonImageEntity();
            image1.Add(Name, personImageType, PersonImageStatus,
            FilePath, ImageType, fkpersonId);
            ImageRepository.UpsertPersonImage(image1);
        }
        public static void Addbadguypaths()
        {
             ObjectLocationPathEntity paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Barn1);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);
            PathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.ForestCenter); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter);

        }
        public static void AddbadguyEscapepaths()
        {
            ObjectLocationPathEntity paths = new ObjectLocationPathEntity();

            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.BusinessCenter); paths.Add(LocationEnum.Shed1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);
            EscapePathsList.Add(paths);
            paths = new ObjectLocationPathEntity();
            paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.CampFire); paths.Add(LocationEnum.Bush2Center); paths.Add(LocationEnum.Barn1); paths.Add(LocationEnum.CampFire);

        }
    }
    }
