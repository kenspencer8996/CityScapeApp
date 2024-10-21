using CityScapeApp.Objects;
using CityScapeApp.Objects.Entities;
using CityScapeApp.Views.Controls.House;
using CityScapeApp.Views.Controls.Person;

namespace CityScapeApp.Views.Controls.Business;

public partial class BusinessDetailContent : ContentView
{
    public string Name {  get; set; }
    public string ImageName { get; set; }
    public BuldingTypeEnum BusinessType { get; set; }
    public decimal EmployeePayHour { get; set; }
     public BusinessDetailContent(string name, string imageName,
         BuldingTypeEnum businessType, decimal employeePayHour)
    {
        InitializeComponent();
        Name = name;
        ImageName = imageName;
        BusinessType = businessType;    
        EmployeePayHour = employeePayHour;
    }
    public void SetPerson(HouseContent person)
    {
        PersonStack.Children.Clear();
        PersonStack.Children.Add(person);
    
    }
  
    void OnDragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.Copy;
    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {
        string name = (string)e.Data.Properties["Person"];
        var citiesFromq = from c in Global.CityAppMaster.CityApp
                          where
                        c.CityAppNumber == Global.CityAppMaster.CurrentCityAppNumber
                          select c;
        CityappEntity cityappEntity = new CityappEntity();
        if (citiesFromq != null || citiesFromq.Count() > 0)
        {
            cityappEntity = citiesFromq.FirstOrDefault();
        }
        var perq = from p in cityappEntity.Persons where p.Name == name select p;
        PersonWorkingContent personWorking = new PersonWorkingContent(perq.First());
        personWorking.StartPay(EmployeePayHour);
        PersonStack.Children.Add(personWorking);
    }
}