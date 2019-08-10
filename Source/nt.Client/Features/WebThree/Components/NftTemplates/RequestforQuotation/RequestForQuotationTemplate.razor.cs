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

  public class RequestForQuotationData : ImmutableObjectBase
  {
    public string DeliveryTerms { get; set; }
    public string CustomClearance { get; set; }
    public string UndPreferred { get; set; }
    public DateTime LatestExpectedDeliveryData { get; set; } = DateTime.Now;
    public string DeliverySchedule { get; set; }
    public string ModeOfTransport { get; set; }
    public string AfterSalesService { get; set; }
    public DateTime Deadline { get; set; } = DateTime.Now;  
    public string DocumentationLanguage { get; set; }
    public string PeriodOfValidity { get; set; }
    public string PartialQuotes { get; set; }
    public string PaymentTerms { get; set; }
    public string Awardees { get; set; }
    public string ContractType { get; set; }
    public string CancelationPolicy { get; set; }
    public string ConditionsOfRelease { get; set; }
    public string Contract { get; set; }
    public string EquivalentSubstitution { get; set; }
  }
}