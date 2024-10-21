using CityScapeApp.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects
{
    internal class ResourceHelper
    {
        public static void GetImages() 
        {

#if ANDROID
           
#elif IOS
         // results =  ResourceHelperIOS.GetImages();
#elif WINDOWS
         //  ResourceHelperWin.GetImagesAndLoadGlobalLists();
#endif
            
        }

    }
}
