namespace CityScapeApp.Objects.Entities
{
    public class BadPersonImageEntity : EntityBase
    {
        public BadPersonImageEntity() 
        { 
        }
        private BadPersonTypeEnum _personImageType;
        
        private string _Name = "";

        private string _FilePath = "";

        private string _ImageType = ""; 
        public BadPersonTypeEnum PersonImageType
        {
            get 
            {
                return _personImageType;
            } 
            set 
            {
                _personImageType = value;
                OnPropertyChanged("PersonImageType");
            }
        }
        public string  Name
         {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
       public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
                OnPropertyChanged("FilePath");
            }
        }
        public string ImageType
        {
            get
            {
                return _ImageType;
            }
            set
            {
                _ImageType = value;
               // OnPropertyChanged("ImageType");
            }
        }
    }
}
