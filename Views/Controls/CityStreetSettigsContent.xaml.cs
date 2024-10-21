using CityScapeApp.Controllers;

namespace CityScapeApp.Views.Controls;

public partial class CityStreetSettigsContent : ContentView
{
    CityStreetSettigsContentController _controller;
    bool _isloading = true;
    public CityStreetSettigsContent()
    {
        InitializeComponent();
        Opacity = 0;
        _controller = new CityStreetSettigsContentController(this);
        CampFireTravelSpeedTimeentry.Text = Global.CampFire.ToString();
        CampFireSleepentry.Text = Global.CampFireSleepTime.ToString();
        travelSpeedentry.Text = Global.TravelSpeed.ToString();
        badguycountentry.Text = Global.BadguyCount.ToString();
        policecarspeedentry.Text = Global.PoliceCarSpeed.ToString();
        _isloading = false;
    }
    private void travelSpeedentry_Completed(object sender, EventArgs e)
    {
        if (_isloading == false)
        { 
            Global.TravelSpeed = Convert.ToInt32(travelSpeedentry.Text);
        }    
    }

    private void campfiresitentry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {
            Global.CampFire = Convert.ToInt32(CampFireTravelSpeedTimeentry.Text);
        }
    }

    private void campfiresitentry_Completed(object sender, EventArgs e)
    {
        Global.WriteDebugOutput("campfiresitentry_Completed complete next: if of isloading;");

        if (_isloading == false)
        {
            Global.CampFire = Convert.ToInt32(CampFireTravelSpeedTimeentry.Text);
        }
    }

    private void travelSpeedentry_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {

            Global.TravelSpeed = Convert.ToInt32(travelSpeedentry.Text);
        }
    }

    private void travelSpeedentry_Completed_1(object sender, EventArgs e)
    {

    }



    private void alarmentry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {
            Global.AlarmTime = Convert.ToInt32(alarmentry.Text);
        }
    }

    private void alarmentry_Completed(object sender, EventArgs e)
    {

    }

    private void badguycountentry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {

            Global.BadguyCount = Convert.ToInt32(badguycountentry.Text);
        }
    }

    private void badguycountentry_Completed(object sender, EventArgs e)
    {

    }

    private void policecarspeedentry_Completed(object sender, EventArgs e)
    {

    }

    private void policecarspeedentry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {

            Global.PoliceCarSpeed = Convert.ToInt32(policecarspeedentry.Text);
        }
    }

    private void policecarspeedentry_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void badguycountentry_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {
            Global.AlarmTime = Convert.ToInt32(alarmentry.Text);
        }
    }

    private void CampFireentry_TextChanged(object sender, TextChangedEventArgs e)
    {
     
    }

    private void travelSpeedentry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {
            Global.TravelSpeed = Convert.ToInt32(travelSpeedentry.Text);
        }
    }

    private void alarmentry_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {
            Global.AlarmTime = Convert.ToInt32(alarmentry.Text);
        }
    }


    private void PoliceCarSpeedentry_TextChanged_2(object sender, TextChangedEventArgs e)
    {

    }

    private void CampFireSleepTimeentry_TextChanged_1(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {

            Global.CampFireSleepTime = Convert.ToInt32(CampFireSleepentry.Text);
        }
    }

    private void CampFireTravelSpeedTimeentry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {

            Global.CampFireSleepTime = Convert.ToInt32(CampFireSleepentry.Text);
        }
    }

    private void CampFireSleepentry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isloading == false)
        {
            Global.CampFireSleepTime = Convert.ToInt32(CampFireSleepentry.Text);
        }
    }
}