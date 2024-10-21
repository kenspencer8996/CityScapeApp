using CityScapeApp.Viewmodels;

namespace CityScapeApp.Views;

public partial class GaragePage : ContentPage
{
    public GaragePage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();

    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {

    }
    private void GoHome()
    {
        Navigation.PopToRootAsync();
    }
}