using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    internal class MapPositionEntity
    {
        private double SkiaToAbsolute = .78;

        public int StreetTopSkia = 125;
        public int StreetBottomYSkia;
        public int LeftStreetInnerSkia;
        public int RightStreetOuterXSkia;
        public int RightStreetInnerXSkia;
        public int MidStreetTopRightSkia;
        public int MidStreetInnerXSkia;
        public int TeaStreetOuterXMaui
       {
            get
            {
                return GetMauiFromSKiaPosition(RightStreetOuterXSkia);
            }
        }
        public int TeaStreetInnerXMaui
        {
            get
            {
                return GetMauiFromSKiaPosition(RightStreetInnerXSkia);
            }
        }

        public int rightStreetouterSkia;
        public int MooStreetLeftXSkia;
        public int MidStreetToprightSkia;
        public int YouStreetStartSkia;
        public int YouStreetEndSkia;
        public int TeeaStreetStartSkia;
        public int TeaStreetEndSkia;
        public int yeaStreetEndSkia;
        public int MikStreetStartSkia;
        public int MikStreetEndSkia;
        public int YodelStreetStartSkia;
        public int YodelStreetEndSkia;
        public int MooooStreetStartSkia;
        public int MooooStreetEndSkia;
        public int TreeStreetStartSkia;
        public int TreeStreetEndSkia;
        public int BeeStreetStartSkia;
        public int MeeStreetEndSkia;
        public int MoneyStreetStartSkia;
        public int MoneyStreetEndSkia;
        public int MooStreetLeftXMaui
        {
            get
            {
                return GetMauiFromSKiaPosition(MooStreetLeftXSkia);
            }
        }

        public int MidStreetTopLeftMaui
        {
            get
            {
                return GetMauiFromSKiaPosition(MooStreetLeftXSkia);
            }
        }
        public int YodelStreetInnerMaui
        {
            get
            {
                return GetMauiFromSKiaPosition(LeftStreetInnerSkia);
            }
        }
        public int TeaStreetOuterMaui
           {
            get
            {
                return GetMauiFromSKiaPosition(rightStreetouterSkia);
            }
        }
        public int MooStreetTopLeftMaui
            {
            get
            {
                return GetMauiFromSKiaPosition(MooStreetLeftXSkia);
            }
        }
        public int MooStreetTopRightMaui
           {
            get
            {
                return GetMauiFromSKiaPosition(MidStreetToprightSkia);
            }
        }
        public int YouStreetStartMaui
          {
            get
            {
                return GetMauiFromSKiaPosition(YouStreetStartSkia);
            }
        }
        public int YouStreetEndMaui
          {
            get
            {
                return GetMauiFromSKiaPosition(YouStreetEndSkia);
            }
        }
        public int TeaStreetStartMaui
             {
            get
            {
                return GetMauiFromSKiaPosition(TeeaStreetStartSkia);
            }
        }
        public int TeaStreetEndMaui
             {
            get
            {
                return GetMauiFromSKiaPosition(TeaStreetEndSkia);
            }
        }
        public int MikStreetStartMaui
        {
            get
            {
                return GetMauiFromSKiaPosition(MikStreetStartSkia);
            }
        }
        public int MikStreetEndMaui
               {
            get
            {
                return GetMauiFromSKiaPosition(MikStreetEndSkia);
            }
        }
        public int YodelStreetStartMaui
               {
            get
            {
                return GetMauiFromSKiaPosition(YodelStreetStartSkia);
            }
        }
        public int YodelStreetEndMaui
               {
            get
            {
                return GetMauiFromSKiaPosition(YodelStreetEndSkia);
            }
        }
        public int MooooStreetStartMau
               {
            get
            {
                return GetMauiFromSKiaPosition(MooooStreetStartSkia);
            }
        }
        public int MooooStreetEndMaui
            {
            get
            {
                return GetMauiFromSKiaPosition(MooooStreetEndSkia);
            }
        }
        public int TreeStreetStartMaui
              {
            get
            {
                return GetMauiFromSKiaPosition(TreeStreetStartSkia);
            }
        }
        public int TreeStreetEndMaui
              {
            get
            {
                return GetMauiFromSKiaPosition(TreeStreetEndSkia);
            }
        }
        public int BeeStreetStartMaui
            {
            get
            {
                return GetMauiFromSKiaPosition(BeeStreetStartSkia);
            }
        }
        public int BeeStreetEndMaui
           {
            get
            {
                return GetMauiFromSKiaPosition(BeeStreetEndMaui);
            }
        }
        public int MoneyStreetStartMaui
          {
            get
            {
                return GetMauiFromSKiaPosition(MoneyStreetStartSkia);
            }
        }
        public int MoneyStreetEndMaui
        {
            get
            {
                return GetMauiFromSKiaPosition(MooooStreetEndSkia);
            }
        }


        internal int MidStreetInnerXMaui
        {
        get 
            {
                return GetMauiFromSKiaPosition(MidStreetInnerXSkia);
            }
        } 
        internal int StreetTopMaui
        {
        get 
            {
                return GetMauiFromSKiaPosition(StreetTopSkia);
            }
        }
        internal int StreetBottomMaui
         {
            get
            {
                return GetMauiFromSKiaPosition(StreetBottomYSkia);
            }
        }
       
        internal int RightStreetInnerMaui
             {
            get
            {
                return GetMauiFromSKiaPosition(RightStreetInnerXSkia);
            }
        }
 
        internal List<LotEntity> MapLocations = new List<LotEntity>();
        internal int GetMauiFromSKiaPosition(int xskiaValue)
        {
            int returnval = 0;
            if (xskiaValue > 0)
                returnval = Convert.ToInt32(xskiaValue * SkiaToAbsolute);
            return returnval;
        }
    }
}
