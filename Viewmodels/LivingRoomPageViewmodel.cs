using CityScapeApp.Views.Controls.House;

namespace CityScapeApp.Viewmodels
{
    public partial class LivingRoomPageViewmodel:BaseViewModel
    {
       public HouseContent House { get; set; }
        public double widthofparent;
        public double heightofparent;
        public PersonEntity Person 
        { get
            {
                if (House.Persons != null && House.Persons.Any())
                    return House.Persons[0];
                else 
                    return new PersonEntity();
            }
        }
        public string LivingRoomImage
        {
            get
            {
                return House.ImageLivingFileName;
            }
        }
        public LivingRoomPageViewmodel()
        {

        }
         
    }
}
