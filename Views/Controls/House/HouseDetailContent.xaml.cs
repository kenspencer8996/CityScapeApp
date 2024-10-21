using CityScapeApp.Objects;
using CityScapeApp.Objects.Entities;
using CityScapeApp.Views.Controls.Car;
using CityScapeApp.Views.Controls.Person;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls;
using System;
using System.Runtime.CompilerServices;

namespace CityScapeApp.Views.Controls.House;

public partial class HouseDetailContent : ContentView
{
    public event EventHandler<LoadStreetsEventArgs> OnLoadStreetsEvent;

    private string _houseImageFileName;
    private string _imageLivingFileName;
    private string _imageKitchenFileName;
    private string _imageGarageFileName;
    private string _currentImage;
     public HouseDetailContent(string houseName,string houseImageFileName,
         string ImageLivingFileName, string ImageKitchenFileName, 
         string ImageGarageFileName)
    {
        InitializeComponent();
        _houseImageFileName = houseImageFileName;
        _imageLivingFileName = ImageLivingFileName;
        _imageKitchenFileName = ImageKitchenFileName;
        _imageGarageFileName = ImageGarageFileName;   

        HouseNameLabel.Text = houseName;

        SetImageSource( ImageLivingFileName);
        //if (Global.ShowAllBordersIfAvailable)
        //    MainBorder.StrokeThickness = 2;
        //else MainBorder.StrokeThickness = 0;
    }
    private void SetImageSource(string imageSource)
    {
        HouseDetailImage.Source = imageSource;
        _currentImage = imageSource;
    }
    public void SetPerson(PersonContent person)
    {
        PersonStack.Children.Clear();
        PersonStack.Children.Add(person);
    
    }
    public void SetCar(CarContent car)
    {
        CarStack.Children.Clear();
        CarStack.Children.Add(car);
    }
    void OnDragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.None;
    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        HouseContent person = (HouseContent)e.Data.Properties["person"];

    }

    private void ExpandButton_Clicked(object sender, EventArgs e)
    {
        this.ScaleTo(2, 2);
    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        switch (e.Direction)
        {
            case SwipeDirection.Left:
                if (_currentImage == _houseImageFileName)
                {
                    // SetImageSource(_imageLivingFileName);
                    //fire event
                    //FireLoadStreets();

                }
                else if (_currentImage == _imageLivingFileName)
                {
                    FireLoadStreets();
                    //SetImageSource(_houseImageFileName);
                    //fire event
                }
                else if (_currentImage == _imageKitchenFileName)
                {
                    SetImageSource(_imageLivingFileName);
                }
                else if (_currentImage == _imageGarageFileName)
                {
                    SetImageSource(_imageKitchenFileName);
                }
                break;
            case SwipeDirection.Right:
                if (_currentImage == _houseImageFileName)
                {
                    SetImageSource(_imageLivingFileName);

                }
                else if (_currentImage == _imageLivingFileName)
                {
                    SetImageSource(_imageKitchenFileName);
                }
                else if (_currentImage == _imageKitchenFileName)
                {
                    SetImageSource(_imageGarageFileName);
                }
                else if (_currentImage == _imageGarageFileName)
                {
                    SetImageSource(_imageLivingFileName);
                }
                break;
        }
   
       

   
    }
    private void FireLoadStreets()
    {
        if (OnLoadStreetsEvent != null)
        {
            LoadStreetsEventArgs buildingOpenEvent = 
                new LoadStreetsEventArgs();
            OnLoadStreetsEvent(this, buildingOpenEvent);
        }
    }
}