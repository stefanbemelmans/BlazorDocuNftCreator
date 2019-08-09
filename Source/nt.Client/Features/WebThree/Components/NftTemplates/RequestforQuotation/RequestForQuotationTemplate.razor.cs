﻿namespace nt.Client.Features.WebThree.Components.NftTemplates.RequestForQuotation
{
  using Microsoft.AspNetCore.Components;
  using nt.Client.Features.Base.Components;
  using nt.Client.Features.WebThree.Actions.AddFormDataToState;
  using System;

  public class RequestForQuotationTemplateModel : BaseComponent
  {
    [Parameter]
    public RequestForQuotationData FormData { get; set; } = new RequestForQuotationData();

    public string MutableDataString { get; set; }

    public RequestForQuotationTemplateModel()
    {
      FormData.Title = "Request For Quotation";
    }

    public void ConsoleData()
    {
      Console.WriteLine("Trying to Console...empty?");
      foreach (System.Reflection.PropertyInfo prop in FormData.GetType().GetProperties())
      {
        Console.WriteLine($"{prop.Name}: {prop.GetValue(FormData)}");
      }
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
  }
}