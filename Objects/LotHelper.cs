using CityScapeApp.Objects.Entities;
using CityScapeApp.Views;
using CityScapeApp.Views.Controls.Business;

namespace CityScapeApp.Objects
{
    public  class LotHelper
    {
        public LotHelper(CityscapeStreets view) 
        {
            _view = view;
        }
        public  int testrect1y = 200;
        public  int testrect2y = 300;
        public  int testrect3y = 400;
        CityscapeStreets _view;
        public  int  LotCounter = 1;
 
        private MapPositionEntity _mapPosition;
        internal  void CreateStreetLotInfo(
            double CityCanvasWidth,double CityCanvasHeight,
            MapPositionEntity mapPosition)
        {

            _mapPosition = mapPosition;
            int LotCounter = 1;
            int MiksstreetBottomMaui = _mapPosition.StreetBottomMaui;
            int Yodelstreetinner = Global.StreetOuterOffset + Global.StreetWidth;
            int Teastreetouter = _mapPosition.TeaStreetInnerXMaui;
            Teastreetouter = Teastreetouter - Global.StreetWidth;
            int moostreettopleft = _mapPosition.MooStreetTopLeftMaui;
            int moostreettopright = moostreettopleft + Global.StreetWidth;


            int YouStreetStart = Global.StreetOuterOffset;//top street
            int YouStreetEnd = Teastreetouter;
            int TeaStreetStart = _mapPosition.StreetTopMaui + Global.StreetWidth;//right street
            int TeaStreetEnd = MiksstreetBottomMaui;
            int MikStreetStart = Teastreetouter;//bottom street
            int MikStreetEnd = TeaStreetStart;
            int YodelStreetStart = MiksstreetBottomMaui;//keft street
            int YodelStreetEnd = _mapPosition.StreetTopMaui;
            int MooooStreetStart = _mapPosition.StreetTopMaui; //middle street
            int MooooStreetEnd = MiksstreetBottomMaui;


            int TreeStreetStart = Global.StreetOuterOffset;
            int TreeStreetEnd = Teastreetouter;
            int BeeStreetStart = Global.StreetOuterOffset;
            int MoneyStreetStart = Global.StreetOuterOffset;
            int MoneyStreetEnd = Teastreetouter;

            int YouStreetLength = Teastreetouter - Global.StreetOuterOffset;
            int YouMikInnerLeftStreetLength = _mapPosition.MidStreetTopLeftMaui;
            int YouMikInnerRightStreetLength = _mapPosition.TeaStreetInnerXMaui - (_mapPosition.MooStreetLeftXMaui+ Global.StreetWidth);
            int TeaStreetLength = TeaStreetEnd - TeaStreetStart;
            int YodelStreetLength = YodelStreetStart - YodelStreetEnd;
            int MooooStreetLength = MooooStreetEnd - MooooStreetStart;
            int TreeStreetLength = TreeStreetEnd - TreeStreetStart;
           // int BeeStreetLength = BeeStreetEnd - BeeStreetStart;
            int MoneyStreetLength = MoneyStreetEnd - MoneyStreetStart;
            int MikStreetLength = Teastreetouter - Global.StreetOuterOffset;

            int YouStreetNormalLotCount = YouStreetLength / Global.LotSizeNormal-2;
            int TeaStreetNormalLotCount = TeaStreetLength / Global.LotSizeNormal;
            int YodelStreetNormalLotCount = YodelStreetLength / Global.LotSizeNormal;
            int MooooStreetNormalLotCount = MooooStreetLength / Global.LotSizeNormal;
            MooooStreetNormalLotCount -= 1;//drop count by 1 to shorten house lots
            int TreeStreetNormalLotCount = TreeStreetLength / Global.LotSizeNormal;

            //not used yet
            //int BeeStreetNormalLotCount = BeeStreetLength / Global.LotSizeNormal;
            int MoneyStreetNormalLotCount = MoneyStreetLength / Global.LotSizeNormal;
            int MikStreetNormalLotCount = MikStreetLength / Global.LotSizeNormal;

            //calc small norm large size
            Global.Lots.Clear();
            //-------------- top street ------------------ upper
            int yVal = _mapPosition.StreetTopMaui - (Global.LotSizeNormal - (Global.BuildingLocationBuffer)) + Global.StreetWidth - 15;
            int lotLocationCounter = Global.StreetOuterOffset;
            int youandMikStreetNormalLeftLotCount = (YouMikInnerLeftStreetLength / Global.LotSizeNormal) -1;
            int youandMikStreetNormalRightLotCount = YouMikInnerRightStreetLength / Global.LotSizeNormal;
            int youandmikrightx = YouMikInnerLeftStreetLength + Global.StreetWidth;
            CalculateLots("You St", lotLocationCounter, 
                yVal ,
                YouStreetNormalLotCount, YouStreetLength,0,
                lotLocationCounter, 0, true, LotPositionEnum.TopSide);
            int youlabely = yVal - (Global.StreetWidth / 2) -5;
            AddLabels("You St", lotLocationCounter, youlabely, YouStreetLength);
            yVal +=  Global.LotSizeNormal+Global.BuildingLocationBuffer + 8;

            CalculateLots("You St", lotLocationCounter,
                yVal,
                youandMikStreetNormalLeftLotCount, YouMikInnerLeftStreetLength, 0,
                lotLocationCounter, 180, true, LotPositionEnum.BottomSide);
            //CalculateLots("You St", youandmikrightx,
            //    yVal,
            //    youandMikStreetNormalRightLotCount, YouMikInnerRightStreetLength, 0,
            //    lotLocationCounter, 180, true);

            lotLocationCounter = _mapPosition.StreetTopMaui;
            // int tealeftlotx = Global.StreetOuterOffset - (Global.LotSizeNormal + Global.BuildingLocationBuffer);
            int tealeftlotx = Teastreetouter-15;
            int tealoty = _mapPosition.StreetTopMaui + Global.StreetWidth + Global.LotSizeNormal;

            CalculateLots("Tea St", tealeftlotx, tealoty, TeaStreetNormalLotCount - 3, TeaStreetLength, Global.StreetOuterOffset - 25, lotLocationCounter, 270, false, LotPositionEnum.LeftSide);
            int tealabelx = tealeftlotx +55;
            AddLabels("Tea St", tealabelx, tealoty, TeaStreetLength);

            int tearightlotx = Global.StreetOuterOffset;
             CalculateLots("Tea St", tearightlotx, tealoty, TeaStreetNormalLotCount, TeaStreetLength, Global.StreetOuterOffset - 25, lotLocationCounter, 90, false, LotPositionEnum.RightSide);
 
            //-------------- bottom street ------------------ lower
            lotLocationCounter = Global.StreetOuterOffset;
            int mikloty = _mapPosition.StreetBottomMaui - Global.LotSizeNormal +25;
            int miklotx = lotLocationCounter + Global.StreetWidth;
            AddLabels("Mik Ave", miklotx, mikloty +45, MikStreetLength);
            CalculateLots("Mik Ave", miklotx, mikloty, youandMikStreetNormalLeftLotCount,
                YouMikInnerLeftStreetLength,
                Global.StreetOuterOffset - 25, lotLocationCounter, 0, true, LotPositionEnum.LeftSide);
            miklotx = (moostreettopleft - 5) + Global.StreetWidth;
            mikloty = mikloty + Global.StreetWidth;
           
            lotLocationCounter = _mapPosition.StreetTopMaui;       
            int yodelleftlotx = Global.StreetOuterOffset ;
            int yodelleftloty = (_mapPosition.StreetTopMaui + _mapPosition.YodelStreetStartMaui)/2;
            int yodellabelx = yodelleftlotx;
            
            //CalculateLots("Yodel Lane",  yodelleftlotx, yodelleftloty, YodelStreetNormalLotCount, YodelStreetLength,
            //    Global.StreetOuterOffset - 25, lotLocationCounter-2, 270, false,   LotPositionEnum.LeftSide);
            AddLabels("Yodel Lane", yodellabelx, yodelleftloty, YodelStreetLength);

            int yodelrightlotx = Global.StreetOuterOffset ;
            int yodelrightloty = _mapPosition.StreetTopMaui + Global.StreetWidth + Global.LotSizeNormal;
            CalculateLots("Yodel Lane", yodelleftlotx, yodelrightloty, YodelStreetNormalLotCount, YodelStreetLength, Global.StreetOuterOffset - 25, lotLocationCounter, 90, false, LotPositionEnum.LeftSide);

            lotLocationCounter = _mapPosition.StreetTopMaui;
            int moox = moostreettopleft - (Global.LotSizeNormal) + 30;
            int mooy = lotLocationCounter + Global.LotSizeNormal + Global.StreetWidth;
            int labelmoox = moostreettopleft - Global.LotSizeNormal;
            AddLabels("Moo Dr", labelmoox, mooy, MooooStreetLength);
           // CalculateLots("Moo Dr",  moox, mooy, MooooStreetNormalLotCount, MooooStreetLength, MooooStreetLength / 2, lotLocationCounter, 90, false);
            moox = moox  + Global.LotSizeNormal + Global.BuildingLocationBuffer;
            CalculateLots("Moo Dr", moox, mooy + Global.BuildingLocationBuffer, MooooStreetNormalLotCount-3, MooooStreetLength, MooooStreetLength / 2, lotLocationCounter, 90, false, LotPositionEnum.RightSide);
            foreach (var aLot in Global.Lots)
            {
                string message = "";
                message = "Street " + aLot.StreetName + "  ";
                message += "position " + aLot.x  + " " + aLot.y + "  ";
              }
        }

        private  void CalculateLots(string streetName, 
            int x, int y, int totallots, int streetlength, int streety,
             int lotLocationCounter, int angle,bool horizontal, LotPositionEnum lotPosition)
        {
            int starty = y;
            int endy = y + streetlength;
             for (int i = 0; i < totallots; i++)
            {
                LotEntity lot = new LotEntity();
                lot.lotPosition = lotPosition;
                lot.LotSize = LotSizeEnum.Normal;
                //lot.SetKiaPositionxy(x, y);
                lot.FrontFaceDegrees = angle;
                lot.StreetName = streetName;
                lot.LotNumber = LotCounter;
                if (horizontal && i == 0) //set counter base when i=0
                    lotLocationCounter = x;
                if (horizontal == false && i == 0) //set counter base when i=0
                    lotLocationCounter = y;
                lotLocationCounter += Global.LotSizeNormal;
                lot.y = y;
                lot.x = x;
                int endlotposition;
                if (horizontal)
                {
                    endlotposition = x + Global.LotSizeNormal;
                    x = lotLocationCounter;
                }
                else
                {
                    y = lotLocationCounter;
                    endlotposition = y + Global.LotSizeNormal;
                }
                 
                if (endlotposition < endy)
                    Global.Lots.Add(lot);
                LotCounter++; 
             }
        }
        private  void AddLabels(string streetName, int x, int y, int StreetLength)
        {
            x = _mapPosition.GetMauiFromSKiaPosition(x) ;
            y = _mapPosition.GetMauiFromSKiaPosition(y);

            switch (streetName)
            {
                case "You St":
                    int yyou = y + Global.LotSizeNormal;

                    _view.AddYouStreetLabel(StreetLength /2, yyou);
                    break;
                case "Moo Dr":
                    int xmoo = x  + Global.StreetWidth + 140;
                    int ymoo = (StreetLength / 2) + 50;
                    _view.AddMooDrLaneLabel(xmoo, ymoo);
                    break;
                case "Tea St":
                    int xtea = x +225;
                    int ytea = y + 100;
                    _view.AddTeaStreetLabel(xtea, ytea);
                    break;
                case "Yodel Lane":
                    int xyodel = 70; // + Global.LotSizeNormal - 20;
                    _view.AddYodelLaneLabel(xyodel, 220);
                    break; 
                case "Mik Ave":
                    int xmik = x +(StreetLength/2);
                    int miky = y + Global.StreetWidth / 2 + Global.LotSizeNormal + 20;
                    _view.AddMikStreetLabel(xmik, miky);
                    break;
            }
        }
    }
}
