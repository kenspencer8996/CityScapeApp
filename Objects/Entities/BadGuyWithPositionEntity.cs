using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    public class BadGuyWithPositionEntity
    {
        CampfireLocationEntity _campfireLocation;
        public BadPersonnContent BadPerson { get; set; }
        public LocationXYEntity lastlocationXY = new LocationXYEntity();
        public LocationXYEntity nextlocationXY = new LocationXYEntity();
        public CampfireLocationEntity CampfireLocation 
        { 
            get
            {
                return _campfireLocation;
            }
            set
            {
                _campfireLocation = value;
                _campfireLocation.RobberName = BadPerson.BadPerson.BadPerson.Name;
            }
        }
        public List<int> CampFirePath = new List<int>();
    }
}
