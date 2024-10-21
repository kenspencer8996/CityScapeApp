using CityScapeApp.Objects;
using CityScapeApp.Objects.Entities;
using CityScapeApp.Views.Controls.House;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using System;

namespace CityScapeApp.Views.Controls.Person;

public partial class PersonContent : ContentView
{
    PersonEntity _person;
    public PersonContent()
    {
        InitializeComponent();
    }
    public PersonContent(PersonEntity person)
    {
        InitializeComponent();
        _person = person;
        person.Host = this;
        BindingContext = person;
        person.ShowPersonTimerFired += Person_PersonTimerFired;
        PersonFundsLabel.RotateTo(90);
    }
    public PersonEntity Person
    { 
        get 
        { return _person; }
        set
        {
            if (_person != value)
            {
                _person = value;
            }
        }
    }

    private void Person_PersonTimerFired(object? sender, PersonTimerFiredEventArg e)
    {
        if (e.Person.PersonRole == PersonEnum.BadGuy) 
        {
            this.IsVisible = true;
        }
    }

    private void OnDragStartingMyPerson(object sender, DragStartingEventArgs e)
    {
        HouseContent person = sender as HouseContent ;
        e.Data.Properties.Add("Person", _person.Name);
    }

   
}