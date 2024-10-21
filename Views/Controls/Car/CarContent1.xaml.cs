using CityScapeApp.Objects;
using System;

namespace CityScapeApp.Views.Controls.Car;

public partial class CarContent : ContentView
{
    public event EventHandler<careventArg> CarBoughtEvent;
    public CarContent(string carName,string carImageFileName,string carCost)
    {
        InitializeComponent();
        CarNameLabel.Text = carName;
        CarImage.Source = carImageFileName;
        CarCostLabel.Text = carCost;

    }

    private void BuyButtxon_Clicked(object sender, EventArgs e)
    {
        careventArg car = new careventArg(this);                 
        CarBoughtEvent(e, car);
    }
}