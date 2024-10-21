using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CityScapeApp.Objects.Entities
{
    public class SettingEntity
    {
        public SettingEntity() { }
        public SettingEntity(string name,string stringSetting, int intSetting) 
        {
            Name = name;
            StringSetting = stringSetting;
            IntSetting = intSetting;
        }

        public int SettingID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StringSetting { get; set; } = string.Empty;
        public int IntSetting { get; set; } = 0;
    }
}
