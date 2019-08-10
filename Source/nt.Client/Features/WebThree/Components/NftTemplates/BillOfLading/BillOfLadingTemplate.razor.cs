﻿namespace nt.Client.Features.WebThree.Components.NftTemplates.BillOfLading
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using System;

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
  public class BillOfLadingData : ImmutableObjectBase
  {
    public string Carrier { get; set; }
    public string Consignee { get; set; }
    public DateTime Date { get; set; }
    public string Details { get; set; }
    public string Instructions { get; set; }
    public string ItemCode { get; set; }
    public string Lading { get; set; }
    public string Order { get; set; }
    public string PO { get; set; }
    public string Quantity { get; set; }
    public string Shipper { get; set; }
    public string Weight { get; set; }
  }
}