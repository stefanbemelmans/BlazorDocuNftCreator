namespace nt.Client.Features.WebThree.Components.NftTemplates.BillOfLading
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using System;
  using System.Threading.Tasks;

  public class BillOfLadingTemplateModel : BaseComponent
  {
    [Parameter]
    public BillOfLadingData FormData { get; set; } = new BillOfLadingData();
    
    public string MutableDataString { get; set; }

    public BillOfLadingTemplateModel()
    {
      FormData.Title = "Bill Of Lading";
    }

    public async void SendDataToState()
    {
      ConsoleData();
      WebThreeState response = await Mediator.Send(new AddFormDataToStateAction()
      {
        FormObjectValues = FormData,
        MutableDataString = MutableDataString
      });

      WebThreeState.ImmutableObject = response.ImmutableObject;
      WebThreeState.MutableDataString = response.MutableDataString;
     
     
    }

    public void ConsoleData()
    {
      Console.WriteLine("Trying to Console...empty?");
      foreach (System.Reflection.PropertyInfo prop in FormData.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(FormData)}");
      }
    }
  }
}