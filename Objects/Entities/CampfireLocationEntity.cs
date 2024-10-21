using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class CampfireLocationEntity
    {
        public LocationXYEntity Location { get; set; } = new LocationXYEntity();
        public int CampfireSpotNumber { get; set; }
        public string RobberName { get; set; } = "";
        public int Degrees { get; set; }
    }
}
