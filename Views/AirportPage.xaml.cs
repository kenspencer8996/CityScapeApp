using CityScapeApp.Viewmodels;

namespace CityScapeApp.Views;

public partial class AirportPage : ContentPage
{
    public AirportPage()
	{
		InitializeComponent();

        ShowOverview();

    }
    private string _currentImage = string.Empty;
    public AirportViewModel ViewModel { get; set; }
    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();

    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        
        switch (e.Direction)
        {
            case SwipeDirection.Left:
                if (_currentImage == ViewModel.AirportOverviewImage)
                    ShowLanding();
                else if (_currentImage == ViewModel.AirportRunwayLandingImage)
                    ShowTaxi();
                break;
            case SwipeDirection.Right:
                if (_currentImage == ViewModel.AirportRunwayTaxiingImage)
                    ShowLanding();
                else if (_currentImage == ViewModel.AirportRunwayLandingImage)
                    ShowOverview();
                    break;
            case SwipeDirection.Up:
                break;
            case SwipeDirection.Down:
                break;
        }
    }
    private void ShowOverview()
    {
        AirportImage.Source = ViewModel.AirportOverviewImage;
    }
    private void ShowLanding()
    {
        AirportImage.Source = ViewModel.AirportRunwayLandingImage;
    }
    private void ShowTaxi()
    {
        AirportImage.Source = ViewModel.AirportRunwayTaxiingImage;
    }
}