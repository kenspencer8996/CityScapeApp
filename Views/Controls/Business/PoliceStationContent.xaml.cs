using CommunityToolkit.Mvvm.Messaging;
using Plugin.Maui.Audio;

namespace CityScapeApp.Views.Controls.Business;

public partial class PoliceStationContent : ContentView
{
    IAudioManager _AudioManager;
    public PoliceStationContent()
    {
        InitializeComponent();
        _AudioManager = new AudioManager();
        PoliceStationImage.Source = "policestation.png";
        WeakReferenceMessenger.Default.Register<PersonMessage>(this, (r, m) =>
        {
            System.Diagnostics.Debug.WriteLine("Playing sound");
            mediaElement.Play();
        });
    }
    public void SetPerson(PersonContent person)
    {
        //PersonStack.Children.Clear();
        //PersonStack.Children.Add(person);

    }

    void OnDragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.Copy;
    }
    public string BusinesName
    {
        get { return _BusinesName; }
    }
    public string BusinesImageName
    {
        get { return _BusinesImageName; }
    }
    public void RotateBusinessImage(double degrees)
    {
        BusinessImage.RotateTo(degrees);
    }
    internal LotEntity Lot { get; set; }
    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        string name = (string)e.Data.Properties["Person"];
        var citiesFromq = from c in Global.CityAppMaster.CityApp
                          where
                        c.CityAppNumber == Global.CityAppMaster.CurrentCityAppNumber
                          select c;
    }

    private void ContentView_Unloaded(object sender, EventArgs e)
    {
    }

    private void mediaElement_StateChanged(object sender, CommunityToolkit.Maui.Core.Primitives.MediaStateChangedEventArgs e)
    {
        switch (e)
        {
             default:
                break;
        }
    }
}