using CityScapeApp.Objects.Entities;
using System.Xml.Linq;

namespace CityScapeApp.Objects
{
    internal class ResourceHelperWin
    {
         public static void GetImagesAndLoadGlobalLists()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string[] strings = System.IO.Directory.GetFiles(path);
            foreach (string filenamewpath in strings)
            {
                try
                {

                    ImageTypeEntity imageType = new ImageTypeEntity();  
                    string filename = System.IO.Path.GetFileName(filenamewpath);
                    string[] parts = filename.Split('_');
                    string ext = System.IO.Path.GetExtension(filenamewpath);    
                    if (parts.Length > 1 
                        && filename.StartsWith("appicon") == false
                        && (ext == "svg" || ext == "png"))
                    {
                        imageType.Name = filename;
                        imageType.number = Convert.ToInt32( parts[1]);
                        if (parts.Length > 2 )
                            imageType.lastpart = parts[2];
                        if (filename.StartsWith("auto"))
                        {
                            imageType.Imagetype = ImageContentEnum.vehicle;
                            Global.VechileImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("badguy"))
                        {
                            imageType.Imagetype = ImageContentEnum.badguy;
                            Global.BadguyImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("bank"))
                        {
                            imageType.Imagetype = ImageContentEnum.bank;
                            Global.FinancialImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("carlot"))
                        {
                            imageType.Imagetype = ImageContentEnum.carlot;
                            Global.CarlotImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("classroom"))
                        {
                            imageType.Imagetype = ImageContentEnum.carlot;
                            Global.ClassroomImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("factory"))
                        {
                            imageType.Imagetype = ImageContentEnum.factory;
                            Global.FactoryImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("garage"))
                        {
                            imageType.Imagetype = ImageContentEnum.garage;
                            Global.GarageImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("girl"))
                        {
                            imageType.Imagetype = ImageContentEnum.girl;
                            Global.PersonImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("house"))
                        {
                            imageType.Imagetype = ImageContentEnum.house;
                            Global.HouseImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("kitchen"))
                        {
                            imageType.Imagetype = ImageContentEnum.room;
                            Global.RoomImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("living"))
                        {
                            imageType.Imagetype = ImageContentEnum.carlot;
                            Global.RoomImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("man"))
                        {
                            imageType.Imagetype = ImageContentEnum.man;
                            Global.PersonImageList.Add(imageType);
                        }
                        else if (filename.StartsWith("pet"))
                        {
                            imageType.Imagetype = ImageContentEnum.store;
                            Global.RetailImageList.Add(imageType);
                        }



                    }
                }
                catch (Exception ex)
                {

                }

            }
        }

    }
}
