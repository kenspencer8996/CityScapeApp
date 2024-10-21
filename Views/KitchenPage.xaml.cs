using CityScapeApp.Viewmodels;

namespace CityScapeApp.Views;

public partial class KitchenPage : ContentPage
{
    KitchenPageViewModel _viewModel;
    public KitchenPageViewModel ViewModel 
    { 
        get
        {  return _viewModel; }
        set
        {
            _viewModel = value;
            BindingContext = _viewModel;
        }
    } 
    public KitchenPage()
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