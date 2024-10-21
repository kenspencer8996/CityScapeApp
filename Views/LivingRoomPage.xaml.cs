using CityScapeApp.Objects;
using CityScapeApp.Viewmodels;

namespace CityScapeApp.Views;

public partial class LivingRoomPage : ContentPage
{
    LivingRoomPageViewmodel model;
    public LivingRoomPageViewmodel ViewModel
    {
        get
        {
            return model;
        }
        set
        {
            model = value;
            WidthRequest = model.widthofparent;
            HeightRequest = model.heightofparent;

            //HouseOwner.Text = model.LivingRoomImage;
            //BindingContext = model;
            RoomImage.Source = model.LivingRoomImage;
            SetGuitarLocation(model.LivingRoomImage);
            if (model.Person != null)
            {
                ThisPersonContent.Person = model.Person;
            }
            if (ThisPersonContent.Person != null && ThisPersonContent.Person.Name != "")
            {
                ThisPersonContent.SetPerson(ThisPersonContent.Person);
                SetPersonLocation(model.LivingRoomImage);
            }
            else
            {

            }

            Global.WriteDebugOutput("living room " + model.LivingRoomImage);
        }
    }
    private void SetGuitarLocation(string LivingRoomImage)
    {
         switch (LivingRoomImage)
        {
            case "living_5_room.jpg":
                Grid.SetRow(Guitarimage, 3);
                Grid.SetColumn(Guitarimage, 4);
                break;
            case "living_6_room.jpg":
                Grid.SetRow(Guitarimage, 3);
                Grid.SetColumn(Guitarimage, 4);
                break;
            case "living__7_room.jpg":
                Grid.SetRow(Guitarimage, 2);
                Grid.SetColumn(Guitarimage, 4);
                break;
            case "living_8_room.jpg":
                Grid.SetRow(Guitarimage, 3);
                Grid.SetColumn(Guitarimage, 4);
                break;
            case "living_9_room.jpg":
                Grid.SetRow(Guitarimage, 3);
                Grid.SetColumn(Guitarimage, 4);
                break;
            case "living_10_roomarmchair.png":
                Grid.SetRow(Guitarimage, 4);
                Grid.SetColumn(Guitarimage, 4);
                break;

            case "living_10_room.png":
                Grid.SetRow(Guitarimage, 3);
                Grid.SetColumn(Guitarimage, 4);
                break;
            case "living_11_room.png":
                Grid.SetRow(Guitarimage, 5);
                Grid.SetColumn(Guitarimage, 5);
                break;
            case "living_11_roombig.png":
                Grid.SetRow(Guitarimage, 5);
                Grid.SetColumn(Guitarimage, 5);
                break;
            case "living_12_room.png":
                Grid.SetRow(Guitarimage, 3);
                Grid.SetColumn(Guitarimage, 4);
                break;
            case "living_13_room.png":
                Grid.SetRow(Guitarimage, 3);
                Grid.SetColumn(Guitarimage, 4);
                break;
            default:
                break;
        }
    }
    private void SetPersonLocation(string LivingRoomImage)
    {
        switch (LivingRoomImage)
        {
            case "living_5_room.jpg":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 2);
                break;
            case "living_6_room.jpg":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 1);
                break;
            case "living__7_room.jpg":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 2);
                break;
            case "living_8_room.jpg":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 2);
                break;
            case "living_9_room.jpg":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 2);
                break;
            case "living_10_room.png":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 2);
                break;
            case "living_10_roomarmchair.png":
                ThisPersonContent.Margin = new Thickness(0, -20, 0, 0) ;
                Grid.SetRow(ThisPersonContent, 4);
                Grid.SetColumn(ThisPersonContent, 3);
                break;
            case "living_11_room.png":
                Grid.SetRow(ThisPersonContent, 5);
                Grid.SetColumn(ThisPersonContent, 3);
                break;
            case "living_11_roombig.png":
                Grid.SetRow(ThisPersonContent, 5);
                Grid.SetColumn(ThisPersonContent, 3);
                break;
            case "living_12_room.png":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 3);
                break;
            case "living_13_room.png":
                Grid.SetRow(ThisPersonContent, 3);
                Grid.SetColumn(ThisPersonContent, 3);
                break;
            default:
                break;
        }
    }
    public LivingRoomPage()
	{
		InitializeComponent();
        SizeChanged += LivingRoomPage_SizeChanged;

    }

    private void LivingRoomPage_SizeChanged(object? sender, EventArgs e)
     {
        Page thisPage = sender as Page;

        MainGrid.WidthRequest = thisPage.Width;
        MainGrid.HeightRequest = thisPage.Height;

        //TopRightLabel.Text ="W: " + Convert.ToString( MainGrid.Width);
        //BottomrightLabel.Text = "H: " + Convert.ToString(MainGrid.Height);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        GoHome();
    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        switch (e.Direction)
        {
            case SwipeDirection.Left:
                break;
            case SwipeDirection.Right:
                break;
            case SwipeDirection.Up:
                break;
            case SwipeDirection.Down:
                break;
        }
    }
    

    private void GoHome()
    {
        Navigation.PopToRootAsync();
    }
    private void GoKitchen()
    {
        var model = ServiceHelper.GetService<KitchenPageViewModel>();
        var page = ServiceHelper.GetService<KitchenPage>();
        model.House = ViewModel.House;
        page.ViewModel = model;
        Navigation.PushAsync(page);
    }

    private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
    {
        Guitarimage.IsVisible = false;
    }

    private void DropGestureRecognizer_DragOver(object sender, DragEventArgs e)
    {

    }

    private void DropGestureRecognizer_DragOver_1(object sender, DragEventArgs e)
    {
        Global.WriteDebugOutput("Drag over - living room");
    }
}