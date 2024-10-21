using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    internal class ImageDetailEntity
    {
        public string ImageFilename { get; set; }
        public string NamePart { get; set; } = string.Empty;
        public Int32 NumberPart { get; set; } = 0;
        public string TrailingPart { get; set; } = string.Empty;

        public ImageDetailEntity() { }

    }
}
