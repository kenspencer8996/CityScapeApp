using CityScapeApp.Objects;
using CityScapeApp.Views.Controls.Person;

namespace CityScapeApp.Views.Controls.House;

public partial class HouseContent : ContentView
{
    public event EventHandler<BuildingOpenEventArgs> OnBuildingOpenContent;
    private string _houseName;
    private string _houseNameFirstCharacter;
    private string _appexpand = "appexpand.jpg";
    private string _appshrink = "appshrink.jpg";

    private string _houseImageName;
    private string _imageLivingFileName;
    private string _imageKitchenFileName;
    private string _imageGarageFileName;
    private string _currentExpndImage;
    private double _baseWidth;
    private double _baseHeight;

    public List<PersonEntity> Persons { get; set; }
    public HouseContent(string houseName,string houseImageFileName,
        string imageLivingFileName, string imageKitchenFileName, 
        string imageGarageFileName,
         int size)
    {
        InitializeComponent();
        
        _houseName = houseName;
        _houseNameFirstCharacter = _houseName;
        if (this.Width > 0)
            _baseWidth = this.Width;
        if (this.Height > 0)
            _baseHeight = this.Height;

        WidthRequest = size;
        HeightRequest = size;
        HouseNameLabel.Text = _houseNameFirstCharacter;
         _houseImageName = houseImageFileName;
        _houseName = houseName;
        _imageLivingFileName = imageLivingFileName;
        _imageKitchenFileName = imageKitchenFileName;
        _imageGarageFileName= imageGarageFileName;
        HouseImage.Source = _houseImageName;
        ExpandHouseImage.Source = _appexpand;
        _currentExpndImage = _appexpand;
        Persons = new List<PersonEntity>();
}
    private void ExpandButton_Clicked(object sender, EventArgs e)
    {
        if (this.Width > 0 && _baseWidth == 0)
            _baseWidth = this.Width;
        if (this.Height > 0 && _baseHeight == 0)
            _baseHeight = this.Height;

        if (_currentExpndImage == _appexpand)
            ExpandMe();
        else
            ShrinkMe();
    }
    private void ExpandMe()
    {
        //_currentExpndImage = _appshrink;
        ////ExpandHouseImage.Source = _currentExpndImage;
        //HouseNameLabel.Text= _houseName;
        //StreetNameLabel.IsVisible = true;
        ////this.ScaleTo(2);
        //this.HeightRequest += 200;
        //this.WidthRequest += 200;
    }
    private void ShrinkMe()
    {
        //_currentExpndImage = _appexpand;
        ////ExpandHouseImage.Source = _currentExpndImage;
        //HouseNameLabel.Text = _houseNameFirstCharacter;
        //StreetNameLabel.IsVisible = false;
        ////this.ScaleTo(1);
        //this.HeightRequest = _baseHeight;
        //this.WidthRequest = _baseWidth;

    }
    public string ImageLivingFileName
   {
        get { return _imageLivingFileName; }
    }
    public string ImageKitchenFileName
     {
        get { return _imageKitchenFileName; }
    }
    public string ImageGarageFileName
  {
        get { return _imageGarageFileName; }
    }
    public string HouseName
    {
        get { return _houseName; }
    }
    public string HouseImageName
    {
        get { return _houseImageName; }
    }
    internal void SetLot(LotEntity lot)
    {
        if (Global.ShowAllBordersIfAvailable)
        {
            //MainBorder.StrokeThickness = 2;
            StreetNameLabel.IsVisible = true;
            StreetNameLabel.Text = lot.StreetName;
        }
        if (lot.x == 0 ||  lot.y == 0)
            IsVisible = false;
        //else MainBorder.StrokeThickness = 0;
  
    }
    public void SetPerson(PersonContent person)
    {
        Persons.Add(person.Person);
        PersonStack.Children.Clear();
        PersonStack.Children.Add(person);
    
    } 
   
    public void RotateHouseImage(double degrees)
    {
        HouseImage.RotateTo(degrees);
    }
    public string GetHouseName()
    {
        return HouseNameLabel.Text;
    }
    void OnDragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.None;
    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        HouseContent person = (HouseContent)e.Data.Properties["person"];

    }

   

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        if (OnBuildingOpenContent != null)
        {
            BuildingOpenEventArgs buildingOpenEvent = new BuildingOpenEventArgs(this, BuldingTypeEnum.House);
            OnBuildingOpenContent(this, buildingOpenEvent);
        }
    }

    private void ExpandTap_Tapped(object sender, TappedEventArgs e)
    {
        if (_currentExpndImage == _appexpand)
            ExpandMe();
        else
            ShrinkMe();
    }
}
