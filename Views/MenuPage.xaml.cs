using CityScapeApp.Objects;
using CityScapeApp.Viewmodels;

namespace CityScapeApp.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}

    private void HomeButton_Clicked(object sender, EventArgs e)
    {
       // App.NavigateToHomePage();
    }

    private void AirportButton_Clicked(object sender, EventArgs e)
    {
        var model = ServiceHelper.GetService<AirportViewModel>();
        var page = ServiceHelper.GetService<AirportPage>();
        page.ViewModel = model;
        Navigation.PushAsync(page);
    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {
        //var model = ServiceHelper.GetService<LivingRoomPageViewmodel>();
        //var page = ServiceHelper.GetService<LivingRoomPage>();
        //model.House = house;
        //page.ViewModel = model;
        //Navigation.PushAsync(page);
    }

    private void PersonsButton_Clicked(object sender, EventArgs e)
    {

    }

    private void BusinessesButton_Clicked(object sender, EventArgs e)
    {

    }

    private void HousesButton_Clicked(object sender, EventArgs e)
    {

    }
}