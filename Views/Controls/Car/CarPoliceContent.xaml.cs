using CityScapeApp.Controllers;
using CityScapeApp.Objects;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Security.Cryptography.X509Certificates;

namespace CityScapeApp.Views.Controls.Car;

public partial class CarPoliceContent : ContentView
{
    PoliceCarMoveFiredEventArg arg;
    public event EventHandler<PoliceCarMoveFiredEventArg> PoliceCarStartMoveEvent;
    CarPoliceContentViewController _controller;
    public bool HandledWeakReferenceRobbery {  get; set; }=false;
    public string RobberName { get; set; }

    private string _name = "";
    public string PoliceCarName
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    private Int32 _number = 0;
    public Int32 PoliceCarNumber
    {
        get
        {
            return _number;
        }
        set
        {
            _number = value;
        }
    }

    public CarPoliceContent()
    {
        InitializeComponent();
        Opacity = 0;
        _controller = new CarPoliceContentViewController(this);
        RobberyMessageDetailEntity RobberyMessageDetail;
        WeakReferenceMessenger.Default.Register<RobberyMessage>(this, (r, m) =>
         {
             RobberyMessageDetail = m.Value;
            //Global.WriteDebutOutput("Playing sound");
             //mediaElement.Play();
             //SendMessageOnRobbery();
             if (RobberName == RobberyMessageDetail.RobberName && 
                HandledWeakReferenceRobbery == false)
             {
                 Global.WriteDebugOutput("WeakReferenceMessenger pol car robber " + RobberName);
                 arg = new PoliceCarMoveFiredEventArg(
                     RobberyMessageDetail.RobberName, RobberyMessageDetail.Business);
                 _controller.PoliceCarStartMove(RobberyMessageDetail.Business, RobberyMessageDetail.RobberName);
                 HandledWeakReferenceRobbery = true;

             }
         });
       
    }
    public void ChangeDirection(PositionsEWNSEnum position)
    {
        Global.WriteDebugOutput("ChangeDirection " + position.ToString());
        switch (position)
        {
            case PositionsEWNSEnum.North:
                CarImage.Source = "policemuaclecarnorth.png";
                break;
            case PositionsEWNSEnum.South:
                CarImage.Source = "policemuaclecarsouth.png";
                break;
            case PositionsEWNSEnum.East:
                CarImage.Source = "policemuaclecarright.png";
                break;
            case PositionsEWNSEnum.West:
                CarImage.Source = "policemuaclecar.png";
                break;
            default:
                break;
        }
    }
    public void FireMoveCarEvent(LocationXYEntity locationXY)
    {
        arg.LocationXY = locationXY;
        if (PoliceCarStartMoveEvent != null)
            PoliceCarStartMoveEvent(this, arg);
    }

}
