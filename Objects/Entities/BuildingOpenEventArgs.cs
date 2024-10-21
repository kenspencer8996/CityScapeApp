using CityScapeApp.Views.Controls.Business;
using CityScapeApp.Views.Controls.House;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class BuildingOpenEventArgs : EventArgs
    {
        public HouseContent House { get; set; }
        public BusinessContent Business { get; set; }
        public BuldingTypeEnum BuldingType { get; set; }
        public BuildingOpenEventArgs(ContentView contentView, BuldingTypeEnum buldingType) 
        {
            BuldingType = buldingType;
            switch (buldingType ) 
            { 
                case BuldingTypeEnum.House:
                    House = (HouseContent)contentView;
                    break;
                case BuldingTypeEnum.Factory:
                    Business = (BusinessContent)contentView;
                    break;
                case BuldingTypeEnum.Bank:
                    Business = (BusinessContent)contentView;
                    break;
                case BuldingTypeEnum.CarLot:
                    Business = (BusinessContent)contentView;
                    break;
                case BuldingTypeEnum.Retail:
                    Business = (BusinessContent)contentView;
                    break;
            }
        }
    }
}
